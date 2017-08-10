/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Tizen.System;
using static Tizen.Multimedia.Interop.Radio;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides a means for using the radio feature.
    /// </summary>
    public class Radio : IDisposable
    {
        private Interop.RadioHandle _handle;

        private const string FeatureFmRadio = "http://tizen.org/feature/fmradio";

        /// <summary>
        /// Initialize a new instance of the Radio class.
        /// </summary>
        /// <exception cref="NotSupportedException">Radio feature is not supported</exception>
        public Radio()
        {
            ValidateFeatureSupported(FeatureFmRadio);

            Create(out _handle);

            try
            {
                SetScanCompletedCb(_handle, ScanCompleteCallback).ThrowIfFailed("Failed to initialize radio");
                SetInterruptedCb(_handle, InterruptedCallback).ThrowIfFailed("Failed to initialize radio");
            }
            catch (Exception)
            {
                _handle.Dispose();
                throw;
            }
        }

        private Interop.RadioHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                return _handle;
            }
        }

        /// <summary>
        /// Occurs when radio scan information is updated.
        /// </summary>
        public event EventHandler<ScanUpdatedEventArgs> ScanUpdated;

        /// <summary>
        /// Occurs when radio scanning stops.
        /// </summary>
        public event EventHandler ScanStopped;

        /// <summary>
        /// Occurs when radio scan is completed.
        /// </summary>
        public event EventHandler ScanCompleted;

        /// <summary>
        /// Occurs when radio is interrupted
        /// </summary>
        public event EventHandler<RadioInterruptedEventArgs> Interrupted;

        /// <summary>
        /// Gets the current state of the radio.
        /// </summary>
        public RadioState State
        {
            get
            {
                RadioState state;
                GetState(Handle, out state);
                return state;
            }
        }

        /// <summary>
        /// Gets or sets the radio frequency, in [87500 ~ 108000] (kHz).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than <see cref="Range.Min"/> of <see cref="FrequencyRange"/>.\n
        ///     - or - \n
        ///     <paramref name="value"/> is greater than <see cref="Range.Max"/> of <see cref="FrequencyRange"/>.\n
        /// </exception>
        public int Frequency
        {
            get
            {
                int value = 0;
                GetFrequency(Handle, out value).ThrowIfFailed("Failed to get frequency");
                return value;
            }
            set
            {
                if (value < FrequencyRange.Min || value > FrequencyRange.Max)
                {
                    throw new ArgumentOutOfRangeException(nameof(Frequency), value, "Frequency must be within FrequencyRange.");
                }

                SetFrequency(Handle, value).ThrowIfFailed("Failed to set frequency");
            }
        }

        /// <summary>
        /// Gets the current signal strength, in [-128 ~ 128] (dBm).
        /// </summary>
        public int SignalStrength
        {
            get
            {
                int value = 0;
                GetSignalStrength(Handle, out value).ThrowIfFailed("Failed to get signal strength");
                return value;
            }
        }

        /// <summary>
        /// Gets the value indicating if radio is muted.
        /// </summary>
        /// <value>
        /// true if the radio is muted; otherwise, false.
        /// The default is false.
        /// </value>
        public bool IsMuted
        {
            get
            {
                bool value;
                GetMuted(Handle, out value).ThrowIfFailed("Failed to get the mute state");
                return value;
            }
            set
            {
                SetMute(Handle, value).ThrowIfFailed("Failed to set the mute state");
            }
        }

        /// <summary>
        /// Gets the channel spacing for current region.
        /// </summary>
        public int ChannelSpacing
        {
            get
            {
                int value;
                GetChannelSpacing(Handle, out value).ThrowIfFailed("Failed to get channel spacing");
                return value;
            }
        }

        /// <summary>
        /// Gets or sets the radio volume level.
        /// </summary>
        /// <remarks>Valid volume range is from 0 to 1.0(100%), inclusive.</remarks>
        /// <value>The default is 1.0.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.\n
        ///     - or -\n
        ///     <paramref name="value"/> is greater than 1.0.
        /// </exception>
        public float Volume
        {
            get
            {
                float value;
                GetVolume(Handle, out value).ThrowIfFailed("Failed to get volume level.");
                return value;
            }
            set
            {
                if (value < 0F || 1.0F < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Valid volume range is 0 <= value <= 1.0, but got { value }.");
                }

                SetVolume(Handle, value).ThrowIfFailed("Failed to set volume level");
            }
        }

        /// <summary>
        /// Gets the frequency for the region, in [87500 ~ 108000] (kHz).
        /// </summary>
        public Range FrequencyRange
        {
            get
            {
                int min, max;

                GetFrequencyRange(Handle, out min, out max).ThrowIfFailed("Failed to get frequency range");

                return new Range(min, max);
            }
        }

        /// <summary>
        /// Starts the radio.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Ready"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        public void Start()
        {
            ValidateRadioState(RadioState.Ready);

            Interop.Radio.Start(Handle).ThrowIfFailed("Failed to start radio");
        }

        /// <summary>
        /// Stops the radio.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        public void Stop()
        {
            ValidateRadioState(RadioState.Playing);

            Interop.Radio.Stop(Handle).ThrowIfFailed("Failed to stop radio");
        }

        /// <summary>
        /// Starts radio scan, will trigger ScanInformationUpdated event, when scan information is updated
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Ready"/> or <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <seealso cref="ScanUpdated"/>
        /// <seealso cref="ScanCompleted"/>
        public void StartScan()
        {
            ValidateRadioState(RadioState.Ready, RadioState.Playing);

            ScanStart(Handle, ScanUpdatedCallback);
        }

        /// <summary>
        /// Stops radio scan.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Scanning"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <seealso cref="ScanStopped"/>
        public void StopScan()
        {
            ValidateRadioState(RadioState.Scanning);

            ScanStop(Handle, ScanStoppedCallback);
        }

        /// <summary>
        /// Seeks up the effective frequency of the radio.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous seeking operation.
        /// The result value is the current frequency, in range [87500 ~ 108000] (kHz).
        /// It can be -1 if the seeking operation has failed.
        /// </returns>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        public async Task<int> SeekUpAsync()
        {
            ValidateRadioState(RadioState.Playing);

            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            SeekCompletedCallback callback = (currentFrequency, _) =>
            {
                tcs.TrySetResult(currentFrequency);
            };

            SeekUp(Handle, callback);
            return await tcs.Task;
        }

        /// <summary>
        /// Seeks down the effective frequency of the radio.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous seeking operation.
        /// The result value is the current frequency, in range [87500 ~ 108000] (kHz).
        /// It can be -1 if the seeking operation has failed.
        /// </returns>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        public async Task<int> SeekDownAsync()
        {
            ValidateRadioState(RadioState.Playing);

            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            SeekCompletedCallback callback = (currentFrequency, _) =>
            {
                tcs.TrySetResult(currentFrequency);
            };

            SeekDown(Handle, callback);
            return await tcs.Task;
        }

        private void ValidateFeatureSupported(string featurePath)
        {
            bool supported = false;
            SystemInfo.TryGetValue(featurePath, out supported);

            if (supported == false)
            {
                throw new NotSupportedException($"The feature({featurePath}) is not supported.");
            }

        }

        private void ScanUpdatedCallback(int frequency, IntPtr data)
        {
            ScanUpdated?.Invoke(this, new ScanUpdatedEventArgs(frequency));
        }

        private void ScanStoppedCallback(IntPtr data)
        {
            ScanStopped?.Invoke(this, EventArgs.Empty);
        }

        private void ScanCompleteCallback(IntPtr data)
        {
            ScanCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void InterruptedCallback(RadioInterruptedReason reason, IntPtr data)
        {
            Interrupted?.Invoke(this, new RadioInterruptedEventArgs(reason));
        }

        private void ValidateRadioState(params RadioState[] required)
        {
            RadioState curState = State;

            if (required.Contains(curState) == false)
            {
                throw new InvalidOperationException($"{curState} is not valid state.");
            }
        }

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Releases the resources used by the Radio.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != null)
                {
                    _handle.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="Radio"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
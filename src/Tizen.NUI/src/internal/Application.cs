/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;

    /**
      * @brief Event arguments that passed via NUIApplicationInit signal
      *
      */
    internal class NUIApplicationInitEventArgs : EventArgs
    {
        private Application _application;

        /**
          * @brief Application - is the application that is being initialized
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationTerminate signal
      *
      */
    internal class NUIApplicationTerminatingEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Terminated
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationPause signal
      *
      */
    internal class NUIApplicationPausedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Paused
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationResume signal
      *
      */
    internal class NUIApplicationResumedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Resumed
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationReset signal
      *
      */
    internal class NUIApplicationResetEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Reset
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationResize signal
      *
      */
    internal class NUIApplicationResizedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Resized
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationLanguageChanged signal
      *
      */
    internal class NUIApplicationLanguageChangedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being affected with Device's language change
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationRegionChanged signal
      *
      */
    internal class NUIApplicationRegionChangedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being affected with Device's region change
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationBatteryLow signal
      *
      */
    internal class NUIApplicationBatteryLowEventArgs : EventArgs
    {
        private Application.BatteryStatus _status;
        /**
          * @brief Application - is the application that is being affected when the battery level of the device is low
          *
          */
        public Application.BatteryStatus BatteryStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationMemoryLow signal
      *
      */
    internal class NUIApplicationMemoryLowEventArgs : EventArgs
    {
        private Application.MemoryStatus _status;
        /**
          * @brief Application - is the application that is being affected when the memory level of the device is low
          *
          */
        public Application.MemoryStatus MemoryStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationAppControl	 signal
      *
      */
    internal class NUIApplicationAppControlEventArgs : EventArgs
    {
        private Application _application;
        private IntPtr _voidp;
        /**
          * @brief Application - is the application that is receiving the launch request from another application
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
        /**
          * @brief VoidP - contains the information about why the application is launched
          *
          */
        public IntPtr VoidP
        {
            get
            {
                return _voidp;
            }
            set
            {
                _voidp = value;
            }
        }
    }

    internal class Application : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Application(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Application_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Application obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (_applicationInitEventCallbackDelegate != null)
            {
                this.InitSignal().Disconnect(_applicationInitEventCallbackDelegate);
            }

            if (_applicationTerminateEventCallbackDelegate != null)
            {
                this.TerminateSignal().Disconnect(_applicationTerminateEventCallbackDelegate);
            }

            if (_applicationPauseEventCallbackDelegate != null)
            {
                this.PauseSignal().Disconnect(_applicationPauseEventCallbackDelegate);
            }

            if (_applicationResumeEventCallbackDelegate != null)
            {
                this.ResumeSignal().Disconnect(_applicationResumeEventCallbackDelegate);
            }

            if (_applicationResetEventCallbackDelegate != null)
            {
                this.ResetSignal().Disconnect(_applicationResetEventCallbackDelegate);
            }

            if (_applicationResizeEventCallbackDelegate != null)
            {
                this.ResizeSignal().Disconnect(_applicationResizeEventCallbackDelegate);
            }

            if (_applicationLanguageChangedEventCallbackDelegate != null)
            {
                this.LanguageChangedSignal().Disconnect(_applicationLanguageChangedEventCallbackDelegate);
            }

            if (_applicationRegionChangedEventCallbackDelegate != null)
            {
                this.RegionChangedSignal().Disconnect(_applicationRegionChangedEventCallbackDelegate);
            }

            if (_applicationBatteryLowEventCallbackDelegate != null)
            {
                this.BatteryLowSignal().Disconnect(_applicationBatteryLowEventCallbackDelegate);
            }

            if (_applicationMemoryLowEventCallbackDelegate != null)
            {
                this.MemoryLowSignal().Disconnect(_applicationMemoryLowEventCallbackDelegate);
            }

            if (_applicationAppControlEventCallbackDelegate != null)
            {
                this.AppControlSignal().Disconnect(_applicationAppControlEventCallbackDelegate);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Application(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <since_tizen> 4 </since_tizen>
        public enum BatteryStatus
        {
            Normal,
            CriticallyLow,
            PowerOff
        };

        /// <since_tizen> 4 </since_tizen>
        public enum MemoryStatus
        {
            Normal,
            Low,
            CriticallyLow
        };

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationInitEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationInitEventArgs> _applicationInitEventHandler;
        private NUIApplicationInitEventCallbackDelegate _applicationInitEventCallbackDelegate;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationTerminateEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationTerminatingEventArgs> _applicationTerminateEventHandler;
        private NUIApplicationTerminateEventCallbackDelegate _applicationTerminateEventCallbackDelegate;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationPauseEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationPausedEventArgs> _applicationPauseEventHandler;
        private NUIApplicationPauseEventCallbackDelegate _applicationPauseEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationResumeEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResumedEventArgs> _applicationResumeEventHandler;
        private NUIApplicationResumeEventCallbackDelegate _applicationResumeEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationResetEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResetEventArgs> _applicationResetEventHandler;
        private NUIApplicationResetEventCallbackDelegate _applicationResetEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationResizeEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResizedEventArgs> _applicationResizeEventHandler;
        private NUIApplicationResizeEventCallbackDelegate _applicationResizeEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationLanguageChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> _applicationLanguageChangedEventHandler;
        private NUIApplicationLanguageChangedEventCallbackDelegate _applicationLanguageChangedEventCallbackDelegate;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationRegionChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> _applicationRegionChangedEventHandler;
        private NUIApplicationRegionChangedEventCallbackDelegate _applicationRegionChangedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationBatteryLowEventCallbackDelegate(BatteryStatus status);
        private DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> _applicationBatteryLowEventHandler;
        private NUIApplicationBatteryLowEventCallbackDelegate _applicationBatteryLowEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationMemoryLowEventCallbackDelegate(MemoryStatus status);
        private DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> _applicationMemoryLowEventHandler;
        private NUIApplicationMemoryLowEventCallbackDelegate _applicationMemoryLowEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void NUIApplicationAppControlEventCallbackDelegate(IntPtr application, IntPtr voidp);
        private DaliEventHandler<object, NUIApplicationAppControlEventArgs> _applicationAppControlEventHandler;
        private NUIApplicationAppControlEventCallbackDelegate _applicationAppControlEventCallbackDelegate;

        /**
          * @brief Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Initialized signal is emitted when application is initialised
          */
        public event DaliEventHandler<object, NUIApplicationInitEventArgs> Initialized
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationInitEventHandler == null)
                    {
                        _applicationInitEventHandler += value;

                        _applicationInitEventCallbackDelegate = new NUIApplicationInitEventCallbackDelegate(OnApplicationInit);
                        this.InitSignal().Connect(_applicationInitEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationInitEventHandler != null)
                    {
                        this.InitSignal().Disconnect(_applicationInitEventCallbackDelegate);
                    }

                    _applicationInitEventHandler -= value;
                }
            }
        }

        // Callback for Application InitSignal
        private void OnApplicationInit(IntPtr data)
        {
            // Initialize DisposeQueue Singleton class. This is also required to create DisposeQueue on main thread.
            DisposeQueue.Instance.Initialize();

            NUIApplicationInitEventArgs e = new NUIApplicationInitEventArgs();
            // Populate all members of "e" (NUIApplicationInitEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);
            if (_applicationInitEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationInitEventHandler(this, e);
            }
        }

        /**
          * @brief Event for Terminated signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Terminated signal is emitted when application is terminating
          */
        public event DaliEventHandler<object, NUIApplicationTerminatingEventArgs> Terminating
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationTerminateEventHandler == null)
                    {
                        _applicationTerminateEventHandler += value;

                        _applicationTerminateEventCallbackDelegate = new NUIApplicationTerminateEventCallbackDelegate(OnNUIApplicationTerminate);
                        this.TerminateSignal().Connect(_applicationTerminateEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationTerminateEventHandler != null)
                    {
                        this.TerminateSignal().Disconnect(_applicationTerminateEventCallbackDelegate);
                    }

                    _applicationTerminateEventHandler -= value;
                }
            }
        }

        // Callback for Application TerminateSignal
        private void OnNUIApplicationTerminate(IntPtr data)
        {
            NUIApplicationTerminatingEventArgs e = new NUIApplicationTerminatingEventArgs();

            // Populate all members of "e" (NUIApplicationTerminateEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationTerminateEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationTerminateEventHandler(this, e);
            }
        }

        /**
          * @brief Event for Paused signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. Paused signal is emitted when application is paused
          */
        public event DaliEventHandler<object, NUIApplicationPausedEventArgs> Paused
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationPauseEventHandler == null)
                    {
                        _applicationPauseEventHandler += value;

                        _applicationPauseEventCallbackDelegate = new NUIApplicationPauseEventCallbackDelegate(OnNUIApplicationPause);
                        this.PauseSignal().Connect(_applicationPauseEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationPauseEventHandler != null)
                    {
                        this.PauseSignal().Disconnect(_applicationPauseEventCallbackDelegate);
                    }

                    _applicationPauseEventHandler -= value;
                }
            }
        }

        // Callback for Application PauseSignal
        private void OnNUIApplicationPause(IntPtr data)
        {
            NUIApplicationPausedEventArgs e = new NUIApplicationPausedEventArgs();

            // Populate all members of "e" (NUIApplicationPauseEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationPauseEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationPauseEventHandler(this, e);
            }
        }

        /**
          * @brief Event for Resumed signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Resumed signal is emitted when application is resumed
          */
        public event DaliEventHandler<object, NUIApplicationResumedEventArgs> Resumed
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationResumeEventHandler == null)
                    {
                        _applicationResumeEventHandler += value;

                        _applicationResumeEventCallbackDelegate = new NUIApplicationResumeEventCallbackDelegate(OnNUIApplicationResume);
                        this.ResumeSignal().Connect(_applicationResumeEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationResumeEventHandler != null)
                    {
                        this.ResumeSignal().Disconnect(_applicationResumeEventCallbackDelegate);
                    }

                    _applicationResumeEventHandler -= value;
                }
            }
        }

        // Callback for Application ResumeSignal
        private void OnNUIApplicationResume(IntPtr data)
        {
            NUIApplicationResumedEventArgs e = new NUIApplicationResumedEventArgs();

            // Populate all members of "e" (NUIApplicationResumeEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationResumeEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationResumeEventHandler(this, e);
            }
        }

        /**
          * @brief Event for Reset signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Reset signal is emitted when application is reset
          */
        public new event DaliEventHandler<object, NUIApplicationResetEventArgs> Reset
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationResetEventHandler == null)
                    {
                        _applicationResetEventHandler += value;

                        _applicationResetEventCallbackDelegate = new NUIApplicationResetEventCallbackDelegate(OnNUIApplicationReset);
                        this.ResetSignal().Connect(_applicationResetEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationResetEventHandler != null)
                    {
                        this.ResetSignal().Disconnect(_applicationResetEventCallbackDelegate);
                    }

                    _applicationResetEventHandler -= value;
                }
            }
        }

        // Callback for Application ResetSignal
        private void OnNUIApplicationReset(IntPtr data)
        {
            NUIApplicationResetEventArgs e = new NUIApplicationResetEventArgs();

            // Populate all members of "e" (NUIApplicationResetEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationResetEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationResetEventHandler(this, e);
            }
        }

        /**
          * @brief Event for Resized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Resized signal is emitted when application is resized
          */
        public event DaliEventHandler<object, NUIApplicationResizedEventArgs> Resized
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationResizeEventHandler == null)
                    {
                        _applicationResizeEventHandler += value;

                        _applicationResizeEventCallbackDelegate = new NUIApplicationResizeEventCallbackDelegate(OnNUIApplicationResize);
                        this.ResizeSignal().Connect(_applicationResizeEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationResizeEventHandler != null)
                    {
                        this.ResizeSignal().Disconnect(_applicationResizeEventCallbackDelegate);
                    }

                    _applicationResizeEventHandler -= value;
                }
            }
        }

        // Callback for Application ResizeSignal
        private void OnNUIApplicationResize(IntPtr data)
        {
            NUIApplicationResizedEventArgs e = new NUIApplicationResizedEventArgs();

            // Populate all members of "e" (NUIApplicationResizeEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationResizeEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationResizeEventHandler(this, e);
            }
        }

        /**
          * @brief Event for LanguageChanged signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. LanguageChanged signal is emitted when the region of the device is changed.
          */
        public event DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationLanguageChangedEventHandler == null)
                    {
                        _applicationLanguageChangedEventHandler += value;

                        _applicationLanguageChangedEventCallbackDelegate = new NUIApplicationLanguageChangedEventCallbackDelegate(OnNUIApplicationLanguageChanged);
                        this.LanguageChangedSignal().Connect(_applicationLanguageChangedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationLanguageChangedEventHandler != null)
                    {
                        this.LanguageChangedSignal().Disconnect(_applicationLanguageChangedEventCallbackDelegate);
                    }

                    _applicationLanguageChangedEventHandler -= value;
                }
            }
        }

        // Callback for Application LanguageChangedSignal
        private void OnNUIApplicationLanguageChanged(IntPtr data)
        {
            NUIApplicationLanguageChangedEventArgs e = new NUIApplicationLanguageChangedEventArgs();

            // Populate all members of "e" (NUIApplicationLanguageChangedEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationLanguageChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationLanguageChangedEventHandler(this, e);
            }
        }

        /**
          * @brief Event for RegionChanged signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. RegionChanged signal is emitted when the region of the device is changed.
          */
        public event DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> RegionChanged
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationRegionChangedEventHandler == null)
                    {
                        _applicationRegionChangedEventHandler += value;

                        _applicationRegionChangedEventCallbackDelegate = new NUIApplicationRegionChangedEventCallbackDelegate(OnNUIApplicationRegionChanged);
                        this.RegionChangedSignal().Connect(_applicationRegionChangedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationRegionChangedEventHandler != null)
                    {
                        this.RegionChangedSignal().Disconnect(_applicationRegionChangedEventCallbackDelegate);
                    }

                    _applicationRegionChangedEventHandler -= value;
                }
            }
        }

        // Callback for Application RegionChangedSignal
        private void OnNUIApplicationRegionChanged(IntPtr data)
        {
            NUIApplicationRegionChangedEventArgs e = new NUIApplicationRegionChangedEventArgs();

            // Populate all members of "e" (NUIApplicationRegionChangedEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(data);

            if (_applicationRegionChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationRegionChangedEventHandler(this, e);
            }
        }

        /**
          * @brief Event for BatteryLow signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. BatteryLow signal is emitted when the battery level of the device is low.
          */
        public event DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> BatteryLow
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationBatteryLowEventHandler == null)
                    {
                        _applicationBatteryLowEventHandler += value;

                        _applicationBatteryLowEventCallbackDelegate = new NUIApplicationBatteryLowEventCallbackDelegate(OnNUIApplicationBatteryLow);
                        this.BatteryLowSignal().Connect(_applicationBatteryLowEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationBatteryLowEventHandler != null)
                    {
                        this.BatteryLowSignal().Disconnect(_applicationBatteryLowEventCallbackDelegate);
                    }

                    _applicationBatteryLowEventHandler -= value;
                }
            }
        }

        // Callback for Application BatteryLowSignal
        private void OnNUIApplicationBatteryLow(BatteryStatus status)
        {
            NUIApplicationBatteryLowEventArgs e = new NUIApplicationBatteryLowEventArgs();

            // Populate all members of "e" (NUIApplicationBatteryLowEventArgs) with real data
            e.BatteryStatus = status;

            if (_applicationBatteryLowEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationBatteryLowEventHandler(this, e);
            }
        }

        /**
          * @brief Event for MemoryLow signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. MemoryLow signal is emitted when the memory level of the device is low.
          */
        public event DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> MemoryLow
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationMemoryLowEventHandler == null)
                    {
                        _applicationMemoryLowEventHandler += value;

                        _applicationMemoryLowEventCallbackDelegate = new NUIApplicationMemoryLowEventCallbackDelegate(OnNUIApplicationMemoryLow);
                        this.MemoryLowSignal().Connect(_applicationMemoryLowEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationMemoryLowEventHandler != null)
                    {
                        this.MemoryLowSignal().Disconnect(_applicationMemoryLowEventCallbackDelegate);
                    }

                    _applicationMemoryLowEventHandler -= value;
                }
            }
        }

        // Callback for Application MemoryLowSignal
        private void OnNUIApplicationMemoryLow(MemoryStatus status)
        {
            NUIApplicationMemoryLowEventArgs e = new NUIApplicationMemoryLowEventArgs();

            // Populate all members of "e" (NUIApplicationMemoryLowEventArgs) with real data
            e.MemoryStatus = status;

            if (_applicationMemoryLowEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationMemoryLowEventHandler(this, e);
            }
        }

        /**
          * @brief Event for AppControl signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. AppControl signal is emitted when another application sends a launch request to the application.
          */
        public event DaliEventHandler<object, NUIApplicationAppControlEventArgs> AppControl
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_applicationAppControlEventHandler == null)
                    {
                        _applicationAppControlEventHandler += value;

                        _applicationAppControlEventCallbackDelegate = new NUIApplicationAppControlEventCallbackDelegate(OnNUIApplicationAppControl);
                        this.AppControlSignal().Connect(_applicationAppControlEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_applicationAppControlEventHandler != null)
                    {
                        this.AppControlSignal().Disconnect(_applicationAppControlEventCallbackDelegate);
                    }

                    _applicationAppControlEventHandler -= value;
                }
            }
        }

        // Callback for Application AppControlSignal
        private void OnNUIApplicationAppControl(IntPtr application, IntPtr voidp)
        {
            NUIApplicationAppControlEventArgs e = new NUIApplicationAppControlEventArgs();

            // Populate all members of "e" (NUIApplicationAppControlEventArgs) with real data
            e.Application = Application.GetApplicationFromPtr(application);
            e.VoidP = voidp;

            if (_applicationAppControlEventHandler != null)
            {
                //here we send all data to user event handlers
                _applicationAppControlEventHandler(this, e);
            }
        }

        private static Application _instance; // singleton

        public static Application Instance
        {
            get
            {
                return _instance;
            }
        }

        public static Application GetApplicationFromPtr(global::System.IntPtr cPtr)
        {
            Application ret = new Application(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application NewApplication()
        {
            return NewApplication("", Application.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet)
        {
            return NewApplication(stylesheet, Application.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet, Application.WindowMode windowMode)
        {
            // register all Views with the type registry, so that can be created / styled via JSON
            //ViewRegistryHelper.Initialize(); //moved to Application side.

            Application ret = New(1, stylesheet, windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return ret;
        }


        public static Application NewApplication(string[] args, string stylesheet, Application.WindowMode windowMode)
        {
            Application ret = New(args, stylesheet, (Application.WindowMode)windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return _instance;
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
        public bool AddIdle(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            System.IntPtr ip2 = NDalicManualPINVOKE.MakeCallback(new System.Runtime.InteropServices.HandleRef(this, ip));

            bool ret = NDalicPINVOKE.Application_AddIdle(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip2));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /**
        * Outer::outer_method(int)
        */
        public static Application New()
        {
            Application ret = new Application(NDalicPINVOKE.Application_New__SWIG_0(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc)
        {
            Application ret = new Application(NDalicPINVOKE.Application_New__SWIG_1(argc), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc, string stylesheet)
        {
            Application ret = new Application(NDalicPINVOKE.Application_New__SWIG_2(argc, stylesheet), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc, string stylesheet, Application.WindowMode windowMode)
        {
            Application ret = new Application(NDalicPINVOKE.Application_New__SWIG_3(argc, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(string[] args, string stylesheet, Application.WindowMode windowMode)
        {
            int argc = args.Length;
            string argvStr = string.Join(" ", args);

            Application ret = new Application(NDalicPINVOKE.Application_New__MANUAL_4(argc, argvStr, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc, string stylesheet, Application.WindowMode windowMode, Rectangle positionSize)
        {
            Application ret = new Application(NDalicPINVOKE.Application_New__SWIG_4(argc, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Application() : this(NDalicPINVOKE.new_Application__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Application(Application application) : this(NDalicPINVOKE.new_Application__SWIG_1(Application.getCPtr(application)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Application Assign(Application application)
        {
            Application ret = new Application(NDalicPINVOKE.Application_Assign(swigCPtr, Application.getCPtr(application)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void MainLoop()
        {
            NDalicPINVOKE.Application_MainLoop__SWIG_0(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void MainLoop(SWIGTYPE_p_Configuration__ContextLoss configuration)
        {
            NDalicPINVOKE.Application_MainLoop__SWIG_1(swigCPtr, SWIGTYPE_p_Configuration__ContextLoss.getCPtr(configuration));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Lower()
        {
            NDalicPINVOKE.Application_Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Quit()
        {
            NDalicPINVOKE.Application_Quit(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool AddIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            bool ret = NDalicPINVOKE.Application_AddIdle(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Window GetWindow()
        {
            Window ret = new Window(NDalicPINVOKE.Application_GetWindow(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ReplaceWindow(Rectangle windowPosition, string name)
        {
            NDalicPINVOKE.Application_ReplaceWindow(swigCPtr, Rectangle.getCPtr(windowPosition), name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static string GetResourcePath()
        {
            string ret = NDalicPINVOKE.Application_GetResourcePath();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetViewMode(ViewMode viewMode)
        {
            NDalicPINVOKE.Application_SetViewMode(swigCPtr, (int)viewMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ViewMode GetViewMode()
        {
            ViewMode ret = (ViewMode)NDalicPINVOKE.Application_GetViewMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetStereoBase(float stereoBase)
        {
            NDalicPINVOKE.Application_SetStereoBase(swigCPtr, stereoBase);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetStereoBase()
        {
            float ret = NDalicPINVOKE.Application_GetStereoBase(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetLanguage()
        {
            string ret = NDalicPINVOKE.Application_GetLanguage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetRegion()
        {
            string ret = NDalicPINVOKE.Application_GetRegion(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        internal ApplicationSignal InitSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_InitSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal TerminateSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_TerminateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal PauseSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_PauseSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal ResumeSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_ResumeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal ResetSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_ResetSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal ResizeSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_ResizeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationControlSignal AppControlSignal()
        {
            ApplicationControlSignal ret = new ApplicationControlSignal(NDalicPINVOKE.Application_AppControlSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal LanguageChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_LanguageChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal RegionChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.Application_RegionChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowBatterySignalType BatteryLowSignal()
        {
            LowBatterySignalType ret = new LowBatterySignalType(NDalicPINVOKE.Application_LowBatterySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowMemorySignalType MemoryLowSignal()
        {
            LowMemorySignalType ret = new LowMemorySignalType(NDalicPINVOKE.Application_LowMemorySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum WindowMode
        {
            Opaque = 0,
            Transparent = 1
        }

    }

}

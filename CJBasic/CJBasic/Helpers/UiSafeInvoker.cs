namespace CJBasic.Helpers
{
    using CJBasic;
    using CJBasic.Loggers;
    using System;
    using System.Windows.Forms;

    public class UiSafeInvoker
    {
        private IAgileLogger agileLogger = new EmptyAgileLogger();
        private Control control;
        private bool showMessageBox = false;
        private bool useBeginInvoke = false;

        public UiSafeInvoker(Control ui, bool showMessageBoxOnException, bool beginInvoke, IAgileLogger logger)
        {
            this.control = ui;
            this.agileLogger = logger ?? new EmptyAgileLogger();
            this.showMessageBox = showMessageBoxOnException;
            this.useBeginInvoke = beginInvoke;
        }

        public void ActionOnUI(CbGeneric method)
        {
            this.ActionOnUI(this.showMessageBox, this.useBeginInvoke, method);
        }

        public void ActionOnUI<T1>(CbGeneric<T1> method, T1 args)
        {
            this.ActionOnUI<T1>(this.showMessageBox, this.useBeginInvoke, method, args);
        }

        public void ActionOnUI<T1, T2>(CbGeneric<T1, T2> method, T1 arg1, T2 arg2)
        {
            this.ActionOnUI<T1, T2>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2);
        }

        public void ActionOnUI(bool showMessageBoxOnException, bool beginInvoke, CbGeneric method)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric>(this.Do_ActionOnUI), new object[] { showMessageBoxOnException, method });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric>(this.Do_ActionOnUI), new object[] { showMessageBoxOnException, method });
                }
            }
            else
            {
                this.Do_ActionOnUI(showMessageBoxOnException, method);
            }
        }

        public void ActionOnUI<T1, T2, T3>(CbGeneric<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
            this.ActionOnUI<T1, T2, T3>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2, arg3);
        }

        public void ActionOnUI<T1>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1> method, T1 args)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1>, T1>(this.Do_ActionOnUI<T1>), new object[] { showMessageBoxOnException, method, args });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1>, T1>(this.Do_ActionOnUI<T1>), new object[] { showMessageBoxOnException, method, args });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1>(showMessageBoxOnException, method, args);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4>(CbGeneric<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            this.ActionOnUI<T1, T2, T3, T4>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2, arg3, arg4);
        }

        public void ActionOnUI<T1, T2>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2> method, T1 arg1, T2 arg2)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2>, T1, T2>(this.Do_ActionOnUI<T1, T2>), new object[] { showMessageBoxOnException, method, arg1, arg2 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2>, T1, T2>(this.Do_ActionOnUI<T1, T2>), new object[] { showMessageBoxOnException, method, arg1, arg2 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2>(showMessageBoxOnException, method, arg1, arg2);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4, T5>(CbGeneric<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            this.ActionOnUI<T1, T2, T3, T4, T5>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2, arg3, arg4, arg5);
        }

        public void ActionOnUI<T1, T2, T3>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2, T3>, T1, T2, T3>(this.Do_ActionOnUI<T1, T2, T3>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2, T3>, T1, T2, T3>(this.Do_ActionOnUI<T1, T2, T3>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2, T3>(showMessageBoxOnException, method, arg1, arg2, arg3);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4, T5, T6>(CbGeneric<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            this.ActionOnUI<T1, T2, T3, T4, T5, T6>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void ActionOnUI<T1, T2, T3, T4>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4>, T1, T2, T3, T4>(this.Do_ActionOnUI<T1, T2, T3, T4>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4>, T1, T2, T3, T4>(this.Do_ActionOnUI<T1, T2, T3, T4>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2, T3, T4>(showMessageBoxOnException, method, arg1, arg2, arg3, arg4);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4, T5, T6, T7>(CbGeneric<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            this.ActionOnUI<T1, T2, T3, T4, T5, T6, T7>(this.showMessageBox, this.useBeginInvoke, method, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public void ActionOnUI<T1, T2, T3, T4, T5>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>(this.Do_ActionOnUI<T1, T2, T3, T4, T5>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>(this.Do_ActionOnUI<T1, T2, T3, T4, T5>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2, T3, T4, T5>(showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4, T5, T6>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6>(this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6>(this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6>(showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        public void ActionOnUI<T1, T2, T3, T4, T5, T6, T7>(bool showMessageBoxOnException, bool beginInvoke, CbGeneric<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (this.control.InvokeRequired)
            {
                if (beginInvoke)
                {
                    this.control.BeginInvoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>(this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6, T7>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
                }
                else
                {
                    this.control.Invoke(new CbGeneric<bool, CbGeneric<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>(this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6, T7>), new object[] { showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
                }
            }
            else
            {
                this.Do_ActionOnUI<T1, T2, T3, T4, T5, T6, T7>(showMessageBoxOnException, method, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }

        private void Do_ActionOnUI(bool showMessageBoxOnException, CbGeneric method)
        {
            try
            {
                method();
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1>(bool showMessageBoxOnException, CbGeneric<T1> method, T1 args)
        {
            try
            {
                method(args);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2>(bool showMessageBoxOnException, CbGeneric<T1, T2> method, T1 arg1, T2 arg2)
        {
            try
            {
                method(arg1, arg2);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2, T3>(bool showMessageBoxOnException, CbGeneric<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
            try
            {
                method(arg1, arg2, arg3);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2, T3, T4>(bool showMessageBoxOnException, CbGeneric<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            try
            {
                method(arg1, arg2, arg3, arg4);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2, T3, T4, T5>(bool showMessageBoxOnException, CbGeneric<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2, T3, T4, T5, T6>(bool showMessageBoxOnException, CbGeneric<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5, arg6);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Do_ActionOnUI<T1, T2, T3, T4, T5, T6, T7>(bool showMessageBoxOnException, CbGeneric<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            try
            {
                method(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            catch (Exception exception)
            {
                this.agileLogger.Log(exception, method.Method.Name, ErrorLevel.Standard);
                if (showMessageBoxOnException)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}


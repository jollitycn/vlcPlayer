namespace CJPlus.Application
{
    using CJBasic;
    using System;
    using System.Windows.Forms;

    public class UICallbackHandler
    {
        private CallbackHandler callbackHandler_0;
        private Control control_0;

        public UICallbackHandler(Control theUI, CallbackHandler handlerOnUI)
        {
            this.control_0 = theUI;
            this.callbackHandler_0 = handlerOnUI;
        }

        public CallbackHandler Create()
        {
            return new CallbackHandler(this.method_0);
        }

        private void method_0(Exception exception_0, byte[] byte_0, object object_0)
        {
            if (this.control_0.InvokeRequired)
            {
                this.control_0.BeginInvoke(new CbGeneric<Exception, byte[], object>(this.method_0), new object[] { exception_0, byte_0, object_0 });
            }
            else
            {
                this.callbackHandler_0(exception_0, byte_0, object_0);
            }
        }
    }
}


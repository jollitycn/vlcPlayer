namespace CJPlus.Application
{
    using CJBasic;
    using System;
    using System.Windows.Forms;

    public class UIResultHandler
    {
        private Control control_0;
        private ResultHandler resultHandler_0;

        public UIResultHandler(Control theUI, ResultHandler handlerOnUI)
        {
            this.control_0 = theUI;
            this.resultHandler_0 = handlerOnUI;
        }

        public ResultHandler Create()
        {
            return new ResultHandler(this.method_0);
        }

        private void method_0(bool bool_0, object object_0)
        {
            if (this.control_0.InvokeRequired)
            {
                this.control_0.BeginInvoke(new CbGeneric<bool, object>(this.method_0), new object[] { bool_0, object_0 });
            }
            else
            {
                this.resultHandler_0(bool_0, object_0);
            }
        }
    }
}


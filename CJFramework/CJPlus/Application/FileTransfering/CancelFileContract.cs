namespace CJPlus.Application.FileTransfering
{
    using System;

    public class CancelFileContract
    {
        private bool bool_0;
        private string string_0;
        private string string_1;

        public CancelFileContract()
        {
            this.string_0 = "";
            this.bool_0 = false;
            this.string_1 = "";
        }

        public CancelFileContract(string file_ID, bool _innerError, string _cause)
        {
            this.string_0 = "";
            this.bool_0 = false;
            this.string_1 = "";
            this.string_0 = file_ID;
            this.bool_0 = _innerError;
            this.string_1 = _cause;
        }

        public string Cause
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        public bool InnerError
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public string ProjectID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}


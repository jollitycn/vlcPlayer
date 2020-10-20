namespace CJPlus.Application.FileTransfering
{
    using System;

    public class SingleFileNotifyContract
    {
        private string string_0;

        public SingleFileNotifyContract()
        {
        }

        public SingleFileNotifyContract(string _projectID)
        {
            this.string_0 = _projectID;
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


namespace CJPlus.Application.FileTransfering
{
    using CJPlus.Core;
    using System;

    public class FileMessageTypeRoom : BaseMessageTypeRoom
    {
        private int hOblcJyewd;
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int vyGlJvfPaj;

        public FileMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.hOblcJyewd = 5;
            this.vyGlJvfPaj = 6;
            this.int_6 = 7;
            base.StartKey = 300;
        }

        public FileMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.hOblcJyewd = 5;
            this.vyGlJvfPaj = 6;
            this.int_6 = 7;
            base.StartKey = _startKey;
        }

        public int BeginSendFile
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public int CancelFileReceiving
        {
            get
            {
                return this.hOblcJyewd;
            }
            set
            {
                this.hOblcJyewd = value;
            }
        }

        public int CancelFileSending
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
            }
        }

        public int ContinueTransFile
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
            }
        }

        public int FilePackageData
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public int RejectOrAcceptFile
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public int SingleFileRevFinishedNotify
        {
            get
            {
                return this.vyGlJvfPaj;
            }
            set
            {
                this.vyGlJvfPaj = value;
            }
        }
    }
}


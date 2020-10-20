namespace CJPlus.Application
{
    using System;

    public class BlobFragmentContract
    {
        private bool bool_0;
        private byte[] byte_0;
        private int int_0;
        private int int_1;
        private int int_2;

        public BlobFragmentContract()
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.byte_0 = null;
            this.int_2 = 0;
            this.bool_0 = false;
        }

        public BlobFragmentContract(int _blobID, int _informationType, int _fragmentIndex, byte[] _fragment, bool _isLast)
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.byte_0 = null;
            this.int_2 = 0;
            this.bool_0 = false;
            this.int_0 = _blobID;
            this.int_2 = _informationType;
            this.int_1 = _fragmentIndex;
            this.byte_0 = _fragment;
            this.bool_0 = _isLast;
        }

        public int BlobID
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        public byte[] Fragment
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        public int FragmentIndex
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        public int InformationType
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

        public bool IsLast
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
    }
}


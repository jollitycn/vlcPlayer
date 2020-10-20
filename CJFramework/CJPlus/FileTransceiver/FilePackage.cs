namespace CJPlus.FileTransceiver
{
    using System;

    [Serializable]
    public class FilePackage
    {
        private byte byte_0;
        private byte[] byte_1;
        private CJPlus.FileTransceiver.PackageType packageType_0;
        private string string_0;

        public FilePackage()
        {
            this.string_0 = "";
            this.byte_0 = 0;
            this.byte_1 = null;
            this.packageType_0 = CJPlus.FileTransceiver.PackageType.FileTransferingPackage;
        }

        public FilePackage(string _projectID, byte _index, byte[] _data, CJPlus.FileTransceiver.PackageType _packageType)
        {
            this.string_0 = "";
            this.byte_0 = 0;
            this.byte_1 = null;
            this.packageType_0 = CJPlus.FileTransceiver.PackageType.FileTransferingPackage;
            this.string_0 = _projectID;
            this.byte_0 = _index;
            this.byte_1 = _data;
            this.packageType_0 = _packageType;
        }

        public byte[] Data
        {
            get
            {
                return this.byte_1;
            }
            set
            {
                this.byte_1 = value;
            }
        }

        public byte Index
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

        public CJPlus.FileTransceiver.PackageType PackageType
        {
            get
            {
                return this.packageType_0;
            }
            set
            {
                this.packageType_0 = value;
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


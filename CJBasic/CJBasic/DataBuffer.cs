namespace CJBasic
{
    using System;

    [Serializable]
    public class DataBuffer
    {
        private byte[] data;
        private int length;
        private int offset;

        public DataBuffer()
        {
        }

        public DataBuffer(byte[] _data)
        {
            this.data = _data;
            this.length = this.data.Length;
            this.offset = 0;
        }

        public DataBuffer(byte[] _data, int len)
        {
            this.data = _data;
            this.length = len;
            this.offset = 0;
        }

        public DataBuffer(byte[] _data, int _offset, int len)
        {
            this.data = _data;
            this.offset = _offset;
            this.length = len;
        }

        public byte[] GetPureData()
        {
            if ((this.offset == 0) && (this.data.Length == this.length))
            {
                return this.data;
            }
            byte[] dst = new byte[this.length];
            Buffer.BlockCopy(this.data, this.offset, dst, 0, this.length);
            return dst;
        }

        public static byte[] MergeDataBuffers(params DataBuffer[] ary)
        {
            int num2;
            if ((ary == null) || (ary.Length == 0))
            {
                return null;
            }
            if (ary.Length == 1)
            {
                return ary[0].GetPureData();
            }
            int num = 0;
            for (num2 = 0; num2 < ary.Length; num2++)
            {
                num += ary[num2].Length;
            }
            byte[] dst = new byte[num];
            int dstOffset = 0;
            for (num2 = 0; num2 < ary.Length; num2++)
            {
                Buffer.BlockCopy(ary[num2].Data, ary[num2].Offset, dst, dstOffset, ary[num2].Length);
                dstOffset += ary[num2].Length;
            }
            return dst;
        }

        public byte[] Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
            set
            {
                this.offset = value;
            }
        }
    }
}


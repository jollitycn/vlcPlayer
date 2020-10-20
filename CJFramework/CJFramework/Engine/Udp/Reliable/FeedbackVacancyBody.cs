namespace CJFramework.Engine.Udp.Reliable
{
    using System;

    public class FeedbackVacancyBody : IBody
    {
        private ulong ulong_0;
        private ulong[] ulong_1;
        private ulong vuYnWdmxXs;

        public FeedbackVacancyBody()
        {
            this.ulong_1 = null;
        }

        public FeedbackVacancyBody(ulong minID, ulong maxID, ulong[] idArray)
        {
            this.ulong_1 = null;
            this.vuYnWdmxXs = minID;
            this.ulong_0 = maxID;
            this.ulong_1 = idArray;
        }

        public static FeedbackVacancyBody Parse(byte[] buff, int offset, int bodyLen)
        {
            ulong minID = BitConverter.ToUInt64(buff, offset);
            ulong maxID = BitConverter.ToUInt64(buff, offset + 8);
            int num3 = BitConverter.ToInt32(buff, offset + 0x10);
            ulong[] idArray = new ulong[num3];
            for (int i = 0; i < num3; i++)
            {
                idArray[i] = BitConverter.ToUInt64(buff, (offset + 20) + (i * 8));
            }
            return new FeedbackVacancyBody(minID, maxID, idArray);
        }

        public void ToStream(byte[] stream, int startIndex)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(this.vuYnWdmxXs), 0, stream, startIndex, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(this.ulong_0), 0, stream, startIndex + 8, 8);
            Buffer.BlockCopy(BitConverter.GetBytes(this.ulong_1.Length), 0, stream, startIndex + 0x10, 4);
            for (int i = 0; i < this.ulong_1.Length; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(this.ulong_1[i]), 0, stream, (startIndex + 20) + (8 * i), 8);
            }
        }

        public int BodyTotalLength
        {
            get
            {
                return ((((this.ulong_1.Length * 8) + 4) + 0x10) + 4);
            }
        }

        public ulong MaxIDInReceivedCache
        {
            get
            {
                return this.ulong_0;
            }
            set
            {
                this.ulong_0 = value;
            }
        }

        public ulong MinIDInReceivedCache
        {
            get
            {
                return this.vuYnWdmxXs;
            }
            set
            {
                this.vuYnWdmxXs = value;
            }
        }

        public ulong[] VacancyIDArray
        {
            get
            {
                return this.ulong_1;
            }
            set
            {
                this.ulong_1 = value;
            }
        }
    }
}


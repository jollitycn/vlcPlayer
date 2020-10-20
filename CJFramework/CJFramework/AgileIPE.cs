namespace CJFramework
{
    using System;
    using System.Net;

    [Serializable]
    public sealed class AgileIPE : IEquatable<AgileIPE>
    {
        private int int_0;
        private IPEndPoint ipendPoint_0;
        private string string_0;

        public AgileIPE()
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ipendPoint_0 = null;
        }

        public AgileIPE(IPEndPoint ipe)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ipendPoint_0 = null;
            this.String_0 = ipe.Address.ToString();
            this.Port = ipe.Port;
        }

        public AgileIPE(string addressAndPort)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ipendPoint_0 = null;
            string[] strArray = addressAndPort.Split(new char[] { ':' });
            this.String_0 = strArray[0];
            this.Port = int.Parse(strArray[1]);
        }

        public AgileIPE(string ip, int thePort)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ipendPoint_0 = null;
            this.String_0 = ip;
            this.Port = thePort;
        }

        public bool Equals(AgileIPE other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return ((this.string_0 == other.string_0) && (this.int_0 == other.int_0));
        }

        public override bool Equals(object obj)
        {
            AgileIPE other = obj as AgileIPE;
            if (other == null)
            {
                return false;
            }
            return this.Equals(other);
        }

        public static bool operator ==(AgileIPE a, AgileIPE b)
        {
            if (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
            {
                return true;
            }
            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(AgileIPE a, AgileIPE b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.string_0, this.int_0);
        }

        public IPEndPoint IPEndPoint_0
        {
            get
            {
                if (this.ipendPoint_0 == null)
                {
                    this.ipendPoint_0 = new IPEndPoint(IPAddress.Parse(this.string_0), this.int_0);
                }
                return this.ipendPoint_0;
            }
        }

        public int Port
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

        public string String_0
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                if (this.string_0 != null)
                {
                    this.string_0 = this.string_0.Trim();
                }
            }
        }
    }
}


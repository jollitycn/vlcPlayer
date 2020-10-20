namespace CJBasic.Collections
{
    using System;

    public class KeyScope
    {
        private int max;
        private int min;

        public KeyScope()
        {
            this.max = -2147483648;
            this.min = 0x7fffffff;
        }

        public KeyScope(string scopeStr)
        {
            this.max = -2147483648;
            this.min = 0x7fffffff;
            this.SetScopeStr(scopeStr);
        }

        public KeyScope(int theMin, int theMax)
        {
            this.max = -2147483648;
            this.min = 0x7fffffff;
            this.min = theMin;
            this.max = theMax;
        }

        public bool Contains(int val)
        {
            return ((this.min <= val) && (val <= this.max));
        }

        public bool Intersect(KeyScope scope)
        {
            for (int i = this.min; i < this.max; i++)
            {
                if (scope.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }

        private void SetScopeStr(string str)
        {
            string[] strArray = str.Split(new char[] { ',' });
            this.min = int.Parse(strArray[0].Trim());
            this.max = int.Parse(strArray[1].Trim());
        }

        public override string ToString()
        {
            return this.ScopeString;
        }

        public int Max
        {
            get
            {
                return this.max;
            }
            set
            {
                this.max = value;
            }
        }

        public int Min
        {
            get
            {
                return this.min;
            }
            set
            {
                this.min = value;
            }
        }

        public string ScopeString
        {
            get
            {
                return string.Format("{0},{1}", this.min, this.max);
            }
            set
            {
                this.SetScopeStr(value);
            }
        }
    }
}


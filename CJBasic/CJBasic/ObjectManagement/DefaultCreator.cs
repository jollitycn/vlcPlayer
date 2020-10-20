namespace CJBasic.ObjectManagement
{
    using System;
    using System.Threading;

    public class DefaultCreator : ICreator<int>
    {
        private int id;

        public DefaultCreator()
        {
            this.id = 0;
        }

        public DefaultCreator(int curMaxID)
        {
            this.id = 0;
            this.id = curMaxID;
        }

        public int Create()
        {
            Interlocked.Increment(ref this.id);
            return this.id;
        }
    }
}


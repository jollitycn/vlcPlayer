namespace CJBasic.Threading.Synchronize
{
    using System;
    using System.Threading;

    public class SmartRWLocker
    {
        private DateTime lastRequireReadTime = DateTime.Now;
        private DateTime lastRequireWriteTime = DateTime.Now;
        private ReaderWriterLock readerWriterLock = new ReaderWriterLock();

        public LockingObject Lock(AccessMode accessMode)
        {
            if (accessMode == AccessMode.Read)
            {
                this.lastRequireReadTime = DateTime.Now;
            }
            else
            {
                this.lastRequireWriteTime = DateTime.Now;
            }
            return new LockingObject(this.readerWriterLock, accessMode);
        }

        public LockingObject Lock(AccessMode accessMode, bool enableSynchronize)
        {
            if (!enableSynchronize)
            {
                return null;
            }
            return this.Lock(accessMode);
        }

        public DateTime LastRequireReadTime
        {
            get
            {
                return this.lastRequireReadTime;
            }
        }

        public DateTime LastRequireWriteTime
        {
            get
            {
                return this.lastRequireWriteTime;
            }
        }
    }
}


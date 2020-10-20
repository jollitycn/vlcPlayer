namespace CJBasic.Threading.Synchronize
{
    using System;
    using System.Threading;

    public class LockingObject : IDisposable
    {
        private AccessMode accessMode = AccessMode.Read;
        private LockCookie lockCookie;
        private ReaderWriterLock readerWriterLock;

        public LockingObject(ReaderWriterLock _lock, AccessMode _lockMode)
        {
            this.readerWriterLock = _lock;
            this.accessMode = _lockMode;
            if (this.accessMode == AccessMode.Read)
            {
                this.readerWriterLock.AcquireReaderLock(-1);
            }
            else if (this.accessMode == AccessMode.Write)
            {
                this.readerWriterLock.AcquireWriterLock(-1);
            }
            else
            {
                this.lockCookie = this.readerWriterLock.UpgradeToWriterLock(-1);
            }
        }

        public void Dispose()
        {
            if (this.accessMode == AccessMode.Read)
            {
                this.readerWriterLock.ReleaseReaderLock();
            }
            else if (this.accessMode == AccessMode.Write)
            {
                this.readerWriterLock.ReleaseWriterLock();
            }
            else
            {
                this.readerWriterLock.DowngradeFromWriterLock(ref this.lockCookie);
            }
        }
    }
}


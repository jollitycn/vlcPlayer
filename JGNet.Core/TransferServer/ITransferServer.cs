using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.TransferServer
{
    public interface ITransferServer
    {
        ITransferServer4Server TransferServer4Server { get; }
    }
}

using JGNet.Core.InteractEntity;
using JGNet.Core.TransferServer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.TransferServer
{
    public interface ITransferServer4Server
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceBusinessAccountId"></param>
        /// <param name="destBusinessAccountId"></param>
        /// <param name="supplierID"></param>
        /// <param name="sourceBrandDict"></param>
        /// <param name="sourceCostumeColorDict">name_ID</param>
        /// <param name="transferCostumes"></param>
        /// <returns></returns>
        InteractResult Transfer(string sourceBusinessAccountId, string destBusinessAccountId, string supplierID, Dictionary<int, string> sourceBrandDict, Dictionary<string, string> sourceCostumeColorDict,
            List<TransferCostume> transferCostumes);
    }
}

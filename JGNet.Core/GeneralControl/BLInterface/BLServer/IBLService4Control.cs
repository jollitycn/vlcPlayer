using JGNet.Core.AiDeployer;
using JGNet.Core.GeneralControl.InteractEntity;
using JGNet.Core.InteractEntity;
using DataRabbit;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.BLInterface
{
    public interface IBLService4Control
    {
        GeneralUser GetGeneralUser(string id);

        BusinessAccount[] GetBusinessAccountPage(GetBusinessAccountPagePara para, out int entityCount);

        InsertResult InsertBusinessAccount(BusinessAccount businessAccount);

        AiDeployerRegisterInfo GetRegisters();

        List<GeneralConfig> GetAllGeneralConfig();

        BusinessAccount GetOneBusinessAccount(string id);
        
        UpdateResult UpdateBusinessAccount(BusinessAccount businessAccount);

        WxShopMan[] GetWxShopManPage(WxShopMan wxShopMan, int pageSize, int pageIndex, out int entityCount);

        InsertResult InsertPaymentRecord(PaymentRecord paymentRecord);

        UpdateResult UpdatePaymentRecord(PaymentRecord paymentRecord);

        PaymentRecord[] GetPaymentRecordPage(PaymentRecord paymentRecord, int pageSize, int pageIndex, out int entityCount);

        List<int> GetBusinessAccountPorts4ServerIP(string id, string serverIP);

        InteractResult StartDeploy(BusinessAccount businessAccount);

        SysErrorRecord[] GetSysErrorRecordPage(BusinessAccount businessAccount, int pageSize, int pageIndex, out int entityCount);

        InsertResult UpdateGeneralConfig(GeneralConfig generalConfig);

        List<BusinessAccount> GetAllBusinessAccount();

        InteractResult InsertAnnounce(Announce announce);

        InteractResult FinishAnnounce(int id);

        InteractResult CancelAnnounce(int id);

        Announce[] GetAnnouncePage(int pageSize, int pageIndex, out int entityCount);

        InteractResult ResetAdminUserPwd(string businessAccountId, string userID, string pwd);

        InteractResult DeleteBusinessAccount(BusinessAccount businessAccount);

        InteractResult DeleteBusinessAccount(string id);
    }
}

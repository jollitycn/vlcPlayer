using System;
using System.Collections.Generic;

using System.Text;
using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.MyEnum;

namespace JGNet.Core.Dev.BLInterface.Web
{
    public interface IBLService4Server
    {
        EMall GetOneEMallWithoutBlob(string businessAccountID);

        byte[] GetEMallLogo(string businessAccountID);

        UpdateResult UpdateEMallWithoutBlob(EMall eMall);

        UpdateResult UpdateEMallLogo(UpdateEMallLogoPara para);

        void InsertSysErrorRecord(SysErrorRecord sysErrorRecord);

        CosLoginInfo GetCosLoginInfo(bool isReadonly);

        UpdateResult UpdateEMallPosterImage(string businessAccountID, string source_url);

        string GetEMallPosterImage(string businessAccountID);

        DeleteResult DeletePosterImageToCos(DeletePosterImagePara para);

        BusinessAccount GetOneBusinessAccount(string businessAccountID);

        Dictionary<string, WxMember> GetWxMemberDict(List<string> memeberIDs);
        
        WxMemberAddress GetWxMemberAddress(int wxMemberAddressID);

        WxMemberAddress GetDefaultAddress(string wxOpenID);

        EMall GetOneEMallHaveLogo(string businessAccountID);

        WxMember GetWxMember(string wxOpenID);

        WxMember GetWxMemberByMemberID(string memberID);

        UpdateResult UpdateEMall(EMall eMall);

        int GetShopCount(string businessAccountID);

        UpdateResult UpdateEMallMiniProgramImg(UpdateEMallPhotoPara para);

        byte[] GetEMallMiniProgramImg(string businessAccountID);

        void DeleteWxShopMan(string businessAccountID, string userID);
        
        WebResponseObj<Dictionary<AnnounceType, Announce>> GetAnnounceDict();
    }
}

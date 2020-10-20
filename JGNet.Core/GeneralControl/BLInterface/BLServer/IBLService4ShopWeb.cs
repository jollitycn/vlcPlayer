using System;
using System.Collections.Generic;

using System.Text;

using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;

namespace JGNet.Core.Dev.BLInterface.Web
{
    public interface IBLService4ShopWeb
    {
        InteractResult UpdateWxMember(string businessAccountID, string wxOpenID, string phoneNumber, string name, string wxNickName, string wxHeadImageUrl);

        WebResponseObj<WxMember> Login(string wxOpenID, string businessAccountID);

        string AddWxMemberAddress(string wxOpenID, string name, string telphone1, string telphone2, string cityZone, string detailAddress, int isDefaultAddress);

        /// <summary>
        /// 获取零售客户默认收货地址ID
        /// </summary>
        /// <param name="wxOpenID"></param>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        int GetMemberDefaultAddressId(string wxOpenID, string businessAccountID);

        /// <summary>
        /// 获取零售客户默认收货地址 （返回整合的DeliveryAddress 对象）
        /// </summary>
        /// <param name="wxOpenID"></param>
        /// <returns></returns>
        string GetWxMemberDefaultAddress(string wxOpenID);

        string GetWxMemberAddress(string wxOpenID);

        /// <summary>
        /// 获取零售客户收货地址列表  （返回整合的List<DeliveryAddress> 集合）
        /// </summary>
        /// <param name="wxOpenID"></param>
        /// <returns></returns>
        string GetWxMemberAddressList(string wxOpenID);

        string DeleteWxMemberAddress(string id);

        string UpdateWxMemberAddress(string id, string name, string telphone1, string telphone2, string cityZone, string detailAddress,int isDefaultAddress, string wxOpenID);

        string GetSignature();

        string GetCosLoginInfo();

        LoadServerInfo GetLoadServerInfo4BusinessAccountId(string businessAccountId);

        WxMember GetWxMember(string wxOpenID);

        string UpdateWxMemberDefaultAddress(string wxOpenID, int defaultAddressID);

        string UploadWxHeadImage(string wxOpenID, string wxHeadImageUrl);

        string GetWxHeadImage(string wxOpenID);

        void DeleteWxMember(string wxOpenID);

        /// <summary>
        /// 获取商城信息（不带logo）
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        string GetOneEMallWithoutBlob(string businessAccountID);

        /// <summary>
        /// 获取商城Logo
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        string GetEMallLogo(string businessAccountID);

        /// <summary>
        /// 获取商套信息
        /// </summary>
        /// <param name="businessAccountID"></param>
        /// <returns></returns>
        BusinessAccount GetBusinessAccount(string businessAccountID);
        
    }
}

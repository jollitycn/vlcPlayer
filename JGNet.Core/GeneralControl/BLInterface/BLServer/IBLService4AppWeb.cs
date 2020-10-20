using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.BLInterface
{
    public interface IBLService4AppWeb
    {
        /// <summary>
        /// 获取所有商户帐套列表
        /// </summary>
        /// <returns></returns>
        List<BusinessAccount> GetAllBusinessAccount();

        /// <summary>
        /// 根据帐套ID获取该帐套实体
        /// </summary>
        /// <param name="businessAccountID">帐套ID</param>
        /// <returns></returns>
        BusinessAccount GetBusinessAccount(string businessAccountID);

        string ResetAdminUserPwd(string phone, string pwd);

        string GetRenewalInfo(string businessAccountID);

        string GetVersionUpdateRecordPage(int pageSize, int pageIndex);

        /// <summary>
        /// 根据微信OpenID获取该店员微信帐号绑定信息
        /// </summary>
        /// <param name="wxOpenID">openID</param>
        /// <returns></returns>
        WxShopMan GetWxShopMan(string wxOpenID);

        /// <summary>
        /// 新增店员微信帐号
        /// </summary>
        /// <param name="wxShopMan">店员微信帐号对象</param>
        void InsertWxShopMan(WxShopMan wxShopMan);

        string GetTrialTime();

        /// <summary>
        /// 更新店员微信帐号
        /// </summary>
        /// <param name="wxShopMan">店员微信帐号对象</param>
        void UpdateWxShopMan(WxShopMan wxShopMan);

        /// <summary>
        /// 更新店员微信帐号最后登录时间
        /// </summary>
        /// <param name="openID">WxOpenID</param>
        void UpdateWxShopManLastLoginTime(string openID);

        /// <summary>
        /// 删除店员微信帐号
        /// </summary>
        /// <param name="wxOpenID">openID</param>
        void DeleteWxShopMan(string wxOpenID);

        string ApplicationTrial(string phone, string companyName, string provinceCity, string name, string pwd);
    }
}

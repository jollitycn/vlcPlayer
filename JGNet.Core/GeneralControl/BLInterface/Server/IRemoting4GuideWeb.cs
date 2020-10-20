using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.RemotingEntity;
using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.BLInterface
{
    public interface IRemoting4GuideWeb
    {

        /// <summary>
        /// 是否只显示本店会员
        /// </summary>
        /// <returns></returns>
        bool IsSeeOwnShopMember();

        /// <summary>
        /// 根据导购帐号获取店铺ID
        /// </summary>
        /// <param name="guideID">导购帐号</param>
        /// <returns>shopID</returns>
        string GetShopIDByGuideID(string guideID);

        /// <summary>
        /// 获取店铺实体
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        Shop GetOneShop(string shopID);

        /// <summary>
        /// 获取导购对象
        /// </summary>
        /// <param name="guideID">导购ID</param>
        /// <returns></returns>
        Guide GetOneGuide(string guideID);


        UpdateResult UpdateGuidePwd(string guideID, string password);

        /// <summary>
        /// 获取一段时间导购日业绩
        /// </summary>
        /// <param name="shopID">店铺ID</param>
        /// <param name="guideID">导购ID</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        List<GuideDayAchievement> GetGuideDayAchievements(string shopID, string guideID, DateTime startDate, DateTime endDate);
        

        /// <summary>
        /// 获取导购员月业绩
        /// </summary>
        /// <param name="month">如 201808 固定六位数</param>
        /// <returns></returns>
        GuideMonthAchievement GetGuideMonthAchievement(string shopID, string guideID, int month);

        /// <summary>
        /// 获取某月的新增会员列表 
        /// </summary>
        /// <param name="shopID">店铺ID</param>
        /// <param name="guideID">导购ID</param>
        /// <param name="month">如 201808 固定六位数</param>
        /// <returns>店铺ID为空，返回所有店数据；导购ID为空返回所有导购数据</returns>
        List<Member> GetNewMemberByMonth(string shopID, string guideID, int month);

        /// <summary>
        /// 根据会员卡号或姓名获取会员对象
        /// </summary>
        /// <param name="idorName">手机号或姓名</param>
        /// <returns></returns>
        MemberListPage GetMemberByIDOrName(int pageIndex,int pageSize, string idorName,string shopID, bool onlyShowOwnShop);

        /// <summary>
        /// 根据导购编号获取会员集合分页
        /// </summary>
        /// <param name="guideID">导购编号</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页多少条数据</param>
        /// <returns></returns>
        MemberListPage GetMemberByGuideID(string guideID, int pageIndex, int pageSize, string shopID);

        /// <summary>
        /// 根据会员卡号获取会员对象
        /// </summary>
        /// <param name="memberID">手机号（会员卡号）</param>
        /// <returns></returns>
        Member GetOneMember(string memberID);

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        InteractResult RegisteredMember(Member member);

        /// <summary>
        /// 获取本店库存
        /// </summary>
        /// <param name="shopID">店铺ID</param>
        /// <param name="costumeID">款号</param>
        /// <returns></returns>
        CostumeItem GetCostumeStoreInShopID(string shopID,string costumeID);

        Dictionary<string, CostumeStore> GetOneShopAllCostumeColorStore(string shopID, string costumeID, bool isRefund);

        /// <summary>
        /// 获取某月导购业绩排行(按销售额倒序排序)
        /// </summary>
        /// <param name="month">月份 （固定6位数 如201804）</param>
        /// <returns></returns>
        List<GuideMonthAchievement> GetGuideMonthAchievementRanking(string shopID, int month);

        DayBenefitReport GetOneShopDayBenefitReport(DateTime startTime, DateTime endTime, string shopID);


        /// <summary>
        /// 修改导购员短信签名
        /// </summary>
        /// <param name="guideID"></param>
        /// <param name="smsSignature"></param>
        /// <returns></returns>
        UpdateResult UpdateGuideSmsSignature(string guideID, string smsSignature);

        /// <summary>
        /// 获取导购员短信签名
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        string GetGuideSmsSignature(string guideID);

        /// <summary>
        /// 修改短信签名
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="smsSignature"></param>
        /// <returns></returns>
        InteractResult UpdateSmsSignature(UserType userType, string userID, string smsSignature);

        /// <summary>
        /// 获取短信签名
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        string GetSmsSignature(UserType userType, string userID);

        /// <summary>
        /// 新增导购备忘
        /// </summary>
        /// <param name="guideID"></param>
        /// <param name="memoContent"></param>
        /// <returns></returns>
        InsertResultAndAutoID InsertGuideMemo(string guideID, string memoContent);

        /// <summary>
        /// 上传导购备忘图片或语音
        /// </summary>
        /// <param name="guideMemoID"></param>
        /// <param name="datas"></param>
        /// <param name="type">0：语音，1，2，3（图片位置）</param>
        /// <returns></returns>
        UpdateResult UploadGuideMemoDatas(string guideMemoID, byte[] datas, DatasType type);

        /// <summary>
        /// 导购备忘完成
        /// </summary>
        /// <param name="guideMemoID"></param>
        /// <returns></returns>
        UpdateResult ClosedGuideMemo(string guideMemoID);

        /// <summary>
        /// 获取 导购备忘分页信息。
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        GuideMemoPage GetGuideMemoPage(GuideMemoPagePara para);

        /// <summary>
        /// 获取 导购备忘 语音或者图片信息
        /// </summary>
        /// <param name="guideMemoID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        byte[] GetGuideMemoDatas(string guideMemoID, DatasType type);

        /// <summary>
        /// 新增回访备忘
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="memberName"></param>
        /// <param name="retailOrderID"></param>
        /// <param name="followType"></param>
        /// <param name="followDate"></param>
        /// <param name="followContent"></param>
        /// <param name="guideID"></param>
        /// <param name="isClosed"></param>
        /// <returns></returns>
        InsertResultAndAutoID InsertReturnVisitMemo(ReturnVisitMemo returnVisitMemo);
        
        /// <summary>
        /// 回访备忘完成
        /// </summary>
        /// <param name="returnVisitMemoID"></param>
        /// <returns></returns>
        UpdateResult ClosedReturnVisitMemo(string returnVisitMemoID);

        /// <summary>
        /// 获取跟进备忘
        /// </summary>
        /// <param name="returnVisitMemoID">备忘ID</param>
        /// <returns></returns>
        ReturnVisitMemo GetReturnVisitMemo(int returnVisitMemoID);

        /// <summary>
        /// 获取 回访备忘分页信息。
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        ReturnVisitMemoPage GetReturnVisitMemoPage(ReturnVisitMemoPagePara para);
        
        /// <summary>
        /// 新增 回访记录
        /// </summary>
        /// <param name="returnVisitRecord"></param>
        /// <returns></returns>
        InsertResult InsertReturnVisitRecord(ReturnVisitRecord returnVisitRecord);

        /// <summary>
        /// 获取导购员回访推送
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        ReturnVisitInfo GetReturnVisitInfo(string guideID,string shopID);

        /// <summary>
        /// 获取销售回访分页信息
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        RetailReturnVisitInfoPage GetRetailReturnVisitInfoPage(RetailReturnVisitInfoPagePara para);

        /// <summary>
        /// 根据主题获取短信模板列表
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        List<ShortMessageTemplate> GetShortMessageTemplates(string subject);

        /// <summary>
        /// 根据导购ID和主题获取 导购收藏的短信模版列表
        /// </summary>
        /// <param name="gudieID"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        List<GuideFavoriteSmsTemplate> GetGuideFavoriteSmsTemplates(string gudieID,string subject);

        /// <summary>
        /// 导购员收藏短信模板
        /// </summary>
        /// <param name="guideID"></param>
        /// <param name="shortMessageTemplateID"></param>
        /// <returns></returns>
        InsertResult InsertGuideFavoriteSmsTemplate(string guideID, int shortMessageTemplateID);

        /// <summary>
        /// 添加短信模板
        /// </summary>
        /// <param name="guideFavoriteSmsTemplate"></param>
        /// <returns></returns>
        InsertResult InsertGuideFavoriteSmsTemplate(GuideFavoriteSmsTemplate guideFavoriteSmsTemplate);

        /// <summary>
        /// 修改短信模板
        /// </summary>
        /// <param name="guideFavoriteSmsTemplate"></param>
        /// <returns></returns>
        UpdateResult UpdateGuideFavoriteSmsTemplate(GuideFavoriteSmsTemplate guideFavoriteSmsTemplate);

        /// <summary>
        /// 删除短信模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DeleteResult DeleteGuideFavoriteSmsTemplate(int id);

        /// <summary>
        /// 获取生日祝福回访分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        BirthdayReturnVisitInfoPage GetBirthdayReturnVisitInfoPage(BirthdayReturnVisitInfoPagePara para);

        /// <summary>
        /// 获取休眠激活回访分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        ActiveReturnVisitInfoPage GetActiveReturnVisitInfoPage(ActiveReturnVisitInfoPagePara para);

        /// <summary>
        /// 获取回访记录分页信息
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        ReturnVisitRecordPage GetReturnVisitRecordPage(string shopID, string guideID, string subject,string visitType ,DateTime startDate,DateTime endDate,int pageIndex,int pageSize);

        /// <summary>
        /// 获取指定店铺某段时间内的回访分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        List<ReturnVisitAnalysis> GetReturnVisitAnalysiss(string shopID, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取指定店铺导购员的回访分析
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        List<ReturnVisitAnalysis4Guide> GetReturnVisitAnalysiss4Guide(string shopID, DateTime startDate, DateTime endDate, bool isNeedAddDay);

        /// <summary>
        /// 获取指定店铺某段时间内的回访分析汇总
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        ReturnVisitAnalysis GetReturnVisitAnalysissSummary(string shopID, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取某段时间内的回访分析汇总  (shopID:""时，返回所有店铺的汇总)
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<ReturnVisitAnalysis> GetReturnVisitAnalysissSummarys4Shop(string shopID, DateTime startDate, DateTime endDate);

        double GetReturnVisitCompletionRate(string shopID, DateTime startDate, DateTime endDate);

        #region 进销存
        /// <summary>
        /// 进销存简报 （用于导购小程序显示）  数据来自日报表
        /// </summary>
        /// <param name="shopID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<InventoryDayReport4GuideSmallProgram> GetInventoryDayReport4GuideSmallProgramList(string shopID, DateTime startDate, DateTime endDate);

        string GetCostumeStoreChange4In(string shopID, int dateInt);

        string GetCostumeStoreChange4Into(string shopID, int dateInt);

        string GetCostumeStoreChange4Return(string shopID, int dateInt);

        string GetCostumeStoreChange4TurnOut(string shopID, int dateInt);

        string GetCostumeStoreChange4Retail(string shopID, int dateInt);

        string GetCostumeStoreChange4Scrap(string shopID, int dateInt);

        string GetCostumeStoreChange4Profit(string shopID, int dateInt);
        #endregion

        #region 销售
        /// <summary>
        /// 获取某店铺某款衣服的销售价格
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        CostumePrice GetCostumeStorePrice(string shopId, string costumeID);

        /// <summary>
        /// 销售
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <returns></returns>
        InteractResult RetailCostume(RetailCostume retailCostume);

        /// <summary>
        /// 获取销售单打印信息 
        /// </summary>
        /// <param name="orderId">销售单号</param>
        /// <returns></returns>
        RetailPrintInfo GetRetailPrintInfo(string orderId);

        /// <summary>
        /// 收银时是否四舍五入
        /// </summary>
        /// <returns></returns>
        bool IsRetailBalanceRound();

        /// <summary>
        /// 销售、出库是否允许负数库存
        /// </summary>
        /// <returns></returns>
        bool IsLimitCostumeStore();

        #endregion
        /// <summary>
        /// 退货
        /// </summary>
        /// <param name="refundCostume"></param>
        /// <returns></returns>
        InteractResult RefundCostume(RefundCostume refundCostume);
    }
}

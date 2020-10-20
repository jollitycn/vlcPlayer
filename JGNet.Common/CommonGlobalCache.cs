using CCWin;
using JGNet.Core;
using JGNet.Core.Const;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools; 
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public class CommonGlobalCache
    {
        public static void UpdateSizeGroup(SizeGroup item)
        {
            SizeGroup b = sizeGroupList?.Find(t => t.SizeGroupName == item.SizeGroupName);
            if (b != null)
            {
                sizeGroupList?.Remove(b);
            }
            sizeGroupList?.Add(item);
        }

        public static InteractResult SupplierList_OnChange(Supplier item)
        {
            InteractResult result = CommonGlobalCache.ServerProxy.InsertSupplier(item);
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    CommonGlobalCache.supplierList = CommonGlobalCache.ServerProxy.GetSupplierList();
                    CommonGlobalCache.supplierList?.Sort();
                    break;
                case ExeResult.Error:
                    break;
                default:
                    break;
            }
            return result;
        }

        public static void DeleteSizeGroup(string sizeGroupName)
        {
            SizeGroup b = sizeGroupList.Find(t => t.SizeGroupName == sizeGroupName);
            if (b != null)
            {
                sizeGroupList.Remove(b);
            }
        }

        public static void InsertSizeGroup(SizeGroup item)
        {
            if (sizeGroupList == null)
            {
                sizeGroupList = new List<SizeGroup>();
            }

            if (!sizeGroupList.Exists(t => t.SizeGroupName == item.SizeGroupName))
            {
                sizeGroupList.Add(item);
            }
        }
        public static List<TreeNode> Permissons { get; protected set; }
        public static List<String> GetShowSizeNames()
        {
            List<String> sizeNameList = new List<string>();
            String sizeName = CommonGlobalCache.GetParameter(ParameterConfigKey.ShowSizeName).ParaValue;

            if (!String.IsNullOrEmpty(sizeName))
            {
                String[] strs = sizeName.Split(',');
                sizeNameList = new List<string>(strs);
            }
            return sizeNameList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="costumeID">商品款号</param>
        /// <param name="sizeGroups">对应款号下的尺码组</param>
        /// <param name="allsizeName">对应商品款号的所有尺码</param>
        /// <returns></returns>
        private static List<String> GetsizeNames(String costumeID, List<SizeGroup> sizeGroups, List<String> allsizeName)
        {
            Costume costume = CommonGlobalCache.GetCostume(costumeID);
            if (costume != null)
            {
                SizeGroup group = CommonGlobalCache.GetSizeGroup(costume.SizeGroupName);
                if (!sizeGroups.Contains(group))
                {
                    sizeGroups.Add(group);
                }
                List<String> sizeNames = costume.SizeNameList;
                if (sizeNames != null)
                {
                    foreach (String s in sizeNames)
                    {
                        if (!allsizeName.Contains(s))
                        {
                            allsizeName.Add(s);
                        }
                    }
                }
            }
            return allsizeName;
        }

        protected static  ServerProxy eMallServerProxy;
        public static  ServerProxy EMallServerProxy
        {
            get
            {
                return (ServerProxy)eMallServerProxy;
            }
        }
        /// <summary>
        ///根据款号获取尺码
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static List<String> GetShowSizeNames(DataGridView view, out List<String> displayNames)
        {
            List<SizeGroup> sizeGroups = new List<SizeGroup>();

            List<String> allsizeName = new List<string>();

            displayNames = new List<string>();
            if (view.DataSource is DataTable)
            {

                DataTable dt = view.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        String costumeID = item["CostumeID"].ToString();
                         GetsizeNames(costumeID, sizeGroups, allsizeName);
                    }
                }
            }
            else
            {
                System.Collections.IEnumerable list = view.DataSource as System.Collections.IEnumerable;
                if (list != null)
                {
                    foreach (object obj in list)
                    {
                        if (obj != null)
                        {
                            string costumeID = CJBasic.Helpers.ReflectionHelper.GetProperty(obj, "CostumeID").ToString();
                            GetsizeNames(costumeID, sizeGroups, allsizeName);
                        }
                    }
                }


            }

            foreach (var item in allsizeName)
            {
                String sizeName = string.Empty;
                int size = 0;
                foreach (var group in sizeGroups)
                {
                    sizeName += CostumeStoreHelper.GetCostumeSizeName(item, group) + SystemDefault.DEFAULT_STRING_BREAKING;
                    size += 20;
                }

                view.ColumnHeadersHeight = size;
                sizeName = sizeName.Substring(0, sizeName.LastIndexOf(SystemDefault.DEFAULT_STRING_BREAKING));
                displayNames.Add(sizeName);
            }
            return allsizeName;
        }


        /// <summary>
        /// 系统更新通知信息
        /// </summary>
        public static String SystemUpdateMessage { get; set; }

        public static void LoadCostumeInfo(String costumeID)
        {
            // CostumeDictionary?.Clear();
            //costumeList?.Clear();
            CostumeListPagePara pagePara = new CostumeListPagePara()
            { CostumeID = costumeID,
                PageIndex = 0,
                PageSize = 1,
                Year = -1,
                BrandID = -1,
                IsQueryValid = IsQueryValid.All
            };

            CostumeListPage listPage = ServerProxy.GetCostumeListPage(pagePara);
            if (listPage != null)
            {
                if (listPage.CostumeList != null)
                {
                    foreach (Costume costume in listPage.CostumeList)
                    {
                        if (costume.ID == costumeID)
                        {
                            Costume costumeOrg = costumeList.Find(t => t.ID == costumeID);
                            if (costumeOrg != null)
                            {
                                costumeList.Remove(costumeOrg);
                            }
                            costumeList.Add(costume);
                            break;
                        }
                    }
                }
            }
        }

        public static void LoadCostumeInfos(int total = 0, bool showProgress = false)
        {
            List<Costume> costumes = new List<Costume>();
            CostumeListPagePara pagePara = new CostumeListPagePara()
            {
                PageIndex = 0,
                PageSize = 50,
                Year = -1,
                BrandID = -1,
                Property = JGNet.Core.MyEnum.CostumeProperty.All,
                IsQueryValid = IsQueryValid.All
            };
            CostumeListPage listPage = ServerProxy.GetCostumeListPage(pagePara);
            if (listPage != null)
            {
                if (listPage.CostumeList != null)
                {
                    foreach (Costume costume in listPage.CostumeList)
                    {
                        costumes.Add(costume);
                    }
                }
                int pageCount = (int)Math.Ceiling((double)listPage.TotalEntityCount / pagePara.PageSize);
                for (int i = 1; i < pageCount; i++)
                {
                    if (showProgress)
                    {
                        CommonGlobalCache.updateProgress(string.Format("服装信息-{0}/{1}", i + 1, pageCount));
                    }
                    pagePara.PageIndex = i;
                    listPage = ServerProxy.GetCostumeListPage(pagePara);
                    if (listPage != null && listPage.CostumeList != null)
                    {
                        foreach (Costume costume in listPage.CostumeList)
                        {
                            costumes.Add(costume);
                        }
                    }
                }
            }
            costumeList = costumes;
        }

        public static string GetCorrectCostumeID(string costumeID)
        {
            if (String.IsNullOrEmpty(costumeID))
            {
                return costumeID;
            }
            Costume costume = costumeList?.Find(t => t.ID.ToUpper() == costumeID.ToUpper());
            if (costume != null)
            {
                return costume.ID;
            }
            return costumeID;
        }

        public static void UpdateSizeNames(UpdateSizeNamesInfo sizeNameInfo)
        {
            foreach (var item in sizeNameInfo.SizeNamesDict)
            {
                Costume costume = costumeList?.Find(t => t.ID == item.Key);
                if (costume != null)
                {
                    costume.SizeNames = item.Value.ToString();
                }

            }
        }

        public static void SetDefaultSizeGroupName(string paraValue)
        {
            defaultSizeGroupName = paraValue;
        }

        protected static String defaultSizeGroupName;

        public static String DefaultSizeGroupName { get { return defaultSizeGroupName; } }

        public static SizeGroup GetSizeGroup(String sizeGroupName) {

            SizeGroup sizeGroup =   SizeGroupList?.Find(t => t.SizeGroupName == sizeGroupName);
            if (sizeGroup == null) {
                sizeGroup = DefaultSizeGroup;
            }
            return sizeGroup;
        }


        public static SizeGroup DefaultSizeGroup{ get { return SizeGroupList?.Find(t => t.SizeGroupName == defaultSizeGroupName); } }

        protected static CostumeGiftTicketInfo costumeGiftTicketInfo;

        public static CostumeGiftTicketInfo CostumeGiftTicketInfo { get { return costumeGiftTicketInfo; } }

        public static RechargeDonateRule RechargeDonateRule { get; set; }
        protected static ServerProxy serverProxy;
        public static ServerProxy ServerProxy { get { return serverProxy; } }
        /// <summary>
        /// 加载缓存进度。参数：总任务数 - 已完成任务数 - 任务名称
        /// </summary>
        protected static CJBasic.CbGeneric<int,  string > iniProgress;
        public static event CJBasic.CbGeneric<int,  string> IniProgress
        {
            add { iniProgress += value; }
            remove { iniProgress -= value; }
        }

        protected static CJBasic.CbGeneric< string> updateProgress;
        public static event CJBasic.CbGeneric<string> UpdateProgress
        {
            add { updateProgress += value; }
            remove { updateProgress -= value; }
        }
        /// <summary>
        /// 加载缓存完成。
        /// </summary>
        /// 
        protected static CJBasic.CbGeneric iniCompleted;
        public static event CJBasic.CbGeneric IniCompleted
        {
            add { iniCompleted += value; }
            remove { iniCompleted -= value; }
        }

        /// <summary>
        /// 加载缓存过程中出现错误。参数：错误信息
        /// </summary>
        protected static CJBasic.CbGeneric<Exception> iniFailed;
        public static event CJBasic.CbGeneric<Exception> IniFailed
        {
            add
            {
                iniFailed += value;
            }
            remove
            {
                iniFailed -= value;
            }
        }


        //public static void InsertBarCode(BarCode barCode)
        //{
        //    if (barCodeList == null)
        //    {
        //        barCodeList = new List<BarCode>();
        //        barCodeList.Add(barCode);
        //    }
        //    else
        //    {
        //        BarCode found = barCodeList.Find(t => t.CostumeID.ToUpper() == barCode.CostumeID.ToUpper() && t.ColorName == barCode.ColorName && t.SizeName == barCode.SizeName);
        //        if (found != null)
        //        {
        //            barCodeList.Remove(found);
        //        }

        //        barCodeList.Add(barCode);
        //    }
        //}

        //public static void UpdateBarCode(BarCode barCode)
        //{

        //    BarCode found = barCodeList?.Find(t => t.CostumeID.ToUpper() == barCode.CostumeID.ToUpper() && t.ColorName == barCode.ColorName && t.SizeName == barCode.SizeName);
        //    if (found != null)
        //    {
        //        barCodeList.Remove(found);
        //    }

        //    barCodeList.Add(barCode);
        //}

        public static void UpdateShopRechargeRuleID(RechargeDonateRule rechargeDonateRule)
        {
            Shop shop = CommonGlobalCache.CurrentShop;
            shop.RechargeRuleID = rechargeDonateRule.AutoID;
            CommonGlobalCache.RechargeDonateRule = rechargeDonateRule;
        }

        public static void UpdateRechargeDonateRule(RechargeDonateRule rechargeDonateRule)
        {
            rechargeDonateRule.ClearRules();
            CommonGlobalCache.RechargeDonateRule = rechargeDonateRule;
        }

        //public static void OnCostumeClassListChange(List<CostumeClass> list)
        //{
        //    CommonGlobalCache.costumeClassList = list;
        //}

        public static void EnabledSizeGroup(EnabledSizeGroupPara para)
        {
            SizeGroup found = sizeGroupList.Find(t => t.SizeGroupName == para.SizeGroupName);
            if (found != null)
            {
                found.Enabled = para.Enabled;
            }
        }

        protected static string generalStoreShopID;
        public static string GeneralStoreShopID { get { return CommonGlobalCache.generalStoreShopID; } }
        public static Shop GeneralStoreShop
        {
            get { return GetShop(CommonGlobalCache.generalStoreShopID); }
        }

        public static void CostumeList_OnChange(Costume item)
        {
            if (CommonGlobalCache.costumeList == null)
            {
                CommonGlobalCache.costumeList = new List<Costume>();
            }

            Costume c = CommonGlobalCache.costumeList?.Find(t => t.ID.ToUpper() == item.ID.ToUpper());

            if (c != null)
            {
                CommonGlobalCache.costumeList?.Remove(c);
                //2018-5-5关联字典
                DeleteCostume(c.ID);

            }
            CommonGlobalCache.costumeList?.Add(item);
            //2018-5-5关联字典
            InsertCostume(item);
        }

        public static void UpdateCostumeValid(UpdateCostumeValidPara result)
        {
            Costume c = CommonGlobalCache.costumeList?.Find(t => t.ID.ToUpper() == result.CostumeID.ToUpper());
            c.IsValid = result.IsValid;
            CostumeList_OnChange(c);
        }

        public static void CostumeList_OnRemove(Costume item)
        {
            Costume c = CommonGlobalCache.costumeList?.Find(t => t.ID.ToUpper() == item.ID.ToUpper());

            if (c != null)
            {
                CommonGlobalCache.costumeList?.Remove(c);
                //2018-5-5关联字典
                DeleteCostume(c.ID);

            }
        }

        #region OwnShopGuide 

        protected static Dictionary<string, Guide> guideDictionary = new Dictionary<string, Guide>();
        public static Dictionary<string, Guide> GuideDictionary { get { return CommonGlobalCache.guideDictionary; } }


        /// <summary>
        /// 新增导购员
        /// </summary>
        /// <param name="guide"></param>
        public static void InsertGuide(Guide guide)
        {
            if (guide == null)
            {
                return;
            }
            CommonGlobalCache.GuideDictionary?.Add(guide.ID, guide);
            CommonGlobalCache.guideList?.Add(guide);

        }

        /// <summary>
        /// 删除导购员
        /// </summary>
        /// <param name="guideID"></param>
        public static void DeleteGuide(string guideID)
        {
            if (string.IsNullOrEmpty(guideID))
            {
                return;
            }
            //if (CommonGlobalCache.GuideDictionary!=null && !CommonGlobalCache.GuideDictionary.Keys.Contains(guideID))
            //{
            //    return;
            //}
            CommonGlobalCache.GuideDictionary?.Remove(guideID);


            Guide guide = CommonGlobalCache.guideList?.Find(t => t.ID == guideID);
            if (guide != null)
            {
                CommonGlobalCache.guideList?.Remove(guide);
            }

        }
        /// <summary>
        /// 更新导购员信息
        /// </summary>
        /// <param name="guide"></param>
        public static void UpdateGuide(Guide guide)
        {
            if (guide == null)
            {
                return;
            }
            CommonGlobalCache.GuideDictionary?.Remove(guide.ID);
            CommonGlobalCache.GuideDictionary?.Add(guide.ID, guide);

            Guide guideOrg = CommonGlobalCache.guideList?.Find(t => t.ID == guide.ID);
            if (guideOrg != null)
            {
                CommonGlobalCache.guideList?.Remove(guideOrg);
            }
            CommonGlobalCache.guideList?.Add(guide);
        }
        #endregion

        #region Year
        protected static List<ListItem<int>> yearList = new List<ListItem<int>>();
        /// <summary>
        /// 年份集合 （包括 所有选择，值为-1）
        /// </summary>
        public static List<ListItem<int>> YearList
        {
            get
            {
                return CommonGlobalCache.yearList;
            }

        }
        #endregion

        #region CostumeColor
        protected static List<CostumeColor> costumeColorList
            //=new List<CostumeColor>() 
            ;

        public static List<CostumeColor> CostumeColorList { get { return CommonGlobalCache.costumeColorList; } }



        public static String GetColorIDByName(String colorName)
        {
            String colorId = string.Empty;

            CostumeColor color = costumeColorList?.Find(t => t.Name == colorName);
            if (color != null)
            {
                colorId = color.ID;
            }
            return colorId;
        }

        #endregion

        #region ParameterConfig



        protected static List<ParameterConfig> parameterConfigList ;

        public static List<ParameterConfig> ParameterConfigList { get { return CommonGlobalCache.parameterConfigList; } }



        /// <summary>
        /// 根据参数类型，获取配置值列表
        /// </summary>
        /// <param name="key">ParameterConfigKey</param>
        /// <returns></returns>
        public static List<ListItem<string>> GetParameterConfig(string key)
        {
            List<ListItem<string>> list = new List<ListItem<string>>();
            ParameterConfig pc = ParameterConfigList?.Find(t => t.ParaKey.Equals(key));
            if (pc != null)
            {
                String[] values = pc.ParaValue.Split(',');
                foreach (String item in values)
                {
                    list.Add(new ListItem<String>(item, item));

                }
            }
            return list;
        }

        #endregion

        #region PromotionTypeEnum

        protected static List<ListItem<PromotionTypeEnum>> promotionTypeEnumList;
        public static List<ListItem<PromotionTypeEnum>> PromotionTypeEnumList { get { return CommonGlobalCache.promotionTypeEnumList; } }

        protected static List<Guide> guideList ;
        public static List<Guide> GuideList { get { return guideList; } }


        public static List<TKeyValue<String, CashRecordFeeType>> FeeTypeList
        {
            get
            {
                List<TKeyValue<String, CashRecordFeeType>> feeTypeList = new List<TKeyValue<string, CashRecordFeeType>>();
                //设置费用类型
                feeTypeList.Add(new TKeyValue<string, CashRecordFeeType>(CommonGlobalUtil.COMBOBOX_ALL, CashRecordFeeType.All));
                feeTypeList.Add(new TKeyValue<string, CashRecordFeeType>("收入", CashRecordFeeType.Income));
                feeTypeList.Add(new TKeyValue<string, CashRecordFeeType>("上缴销售款", CashRecordFeeType.Remittances));
                feeTypeList.Add(new TKeyValue<string, CashRecordFeeType>("支出", CashRecordFeeType.Spending));
                return feeTypeList;
            }
        }





        #endregion


        #region Shop
        private bool enble;
        protected static string currentShopID;
        public static string CurrentShopID { get { return CommonGlobalCache.currentShopID; } }
        public static Shop CurrentShop
        {
            get { return GetShop(CommonGlobalCache.currentShopID); }
        }


        public static Shop GetShop(string shopID)
        {
            
            return ShopList?.Find(t => t.ID == shopID);
        }

        /// <summary>
        /// 获取店铺列表
        /// </summary>
        public static List<Shop> ShopList
        {
            get; set;
            
        }


        /// <summary>
        /// 新增店铺
        /// </summary>
        /// <param name="shop"></param>
        public static void InsertShop(Shop shop)
        {
            if (shop == null)
            {
                return;
            }
            CommonGlobalCache.ShopList?.Add(shop);
        }

        public static void DisableShop(string shopID)
        {

            Shop orgShop = ShopList?.Find(t => t.ID == shopID);
            if (orgShop != null)
            {
                CommonGlobalCache.ShopList?.Remove(orgShop);
            }
        }

        /// <summary>
        /// 更新店铺信息
        /// </summary>
        /// <param name="shop"></param>
        public static void RemoveShop(String ID)
        {
            if (String.IsNullOrEmpty(ID) )
            {
                return;
            }

            Shop orgShop = ShopList?.Find(t => t.ID == ID);
            if (orgShop != null)
            {
                CommonGlobalCache.ShopList?.Remove(orgShop);
            }
            //CommonGlobalCache.ShopList.Add(shop);
        }

        /// <summary>
        /// 更新店铺信息
        /// </summary>
        /// <param name="shop"></param>
        public static void UpdateShop(Shop shop)
        {
            if (shop == null)
            {
                return;
            }

            Shop orgShop = ShopList?.Find(t => t.ID == shop.ID);
            if (orgShop != null)
            {
                CommonGlobalCache.ShopList?.Remove(orgShop);
            }
            CommonGlobalCache.ShopList?.Add(shop);
        }


        /// <summary>
        /// 获取总仓店铺
        /// </summary>
        /// <returns></returns>
        public static Shop GetGeneralStoreShop()
        {
            foreach (Shop shop in ShopList)
            {
                if (shop.IsGeneralStore)
                {
                    return shop;
                }
            }
            return null;
        }
        #endregion

        #region SalesPromotion 
        public static List<SalesPromotion> SalesPromotionList { get { return salesPromotionList; } }
        protected static List<SalesPromotion> salesPromotionList;
        
        /// <summary>
        /// 新增促销活动
        /// </summary>
        /// <param name="salesPromotion"></param>
        public static void InsertSalesPromotion(SalesPromotion salesPromotion)
        {
            if (salesPromotion == null)
            {
                return;
            }
            CommonGlobalCache.SalesPromotionList?.Add(salesPromotion);
        }

        /// <summary>
        /// 更新促销活动
        /// </summary>
        /// <param name="salesPromotion"></param>
        public static void UpdateSalesPromotion(SalesPromotion salesPromotion)
        {
            if (salesPromotion == null)
            {
                return;
            }
            SalesPromotion item = SalesPromotionList?.Find(t => t.ID == salesPromotion.ID);
            if (item != null)
            {
                CommonGlobalCache.SalesPromotionList?.Remove(item);
            }
            CommonGlobalCache.SalesPromotionList?.Add(salesPromotion);
        }

        /// <summary>
        /// 删除促销活动
        /// </summary>
        /// <param name="salesPromotionID"></param>
        public static void DeleteSalesPromotion(string salesPromotionID)
        {
            if (string.IsNullOrEmpty(salesPromotionID))
            {
                return;
            }
            SalesPromotion item = SalesPromotionList?.Find(t => t.ID == salesPromotionID);
            if (item != null)
            {
                item.IsValid = false;
               // CommonGlobalCache.SalesPromotionList.Remove(item);
            }
        }
        #endregion
         
        public static bool IsPos { get; set; }


        #region RechargeDonateRule
        /// <summary>
        /// 充值活动规则列表
        /// </summary>
        /// 
        protected static List<RechargeDonateRule> rechargeDonateRuleList;
        public static List<RechargeDonateRule> RechargeDonateRuleList { get { return rechargeDonateRuleList; } }


        //public static RechargeDonateRule GetRechargeDonateRule(int id)
        //{
        //    return rechargeDonateRuleList.Find(t => t.AutoID == id);
        //}



        /// <summary>
        /// 删除充值规则
        /// </summary>
        public static void DeleteRechargeDonateRule()
        {
            CommonGlobalCache.RechargeDonateRuleList?.Clear();
        }
        #endregion

        #region IntegralConversionBalanceRatio
        protected static int integralConversionBalanceRatio;
        /// <summary>
        /// 积分转余额比例
        /// </summary>
        public static int IntegralConversionBalanceRatio { get { return CommonGlobalCache.integralConversionBalanceRatio; } }

        public static void OnIntegralRatioChanged(int newVal)
        {
            CommonGlobalCache.integralConversionBalanceRatio = newVal;
        }
        #endregion

        #region IncomeConfig
        protected static List<string> incomeList = new List<string>();
        /// <summary>
        /// 收入种类
        /// </summary>
        public static List<string> IncomeList { get { return CommonGlobalCache.incomeList; } }

        public static void UpdateIncomeList(List<string> incomes)
        {
            CommonGlobalCache.incomeList = incomes;
        }

        #endregion

        #region SpendingConfig
        protected static List<string> spendingList = new List<string>();
        /// <summary>
        /// 支出种类
        /// </summary>
        public static List<string> SpendingList { get { return CommonGlobalCache.spendingList; } }

        public static void UpdateSpendingList(List<string> spendings)
        {
            CommonGlobalCache.spendingList = spendings;
        }
        #endregion


        protected static String guideSeeMyself = "1";
        public static String GuideSeeMyself { get { return CommonGlobalCache.guideSeeMyself; } }

        protected static String seeOwnShopMember = "1";
        public static String SeeOwnShopMember { get { return CommonGlobalCache.seeOwnShopMember; } }

        protected static String isGeneralStoreRetail = "1";
        public static String IsGeneralStoreRetail { get { return CommonGlobalCache.isGeneralStoreRetail; } }

        protected static String limitCostumeStore = "1";
        public static String LimitCostumeStore { get { return CommonGlobalCache.limitCostumeStore; } }

        protected static String barCodeTemplate = "0";
        public static String BarCodeTemplate { get { return CommonGlobalCache.barCodeTemplate; } } 

        #region SeasonList
        protected static List<string> seasonList = new List<string>();
        public static List<string> SeasonList
        {
            get
            {
                return seasonList;
            }
        }

        /// <summary>
        /// 季节配置更改
        /// </summary>
        /// <param name="seasonList"></param>
        public static void SeasonChange(List<string> seasonList)
        {
            if (seasonList == null)
            {
                return;
            }
            CommonGlobalCache.seasonList.Clear();
            CommonGlobalCache.seasonList.Add(CommonGlobalUtil.COMBOBOX_ALL);
            foreach (string season in seasonList)
            {
                CommonGlobalCache.seasonList.Add(season);
            }
        }
        #endregion

        #region Costume
        protected static List<Costume> costumeList;
        /// <summary>
        /// 服装
        /// </summary>
        public static List<Costume> CostumeList
        {
            get
            {
                return CommonGlobalCache.costumeList;
            }
        }

        //protected static List<BarCode> barCodeList = new List<BarCode>();
        //public static List<BarCode> BarCodeList
        //{
        //    get
        //    {
        //        return CommonGlobalCache.barCodeList;
        //    }
        //}

        protected static List<SizeGroup> sizeGroupList ;
        public static List<SizeGroup> SizeGroupList
        {
            get
            {
                return CommonGlobalCache.sizeGroupList;
            }
        }





        //protected static Dictionary<string, Costume> costumeDictionary = new Dictionary<string, Costume>();
        ///// <summary>
        ///// 服装字典集合
        ///// </summary>
        //public static Dictionary<string, Costume> CostumeDictionary
        //{
        //    get
        //    {
        //        return CommonGlobalCache.costumeDictionary;
        //    }
        //}
        /// <summary>
        /// 根据款号获取服装名称 （注：款号不存在返回 ""）
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public static string GetCostumeName(string costumeID)
        {
            String costumeName = String.Empty;
            costumeName = GetCostume(costumeID)?.Name;
            return costumeName;
        }


        /// <summary>
        /// 根据款号获取服装实体
        /// </summary>
        /// <param name="costumeID">款号</param>
        /// <returns></returns>
        public static Costume GetCostume(string costumeID)
        {
            Costume costumeName = CommonGlobalCache.costumeList?.Find(t => t.ID.ToUpper().Equals(costumeID.ToUpper()));
            return costumeName;
        }


        /// <summary>
        /// 新增服装信息
        /// </summary>
        /// <param name="costume"></param>
        public static void InsertCostume(Costume costume)
        {
            if (costume == null)
            {
                return;
            }



            Costume costumeOrg = CommonGlobalCache.CostumeList?.Find(t => t.ID.ToUpper().Equals(costume?.ID.ToUpper()));
            if (costumeOrg != null)
            {
                CommonGlobalCache.CostumeList?.Remove(costumeOrg);
            }
            CommonGlobalCache.costumeList?.Add(costume);
        }

        /// <summary>
        /// 修改服装信息
        /// </summary>
        /// <param name="costume"></param>
        public static void UpdateCostume(Costume costume)
        {
            //if (costume == null)
            //{
            //    return;
            //}
            //if (!CommonGlobalCache.CostumeDictionary.Keys.Contains(costume.ID))
            //{
            //    return;
            //}

            Costume costumeOrg = CommonGlobalCache.CostumeList?.Find(t => t.ID.ToUpper().Equals(costume?.ID.ToUpper()));
            if (costumeOrg != null)
            {
                CommonGlobalCache.CostumeList?.Remove(costumeOrg);
            }

          CommonGlobalCache.CostumeList?.Add(costume);
          //CommonGlobalCache.CostumeDictionary.Remove(costume?.ID);
          //  CommonGlobalCache.CostumeDictionary.Add(costume?.ID, costume);
        }

        /// <summary>
        /// 删除服装信息
        /// </summary>
        /// <param name="costumeID"></param>
        public static void DeleteCostume(string costumeID)
        {
            Costume costume= CommonGlobalCache.CostumeList?.Find(t=>t.ID.ToUpper().Equals(costumeID.ToUpper()));
            if (costume != null) {
                CommonGlobalCache.CostumeList?.Remove(costume);
            }
           // CommonGlobalCache.CostumeDictionary.Remove(costumeID); 
        }
        #endregion

        #region Brand
        protected static List<Brand> brandList;
        public static List<Brand> BrandList { get { return CommonGlobalCache.brandList; } }
        public static string GetBrandName(int id)
        {
            string name = "";
            foreach (var item in BrandList)
            {
                if (item.AutoID == id)
                {
                    name = item.Name;
                }
            }
            return name;
        } 

        /// <summary>
        /// 新增品牌信息
        /// </summary>
        /// <param name="brand"></param>
        public static void InsertBrand(Brand brand)
        {
            if (brand == null)
            {
                return;
            }
            CommonGlobalCache.brandList?.Add(brand);
            CommonGlobalCache.brandList?.Sort();
        }

        /// <summary>
        /// 修改品牌信息
        /// </summary>
        /// <param name="brand"></param>
        public static void UpdateBrand(Brand brand)
        {
            if (brand == null)
            {
                return;
            }
            Brand oldBrand = CommonGlobalCache.brandList?.Find(b => b.AutoID == brand.AutoID);
            if (oldBrand != null)
            {
                CommonGlobalCache.brandList?.Remove(oldBrand);
            }
            CommonGlobalCache.BrandList?.Add(brand);
            CommonGlobalCache.brandList?.Sort();
        }

        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="brandID"></param>
        public static void DeleteBrand(int brandID)
        {
            Brand oldBrand = CommonGlobalCache.brandList?.Find(b => b.AutoID == brandID);
            if (oldBrand != null)
            {
                CommonGlobalCache.brandList?.Remove(oldBrand);
            }
            CommonGlobalCache.brandList?.Sort();
        }
        #endregion

        #region AdminUser
        protected static string currentUserID;
        public static string CurrentUserID { get { return CommonGlobalCache.currentUserID; } }
        
        protected static UserInfo currentUser = null;
        public static UserInfo CurrentUser
        {
            get { return currentUser; }
        }

        public static UserInfo DemoCurrentUser
        {
            set { currentUser = value; }
        }


        public static AdminUser GetAdminUser(string userID)
        {
            return CommonGlobalCache.adminUserList?.Find(t => t.ID == userID);
        }

        public static AdminUser GetSupperAdminUser()
        {
            return CommonGlobalCache.adminUserList?.Find(t => t.ID == SystemDefault.DefaultAdmin);
        }


        protected static List<AdminUser> adminUserList;
        public static List<AdminUser> AdminUserList { get { return adminUserList; } }



        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="adminUser"></param>
        public static void InsertAdminUser(AdminUser adminUser)
        {
            if (adminUser == null)
            {
                return;
            }
            CommonGlobalCache.adminUserList?.Add(adminUser);
        }

        /// <summary>
        /// 更新管理员
        /// </summary>
        /// <param name="adminUser"></param>
        public static void UpdateAdminUser(AdminUser adminUser)
        {
            if (adminUser == null)
            {
                return;
            }
            AdminUser oldAdminUser = CommonGlobalCache.adminUserList?.Find(u => u.ID.ToUpper() == adminUser.ID.ToUpper());
            if (oldAdminUser != null)
            {
                CommonGlobalCache.adminUserList?.Remove(oldAdminUser);
            }
            CommonGlobalCache.adminUserList?.Add(adminUser);
        }
        #endregion
        protected static List<TreeModel> distributorPFMemberList; //批发分销人员
        public static List<TreeModel> DistributorPFList { get { return CommonGlobalCache.distributorPFMemberList; } }

        protected static List<TreeModel> distributorMemberList; //分销人员
        public static List<TreeModel> DistributorList { get { return CommonGlobalCache.distributorMemberList; } }






        /// <summary>
        /// 新增分销人员
        /// </summary>
        /// <param name="adminUser"></param>
        public static void InsertPFDistributor(TreeModel tModel)
        {
            if (tModel == null)
            {
                return;
            }
            CommonGlobalCache.distributorPFMemberList?.Add(tModel);
        }

        /// <summary>
        /// 更新分销人员
        /// </summary>
        /// <param name="tModel"></param>
        public static void UpdatePFDistributor(TreeModel tModel)
        {
            if (tModel == null)
            {
                return;
            }
            TreeModel oldAdminUser = CommonGlobalCache.distributorPFMemberList?.Find(u => u.ID.ToUpper() == tModel.ID.ToUpper());
            if (oldAdminUser != null)
            {
                CommonGlobalCache.distributorPFMemberList?.Remove(tModel);
            }
            CommonGlobalCache.distributorPFMemberList?.Add(tModel);
        }


        public static void DeletePFDistributor(TreeModel tModel)
        {
            TreeModel oldSupplier = CommonGlobalCache.distributorPFMemberList?.Find(s => s.ID.Equals(tModel.ID));
            if (oldSupplier == null)
            {
                return;
            }
            CommonGlobalCache.distributorPFMemberList?.Remove(oldSupplier);
            // CommonGlobalCache.supplierList?.Sort();
        }










        /// <summary>
        /// 新增分销人员
        /// </summary>
        /// <param name="adminUser"></param>
        public static void InsertDistributor(TreeModel tModel)
        {
            if (tModel == null)
            {
                return;
            }
            CommonGlobalCache.distributorMemberList?.Add(tModel);
        }

        /// <summary>
        /// 更新分销人员
        /// </summary>
        /// <param name="tModel"></param>
        public static void UpdateDistributor(TreeModel tModel)
        {
            if (tModel == null)
            {
                return;
            }
            TreeModel oldAdminUser = CommonGlobalCache.distributorMemberList?.Find(u => u.ID.ToUpper() == tModel.ID.ToUpper());
            if (oldAdminUser != null)
            {
                CommonGlobalCache.distributorMemberList?.Remove(tModel);
            }
            CommonGlobalCache.distributorMemberList?.Add(tModel);
        }


        public static void DeleteDistributor(TreeModel tModel)
        {
            TreeModel oldSupplier = CommonGlobalCache.distributorMemberList?.Find(s => s.ID.Equals(tModel.ID));
            if (oldSupplier == null)
            {
                return;
            }
            CommonGlobalCache.distributorMemberList?.Remove(oldSupplier);
           // CommonGlobalCache.supplierList?.Sort();
        }





        #region Supplier
        protected static List<Supplier> supplierList;

        //   public static Supplier bulkSupplier = new Supplier() {  ID="0", Name="散货供应商" };
        public static List<Supplier> SupplierList { get { return CommonGlobalCache.supplierList; } }

        public static List<Supplier> EnabledSupplierList { get {
                List < Supplier > suppliers = CommonGlobalCache.supplierList?.FindAll(t => t.Enabled);
                suppliers?.Sort();
                return suppliers;
            }
        }

        public static List<Shop> EnabledShopList { get { return CommonGlobalCache.ShopList?.FindAll(t => t.Enabled); } }
        

        public static string GetSupplierName(string id)
        {
            string name = "";
            foreach (Supplier item in SupplierList)
            {
                if (item.ID == id)
                {
                    name = item.Name;
                }
            }
            return name;
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="supplierID"></param>
        public static void DeleteSupplier(string supplierID)
        {
            Supplier oldSupplier = CommonGlobalCache.supplierList?.Find(s => s.ID.Equals(supplierID));
            if (oldSupplier == null)
            {
                return;
            }
            CommonGlobalCache.supplierList?.Remove(oldSupplier);
            CommonGlobalCache.supplierList?.Sort();
        }

        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <param name="supplier"></param>
        public static void InsertSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                return;
            }
            CommonGlobalCache.supplierList?.Add(supplier);
            CommonGlobalCache.supplierList?.Sort();
        }
        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="supplier"></param>
        public static void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                return;
            }
            Supplier oldSupplier = CommonGlobalCache.supplierList?.Find(s => s.ID == supplier.ID);
            if (oldSupplier != null)
            {
                CommonGlobalCache.supplierList?.Remove(oldSupplier);
            }
            CommonGlobalCache.supplierList?.Add(supplier);
            CommonGlobalCache.supplierList?.Sort();
        }

        protected static void SetParams()
        {
            if (parameterConfigList != null)
            {
                foreach (ParameterConfig config in parameterConfigList)
                {
                    ParameterConfig(config, false);
                }
            }
        }

        public static void ParameterConfig(ParameterConfig config, bool updateList = true)
        {
            switch (config.ParaKey)
            {
                case ParameterConfigKey.IntegrationExchange:
                    CommonGlobalCache.integralConversionBalanceRatio = Int32.Parse(config.ParaValue);
                    break;
                case ParameterConfigKey.CostumeModel:
                    break;
                case ParameterConfigKey.CostumeStyle:
                    break;
                case ParameterConfigKey.Season:
                    CommonGlobalCache.SeasonChange(new List<string>(config.ParaValue.Split(',')));
                    break;
                case ParameterConfigKey.IncomeTypes:
                    CommonGlobalCache.incomeList = new List<string>(config.ParaValue.Split(','));
                    break;
                case ParameterConfigKey.SpendingTypes:
                    CommonGlobalCache.spendingList = new List<string>(config.ParaValue.Split(','));
                    break;
                case ParameterConfigKey.X_SeeMyself:
                    CommonGlobalCache.guideSeeMyself = config.ParaValue;
                    break;
                case ParameterConfigKey.SeeOwnShopMember:
                    CommonGlobalCache.seeOwnShopMember = config.ParaValue;
                    break;
                case ParameterConfigKey.LimitCostumeStore:
                    CommonGlobalCache.limitCostumeStore = config.ParaValue;
                    break;
                case ParameterConfigKey.BarCodeTemplate:
                    CommonGlobalCache.barCodeTemplate = config.ParaValue;
                    break;
                case ParameterConfigKey.DefaultSizeGroup:
                    CommonGlobalCache.defaultSizeGroupName = config.ParaValue;
                    break; 
                case ParameterConfigKey.CostumeGiftTicket:
                    CostumeGiftTicketInfo info = new CostumeGiftTicketInfo();
                    info.StringToObj(config.ParaValue);
                    CommonGlobalCache.costumeGiftTicketInfo = info;
                    break;
                default:
                    break;
            }
            if (updateList)
            {
                UpdateParameterKey(config);
            }
        }

        public static ParameterConfig GetParameter(String key)
        {
            ParameterConfig configOrg = parameterConfigList?.Find(t => t.ParaKey == key);
            return configOrg;
        }

        private static void UpdateParameterKey(ParameterConfig config)
        {
            ParameterConfig configOrg = parameterConfigList?.Find(t => t.ParaKey == config.ParaKey);
            if (config != null)
            {
                parameterConfigList?.Remove(configOrg);
            }
            parameterConfigList.Add(config);
        }
      
        public static void ReInitConfig(String[] keys)
        {

            CommonGlobalCache.parameterConfigList = CommonGlobalCache.ServerProxy.GetAllParameterConfig();
            if (parameterConfigList != null)
            {
                foreach (ParameterConfig config in parameterConfigList)
                {
                    foreach (var key in keys)
                    {
                        if (config.ParaKey == key)
                        {
                            ParameterConfig(config, false);
                        }
                    }
                }
            }
        }




        public static void ReInitConfig()
        {
            CommonGlobalCache.parameterConfigList = CommonGlobalCache.ServerProxy.GetAllParameterConfig();
            if (parameterConfigList != null)
            {
                foreach (ParameterConfig config in parameterConfigList)
                {
                    ParameterConfig(config, false);
                }
            }
        }


        #endregion

        #region CheckStore
        /// <summary>
        /// 本店是否处于盘点状态
        /// </summary>
     //   public static bool IsCheckStoreState { get; set; }
        private static BusinessAccount businessAccount;
        public static BusinessAccount BusinessAccount { get { return businessAccount; } }
        public static void SetBusinessAccount(BusinessAccount value)
        {
            businessAccount = value;
        }
        protected static Image eMallMiniProgramImg;
        public static Image EMallMiniProgramImg { get { return eMallMiniProgramImg; } }

       
        #endregion

        #region Method
        /// <summary>
        /// 获取导购姓名（导购不存在，返回userID）
        /// </summary>
        /// <param name="guideID"></param>
        /// <returns></returns>
        public static string GetUserName(string userID)
        {
            String value = userID;
            if (value == SystemDefault.WithoutID)
            {
                value = SystemDefault.WithoutName;
            }
            else
            {
                Guide guide = CommonGlobalCache.GuideList?.Find(t => t.ID == userID);
                if (guide != null)
                {
                    value = guide.Name;
                }
                else
                {
                    AdminUser adminUser = CommonGlobalCache.adminUserList?.Find(t => t.ID == userID);
                    if (adminUser != null)
                    {
                        value = adminUser.Name;
                    }
                }
            }

            return value;
        }



        public static string GetUserIDByUserName(string userName)
        {
            String value = userName;
            if (value == SystemDefault.WithoutID)
            {
                value = SystemDefault.WithoutName;
            }
            else
            {
                Guide guide = CommonGlobalCache.GuideList?.Find(t => t.Name == userName);
                if (guide != null)
                {
                    value = guide.ID;
                }
                else
                {
                    AdminUser adminUser = CommonGlobalCache.adminUserList?.Find(t => t.Name == userName);
                    if (adminUser != null)
                    {
                        value = adminUser.ID;
                    }
                }
            }

            return value;
        }

        public static string GetShopIDByName(string shopName)
        {
            String value = shopName;
            if (string.IsNullOrEmpty(shopName)) { return value; }
            if (value == SystemDefault.WithoutID)
            {
                return SystemDefault.WithoutName;
            }



            Shop shop = ShopList.Find(t => t.Name == shopName);
            if (shop != null)
            {
                value = shop.Name;
            }
            else if (shopName == SystemDefault.Report_Online)
            {
                value = ShopList.Find(t => t.ShowOnEMall).ID;
            }

            return value;
        }

        /// <summary>
        /// 获取店铺名称 （店铺不存在返回 shopID）
        /// </summary>
        /// <param name="shopID"></param>
        /// <returns></returns>
        public static string GetShopName(string shopID)
        {
            String value = shopID;
            if (string.IsNullOrEmpty(shopID)) { return value; }
            if (value == SystemDefault.WithoutID)
            {
                return SystemDefault.WithoutName;
            }



            Shop shop = ShopList.Find(t => t.ID == shopID);
            if (shop != null)
            {
                value = shop.Name;
            }
            else if (shopID == SystemDefault.Report_Online)
            {
                value = SystemDefault.onlineName;
            }
            else
            {
                foreach (Supplier supplier in CommonGlobalCache.supplierList)
                {
                    if (supplier.ID == shopID)
                    {
                        value = supplier.Name;
                        break;
                    }
                }
            }


            return value;
        }

        /// <summary>
        /// 根据款号查找品牌名称
        /// </summary>
        /// <param name="costumeID"></param>
        /// <returns></returns>
        public static string GetBrandName4CostumeID(string costumeID)
        {
            Costume costume = CommonGlobalCache.GetCostume(costumeID);
            if (costume == null)
            {
                return string.Empty;
            }
            return CommonGlobalCache.GetBrandName(costume.BrandID);
        }
        #endregion
    }
}

using JGNet.Core.Const;
using JGNet.Core.InteractEntity;
using JGNet.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Common.cache.Wholesale
{
   public class PfCustomerCache: CommonGlobalCache
    {   /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="supplierID"></param>
        public static void DeletePfCustomer(string supplierID)
        {
            PfCustomer oldSupplier = pfCustomerList.Find(s => s.ID == supplierID);
            if (oldSupplier == null)
            {
                return;
            }
            pfCustomerList.Remove(oldSupplier);
        }

        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <param name="supplier"></param>
        public static void InsertPfCustomer(PfCustomer supplier)
        {
            if (supplier == null)
            {
                return;
            }
            pfCustomerList?.Add(supplier);
        }
        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="supplier"></param>
        public static void UpdatePfCustomer(PfCustomer supplier)
        {
            if (supplier == null)
            {
                return;
            }
            PfCustomer oldSupplier = pfCustomerList?.Find(s => s.ID == supplier.ID);
            if (oldSupplier != null)
            {
                pfCustomerList?.Remove(oldSupplier);
            }
            pfCustomerList?.Add(supplier);
        }

        protected static List<PfCustomer> pfCustomerList;
        public static List<PfCustomer> PfCustomerList { get { return pfCustomerList; } }
        public static void Load()
        {
            if (pfCustomerList == null)
            {
                GetPfCustomerPagePara pfPara = new GetPfCustomerPagePara()
                {
                    PageIndex = 0,
                    PageSize = int.MaxValue
                };

                pfCustomerList = PfCustomerCache.ServerProxy.GetPfCustomerPage(pfPara)?.PfCustomers;
                if (pfCustomerList != null && pfCustomerList.Count > 0)
                {

                    foreach (var item in pfCustomerList)
                    {
                        if (string.IsNullOrEmpty(item.FirstCharSpell))
                        {
                            item.FirstCharSpell = DisplayUtil.GetPYString(item.Name);
                        }
                    }
                }
            }
        }

        public static InteractResult PfCustomer_OnRemove(string id)
        {
            InteractResult result = ServerProxy.DeletePfCustomer(id);
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    PfCustomer c = pfCustomerList?.Find(t => t.ID == id);
                    if (c != null)
                    {
                        pfCustomerList?.Remove(c);
                    }
                    break;
                case ExeResult.Error:
                    break;
                default:
                    break;
            }
            return result;
        }

        public static InteractResult PfCustomer_OnUpdate(PfCustomer curSupplier)
        {
            InteractResult result = ServerProxy.UpdatePfCustomer(curSupplier);
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    PfCustomer supplier = pfCustomerList?.Find(t => t.ID == curSupplier.ID);
                    if (supplier != null) { pfCustomerList?.Remove(supplier); }
                    pfCustomerList?.Add(curSupplier);
                    break;
                case ExeResult.Error:
                    break;
                default:
                    break;
            }
            return result;
        }



        public static InteractResult PfCustomer_OnInsert(PfCustomer item)
        {
            InteractResult result = ServerProxy.InsertPfCustomer(item);
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    if (pfCustomerList == null)
                    {
                        pfCustomerList = new List<PfCustomer>();
                    }
                    pfCustomerList?.Add(item);
                    break;
                case ExeResult.Error:
                    break;
                default:
                    break;
            }
            return result;

        }

        public static string GetPfCustomerName(string pfCustomerID)
        {
            return pfCustomerList?.Find(t => t.ID == pfCustomerID)?.Name;
        }
        public static PfCustomer GetPfCustomer(string pfCustomerID)
        {
            return pfCustomerList?.Find(t => t.ID == pfCustomerID);
        }

        public static string GetUserNameWithPf(string userID)
        {
            String value = userID;
            if (value == SystemDefault.WithoutID)
            {
                value = SystemDefault.WithoutName;
            }
            else
            {
                PfCustomer guide = pfCustomerList?.Find(t => t.ID == userID);
                if (guide != null)
                {
                    value = guide.Name;
                }
                else
                {
                    AdminUser adminUser = adminUserList?.Find(t => t.ID == userID);
                    if (adminUser != null)
                    {
                        value = adminUser.Name;
                    }
                }
            }

            return value;
        }
    }
}

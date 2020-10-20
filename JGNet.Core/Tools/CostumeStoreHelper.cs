using JGNet.Core.Const;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    public static class CostumeStoreHelper
    {
        private static String[] costumeSizeColumn = new String[] { "F","XS", "S", "M", "L", "XL", "XL2", "XL3", "XL4", "XL5", "XL6" };
        public static String[] CostumeSizeColumn { get { return costumeSizeColumn; } }


        /// <summary>
        /// 将界面上的类似2XL标识转化为DB中对应的XL2
        /// </summary>
        /// <param name="sizeName"></param>
        /// <returns></returns>
        public static string GetCostumeSize(string sizeName, SizeGroup sizeGroup)
        {
            //sizeName = sizeName.ToUpper();
            if (sizeName == sizeGroup.NameOfF)
            {
                return CostumeSize.F;
            }
            if (sizeName == sizeGroup.NameOfXS)
            {
                return CostumeSize.XS;
            }
            if (sizeName == sizeGroup.NameOfS)
            {
                return CostumeSize.S;
            }
            if (sizeName == sizeGroup.NameOfM)
            {
                return CostumeSize.M;
            }
            if (sizeName == sizeGroup.NameOfL)
            {
                return CostumeSize.L;
            }
            if (sizeName == sizeGroup.NameOfXL)
            {
                return CostumeSize.XL;
            }
            if (sizeName == sizeGroup.NameOfXL2)
            {
                return CostumeSize.XL2;
            }
            if (sizeName == sizeGroup.NameOfXL3)
            {
                return CostumeSize.XL3;
            }
            if (sizeName == sizeGroup.NameOfXL4)
            {
                return CostumeSize.XL4;
            }
            if (sizeName == sizeGroup.NameOfXL5)
            {
                return CostumeSize.XL5;
            }
            if (sizeName == sizeGroup.NameOfXL6)
            {
                return CostumeSize.XL6;
            }
            return sizeName;
        }

        public static string GetCostumeSize2(string sizeName, SizeGroup sizeGroup)
        {
            //sizeName = sizeName.ToUpper();
            if (sizeName == sizeGroup.NameOfF)
            {
                return CostumeSize.F;
            }
            if (sizeName == sizeGroup.NameOfXS)
            {
                return CostumeSize.XS;
            }
            if (sizeName == sizeGroup.NameOfS)
            {
                return CostumeSize.S;
            }
            if (sizeName == sizeGroup.NameOfM)
            {
                return CostumeSize.M;
            }
            if (sizeName == sizeGroup.NameOfL)
            {
                return CostumeSize.L;
            }
            if (sizeName == sizeGroup.NameOfXL)
            {
                return CostumeSize.XL;
            }
            if (sizeName == sizeGroup.NameOfXL2)
            {
                return CostumeSize.XL2;
            }
            if (sizeName == sizeGroup.NameOfXL3)
            {
                return CostumeSize.XL3;
            }
            if (sizeName == sizeGroup.NameOfXL4)
            {
                return CostumeSize.XL4;
            }
            if (sizeName == sizeGroup.NameOfXL5)
            {
                return CostumeSize.XL5;
            }
            if (sizeName == sizeGroup.NameOfXL6)
            {
                return CostumeSize.XL6;
            }
            return null;
        }

        /// <summary>
        /// 尺码转 尺码别名
        /// </summary>
        /// <param name="sizeColumn"></param>
        /// <param name="sizeGroup"></param>
        /// <returns></returns>
        public static string GetCostumeSizeName(string sizeColumn, SizeGroup sizeGroup)
        {
            sizeColumn = sizeColumn?.ToUpper();
            if (sizeGroup == null)
            {
                return sizeColumn;
            }
            switch (sizeColumn)
            {
                case CostumeSize.F:
                    return sizeGroup.NameOfF;
                case CostumeSize.XS:
                    return sizeGroup.NameOfXS;
                case CostumeSize.S:
                    return sizeGroup.NameOfS;
                case CostumeSize.M:
                    return sizeGroup.NameOfM;
                case CostumeSize.L:
                    return sizeGroup.NameOfL;
                case CostumeSize.XL:
                    return sizeGroup.NameOfXL;
                case CostumeSize.XL2:
                    return sizeGroup.NameOfXL2;
                case CostumeSize.XL3:
                    return sizeGroup.NameOfXL3;
                case CostumeSize.XL4:
                    return sizeGroup.NameOfXL4;
                case CostumeSize.XL5:
                    return sizeGroup.NameOfXL5;
                case CostumeSize.XL6:
                    return sizeGroup.NameOfXL6;
                default:
                    return sizeColumn;
            }
        }
        /// <summary>
        /// 获取指定款号库存 中指定颜色的数量
        /// </summary>
        /// <param name="store">库存实体</param>
        /// <param name="sizeType">DB中的尺码标识</param>
        /// <returns></returns>
        public static void AddStoreCountBySize(CostumeStore store, string sizeType, short value)
        {
            if (store == null)
            {
                return ;
            }
            switch (sizeType)
            {
                case CostumeSize.XS:
                    store.XS += value;
                    break;
                case CostumeSize.S:
                    store.S += value;
                    break;
                case CostumeSize.M:
                    store.M += value;
                    break;
                case CostumeSize.L:
                    store.L += value;
                    break;
                case CostumeSize.XL:
                    store.XL += value;
                    break;
                case CostumeSize.XL2:
                    store.XL2 += value;
                    break;
                case CostumeSize.XL3:
                    store.XL3 += value;
                    break;
                case CostumeSize.XL4:
                    store.XL4 += value;
                    break;
                case CostumeSize.XL5:
                    store.XL5 += value;
                    break;
                case CostumeSize.XL6:
                    store.XL6 += value;
                    break;
                case CostumeSize.F:
                    store.F += value;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 获取指定款号库存 中指定颜色的数量
        /// </summary>
        /// <param name="store">库存实体</param>
        /// <param name="sizeType">DB中的尺码标识</param>
        /// <returns></returns>
        public static int GetStoreCountBySize(CostumeStore store, string sizeType)
        {
            if (store==null)
            {
                return 0;
            }
            switch (sizeType)
            {
                case CostumeSize.XS:
                    return store.XS;
                case CostumeSize.S:
                    return store.S;
                case CostumeSize.M:
                    return store.M;
                case CostumeSize.L:
                    return store.L;
                case CostumeSize.XL:
                    return store.XL;
                case CostumeSize.XL2:
                    return store.XL2;
                case CostumeSize.XL3:
                    return store.XL3;
                case CostumeSize.XL4:
                    return store.XL4;
                case CostumeSize.XL5:
                    return store.XL5;
                case CostumeSize.XL6:
                    return store.XL6;
                case CostumeSize.F:
                    return store.F;
                default:
                    return 0;
            }
        }

        public static void SetSizeName4CostumeStore(CostumeStore costumeStore,SizeGroup sizeGroup)
        {
            List<CostumeStoreInfo> infos = new List<CostumeStoreInfo>();
            foreach (string sizeColumn in costumeSizeColumn)
            {
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(costumeStore, sizeColumn)
                });
            }
            costumeStore.CostumeStoreInfos = infos;
        }

        /// <summary>
        /// 根据尺码别名 转换为 对应的库存对象
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        public static CostumeStore GetCostumeStore4SizeNameAlias(List<CostumeStoreInfo> infos, SizeGroup sizeGroup)
        {
            CostumeStore costumeStore = new CostumeStore();
            foreach (CostumeStoreInfo info in infos)
            {
                string sizeName = GetCostumeSize(info.SizeName, sizeGroup);
                AddStoreCountBySize(costumeStore, sizeName, (short)info.Count);
            }
            return costumeStore;
        }

        public static void SetSizeName4CostumeStore(string[] costumeSizes, CostumeStore costumeStore, SizeGroup sizeGroup)
        {
            if (costumeSizes == null || costumeSizes.Length == 0)
            {
                return;
            }
            List<CostumeStoreInfo> infos = new List<CostumeStoreInfo>();
            foreach (string sizeColumn in costumeSizes)
            {
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(costumeStore, sizeColumn)
                });
            }
            costumeStore.CostumeStoreInfos = infos;
        }

        public static List<CostumeStoreInfo> GetCostumeStoreInfos(PfCustomerStore pfCustomerStore, SizeGroup sizeGroup)
        {
            List<CostumeStoreInfo> infos = new List<CostumeStoreInfo>();
            if (pfCustomerStore.XS != 0)
            {
                string sizeColumn = CostumeSize.XS;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.S != 0)
            {
                string sizeColumn = CostumeSize.S;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.M != 0)
            {
                string sizeColumn = CostumeSize.M;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.L != 0)
            {
                string sizeColumn = CostumeSize.L;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL != 0)
            {
                string sizeColumn = CostumeSize.XL;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL2 != 0)
            {
                string sizeColumn = CostumeSize.XL2;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL3 != 0)
            {
                string sizeColumn = CostumeSize.XL3;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL4 != 0)
            {
                string sizeColumn = CostumeSize.XL4;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL5 != 0)
            {
                string sizeColumn = CostumeSize.XL5;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.XL6 != 0)
            {
                string sizeColumn = CostumeSize.XL6;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            if (pfCustomerStore.F != 0)
            {
                string sizeColumn = CostumeSize.F;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            return infos;
        }

        /// <summary>
        /// 获取指定款号库存 中指定颜色的数量
        /// </summary>
        /// <param name="store">库存实体</param>
        /// <param name="sizeType">DB中的尺码标识</param>
        /// <returns></returns>
        public static int GetStoreCountBySize(PfCustomerStore store, string sizeType)
        {
            if (store == null)
            {
                return 0;
            }
            switch (sizeType)
            {
                case CostumeSize.XS:
                    return store.XS;
                case CostumeSize.S:
                    return store.S;
                case CostumeSize.M:
                    return store.M;
                case CostumeSize.L:
                    return store.L;
                case CostumeSize.XL:
                    return store.XL;
                case CostumeSize.XL2:
                    return store.XL2;
                case CostumeSize.XL3:
                    return store.XL3;
                case CostumeSize.XL4:
                    return store.XL4;
                case CostumeSize.XL5:
                    return store.XL5;
                case CostumeSize.XL6:
                    return store.XL6;
                case CostumeSize.F:
                    return store.F;
                default:
                    return 0;
            }
        }

        public static List<CostumeStoreInfo> GetCostumeStoreInfos(PfOrderDetail detail, SizeGroup sizeGroup)
        {
            List<CostumeStoreInfo> infos = new List<CostumeStoreInfo>();
            if (detail.XS != 0)
            {
                string sizeColumn = CostumeSize.XS;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.S != 0)
            {
                string sizeColumn = CostumeSize.S;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.M != 0)
            {
                string sizeColumn = CostumeSize.M;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.L != 0)
            {
                string sizeColumn = CostumeSize.L;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL != 0)
            {
                string sizeColumn = CostumeSize.XL;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL2 != 0)
            {
                string sizeColumn = CostumeSize.XL2;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL3 != 0)
            {
                string sizeColumn = CostumeSize.XL3;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL4 != 0)
            {
                string sizeColumn = CostumeSize.XL4;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL5 != 0)
            {
                string sizeColumn = CostumeSize.XL5;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.XL6 != 0)
            {
                string sizeColumn = CostumeSize.XL6;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            if (detail.F != 0)
            {
                string sizeColumn = CostumeSize.F;
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(detail, sizeColumn)
                });
            }
            return infos;
        }

        public static List<CostumeStoreInfo> SetSizeName4CostumeStore(List<string> costumeSizes, PfCustomerStore pfCustomerStore, SizeGroup sizeGroup)
        {
            if (costumeSizes == null || costumeSizes.Count == 0)
            {
                return new List<CostumeStoreInfo>();
            }
            List<CostumeStoreInfo> infos = new List<CostumeStoreInfo>();
            foreach (string sizeColumn in costumeSizes)
            {
                infos.Add(new CostumeStoreInfo()
                {
                    OriginalSizeName = sizeColumn,
                    SizeName = GetCostumeSizeName(sizeColumn, sizeGroup),
                    Count = GetStoreCountBySize(pfCustomerStore, sizeColumn)
                });
            }
            return infos;
        }

        /// <summary>
        /// 获取指定款号库存 中指定颜色的数量
        /// </summary>
        /// <param name="store">库存实体</param>
        /// <param name="sizeType">DB中的尺码标识</param>
        /// <returns></returns>
        public static int GetStoreCountBySize(PfOrderDetail detail, string sizeType)
        {
            if (detail == null)
            {
                return 0;
            }
            switch (sizeType)
            {
                case CostumeSize.XS:
                    return detail.XS;
                case CostumeSize.S:
                    return detail.S;
                case CostumeSize.M:
                    return detail.M;
                case CostumeSize.L:
                    return detail.L;
                case CostumeSize.XL:
                    return detail.XL;
                case CostumeSize.XL2:
                    return detail.XL2;
                case CostumeSize.XL3:
                    return detail.XL3;
                case CostumeSize.XL4:
                    return detail.XL4;
                case CostumeSize.XL5:
                    return detail.XL5;
                case CostumeSize.XL6:
                    return detail.XL6;
                case CostumeSize.F:
                    return detail.F;
                default:
                    return 0;
            }
        }
    }

    [Serializable]
    public class CostumeStoreInfo
    {
        /// <summary>
        /// 原始尺码名称 （X,XL ...）
        /// </summary>
        public string OriginalSizeName { get; set; }

        /// <summary>
        /// 显示的尺码名称（20码，21码 ...）
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
    }
}

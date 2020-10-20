using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetCostumePricesPara
    {
        public string CostumeID { get; set; }

        public string ShopId { get; set; }

        /// <summary>
        /// -1:不过滤
        /// </summary>
        public int BrandID { get; set; }

        private int classId = -1;
        /// <summary>
        /// 类别id：（不过滤：-1）
        /// </summary>
        public int ClassID
        {
            get
            {
                return this.classId;
            }
            set
            {
                this.classId = value;
            }
        }
    }

    [Serializable]
    public class CostumePrice : UpdateShopCostumePricePara
    {
        public string CostumeName { get; set; }

        public string ShopName { get; set; }
    }

    [Serializable]
    public class UpdateShopCostumePricePara
    {
        public string CostumeID { get; set; }
        
        public string ShopId { get; set; }
        
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }
    }
}

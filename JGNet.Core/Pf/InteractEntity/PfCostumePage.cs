using JGNet.Core.InteractEntity;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Pf.InteractEntity
{
    public class PfCostumePage : BasePage
    {
        public List<PfCostume> PfCostumes { get; set; }
    }

    public class PfCostume
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string EmThumbnail { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsFavorite { get; set; }

        public decimal PfDiscount { get; set; }

        public decimal PfPrice
        {
            get
            {
                return MathHelper.Rounded(this.Price * this.PfDiscount, 0);
            }
        }

        public List<EmCostumePhoto> EmCostumePhotos { get; set; }

        public List<string> SizeNames { get; set; }        
    }

    public class PfCostumeDetail : PfCostume
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 主图
        /// </summary>
        public string MainPhoto { get; set; }

        public List<string> LinkAddressList { get; set; }
    }
}

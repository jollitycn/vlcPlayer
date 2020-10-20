using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class EmPfCostumeInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string EmTitle { get; set; }

        public string Colors { get; set; }

        public decimal PfOnlinePrice { get; set; }
        
        public string EmThumbnail { get; set; }

        public List<EmCostumePhoto> EmCostumePhotos { get; set; }

        public string EmDetails { get; set; }
        
        public decimal EmOnlinePrice { get; set; }

        public int CarriageCostTemplateID { get; set; }


        
        public bool EmShowOnline { get; set; }

        /// <summary>
        /// 是否线上商城上架过
        /// </summary>
        public bool EmEverOnline { get; set; }
    }

    public class ShelvesEmPfInfoPara
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public decimal PfOnlinePrice { get; set; }
        
        public string Details { get; set; }

        /// <summary>
        /// 同步上架线上商城
        /// </summary>
        public bool IsSyncEmOnline { get; set; }

        public decimal EmOnlinePrice { get; set; }

        public int CarriageCostTemplateID { get; set; }
    }
}

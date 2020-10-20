using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class CarriageCost
    {
        public EmCarriageCostTemplate CarriageCostTemplate { get; set; }

        public List<EmCarriageCostDetail> CarriageCostDetails { get; set; }
    }

    public class CarriageCostTemplatePagePara : BasePagePara
    {
        public string Name { get; set; }

        /// <summary>
        /// -1:全部，0：无效，1：有效
        /// </summary>
        public int IsValid { get; set; }
    }

    public class CarriageCostTemplatePage : BasePage
    {
        public List<EmCarriageCostTemplate> CarriageCostTemplates { get; set; }
    }
}

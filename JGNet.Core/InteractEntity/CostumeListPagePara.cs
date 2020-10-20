using JGNet.Core.MyEnum;
using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CostumeListPagePara : BasePagePara
    {
        /// <summary>
        /// id精确查询，忽略其他条件
        /// </summary>
        public bool IdAccurate { get; set; }

        public string CostumeID { get; set; }

        public bool IsPos { get; set; }


        public int Year { get; set; }

        public string Season { get; set; }

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

        /// <summary>
        /// 属性
        /// </summary>
        public CostumeProperty Property { get; set; }

        public string SupplierID { get; set; }

        public string Models { get; set; }

        public string Style { get; set; }

        /// <summary>
        /// 查询类型
        /// </summary>
        public IsQueryValid IsQueryValid { get; set; }

        public bool IsOpenTime { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public enum IsQueryValid
    {
        /// <summary>
        /// 所有
        /// </summary>

        [Description("所有")]
        All = -1,

        /// <summary>
        /// 只列出有效
        /// </summary>
        [Description("正常")]
        True,

        /// <summary>
        /// 只列出无效
        /// </summary>
        [Description("禁用")]
        False
    }

    [Serializable]
    public class CostumeListPage : BasePage
    {
        public List<Costume> CostumeList { get; set; }
         
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class EmPfCostumePage : BasePage
    {
        public List<Costume> Costumes { get; set; }
    }

    public class GetEmPfCostumePagePara : BasePagePara
    {
        public string ID { get; set; }

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

        public bool IsOnline { get; set; }

        /// <summary>
        /// 只列推荐
        /// </summary>
        public bool IsOnlyShowHot { get; set; }

        public bool IsOnlyShowNew { get; set; }
    }
}

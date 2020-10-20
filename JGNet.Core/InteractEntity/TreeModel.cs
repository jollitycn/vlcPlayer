using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class TreeModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string ParentID { get; set; }

        public decimal AccruedCommission { get; set; }

        /// <summary>
        /// 子节点集合
        /// </summary>
        public List<TreeModel> Childrens { get; set; }

        public string Phone { get; set; }
    }
}

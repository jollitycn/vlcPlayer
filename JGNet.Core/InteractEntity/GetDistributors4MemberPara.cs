using JGNet.Core.MyEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetDistributors4MemberPara
    {
        public string Phone { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// -1:所有，-2：从未消费
        /// </summary>
        public int NoRetailDay { get; set; }

        public SeeCommission SeeCommission { get; set; }
    }

    public enum SeeCommission
    {
        /// <summary>
      /// 查询所有
      /// </summary>
        [Description("所有")]
        All,
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("允许")]
        True,
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("禁止")]
        False
    }

    public class GetPfDistributorsPara
    {
        public string ID { get; set; }

        public CustomerType CustomerType { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// -1:所有，-2：从未消费
        /// </summary>
        public int NoRetailDay { get; set; }

        public SeeCommission SeeCommission { get; set; }
    }
}

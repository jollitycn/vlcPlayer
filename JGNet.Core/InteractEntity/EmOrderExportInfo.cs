using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class EmOrderExportInfo
    {
        /// <summary>
        /// 渠道编号
        /// </summary>
        public string ChannelID { get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 分账编号
        /// </summary>
        public string LedgerAccountID { get; set; }

        /// <summary>
        /// 分账名称
        /// </summary>
        public string LedgerAccountName { get; set; }

        public override string ToString()
        {
            return string.Format("{0}#{1}#{2}#{3}#{4}#{5}", this.ChannelID, this.ChannelName, this.WarehouseID, this.WarehouseName, this.LedgerAccountID, this.LedgerAccountName);
        }

        public static EmOrderExportInfo Parsing(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new EmOrderExportInfo();
            }
            string[] strs = value.Split('#');
            return new EmOrderExportInfo()
            {
                ChannelID = strs[0],
                ChannelName = strs[1],
                WarehouseID = strs[2],
                WarehouseName = strs[3],
                LedgerAccountID = strs[4],
                LedgerAccountName = strs[5]
            };
        }
    }

    public class EmOrderExportData
    {
        public EmOrderExportInfo EmOrderExportInfo { get; set; }

        public DateTime OrderTime { get; set; }

        public string OrderUserID { get; set; }

        public string OrderUserName { get; set; }

        public List<EmOrderExportDetail> Details { get; set; }

        public EmOrderExportDetail Sum { get; set; }
    }

    public class EmOrderExportDetail
    {
        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string ColorID { get; set; }

        public string ColorName { get; set; }

        public int XS { get; set; }

        public int S { get; set; }

        public int M { get; set; }

        public int L { get; set; }

        public int XL { get; set; }

        public int XL2 { get; set; }

        public int XL3 { get; set; }

        public int XL4 { get; set; }

        public int XL5 { get; set; }

        public int XL6 { get; set; }

        public int F { get; set; }

        public int Count { get => this.XS + this.S + this.M + this.L + this.XL + this.XL2 + this.XL3 + this.XL4 + this.XL5 + this.XL6 + this.F; }

        /// <summary>
        /// 通知数
        /// </summary>
        public int NoticeCount { get; set; }

        /// <summary>
        /// 差异数
        /// </summary>
        public int DifferenceCount { get; set; }

        /// <summary>
        /// 标准价
        /// </summary>
        public decimal OnlinePrice { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 单价(标准价 * 折扣)
        /// </summary>
        public decimal Price { get; set; }

        public decimal SumMoney { get => this.Price * this.Count; }

        public string Remarks { get; set; }
    }
}

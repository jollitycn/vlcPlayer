using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GuideReturnVisitPara
    {
        /// <summary>
        /// 销售回访
        /// </summary>
        public int Retail { get; set; }
        
        /// <summary>
        /// 生日提前提醒天数
        /// </summary>
        public int BirthdayAdvanceRemind { get; set; }

        /// <summary>
        /// 活跃客户消费天数
        /// </summary>
        public int ActiveMember { get; set; }

        /// <summary>
        /// 纪念日提前提醒天数
        /// </summary>
        public int AnniversaryAdvanceRemind { get; set; }

        /// <summary>
        /// 流失客户消费天数
        /// </summary>
        public int LossMember { get; set; }

        public override string ToString()
        {
            return string.Format("XS-{0},SRTX-{1},HYXF-{2},JNR-{3},LSXF-{4}", this.Retail, this.BirthdayAdvanceRemind, this.ActiveMember, this.AnniversaryAdvanceRemind, this.LossMember);
        }

        public void AnalyticalString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            string[] strs = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            this.Retail = this.AnalyticalPara(strs[0]);
            this.BirthdayAdvanceRemind = this.AnalyticalPara(strs[1]);
            this.ActiveMember = this.AnalyticalPara(strs[2]);
            this.AnniversaryAdvanceRemind = this.AnalyticalPara(strs[3]);
            this.LossMember = this.AnalyticalPara(strs[4]);
        }

        private int AnalyticalPara(string str)
        {
            return int.Parse(str.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1]);
        }
    }
}

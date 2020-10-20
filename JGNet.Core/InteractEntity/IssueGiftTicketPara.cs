using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class IssueGiftTicketPara
    {
        public List<string> MemberIDs { get; set; }

        public int GiftTicketTemplateID { get; set; }

        /// <summary>
        /// 发放数量
        /// </summary>
        public int IssueCount { get; set; }
        
        public Date EffectDate { get; set; }

        public Date ExpiredDate { get; set; }

        public string Remarks { get; set; }

        public string OperatorUserID { get; set; }
    }
}

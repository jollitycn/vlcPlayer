using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class SignRecordPagePara : BasePagePara
    {
        public string ShopID { get; set; }

        public string GuideID { get; set; }

        public SignType SignType { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
        
    }

    public class SignRecordPage : BasePage
    {
        public List<SignRecord> SignRecords { get; set; }
         
        public SignRecord SignRecordSum { get; set; }
    }
}

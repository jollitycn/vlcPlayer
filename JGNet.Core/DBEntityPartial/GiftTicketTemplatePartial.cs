using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{ 
	public partial class GiftTicketTemplate  
	{
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String OperatorUserName { get; set; }

        public String DenominationAndTickDesc
        {
            get { return this.Denomination + "-" + this.TicketDescription; }
        }

    }
}

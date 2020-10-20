using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class BusinessAccount
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int WillExpiredDay
        {
            get
            {
                DateTime now = DateTime.Now;
                return this.ExpiredDate.Subtract(new DateTime(now.Year, now.Month, now.Day)).Days;
            }
        } 
    }
}

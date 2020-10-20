using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core
{
    public class GiftTicketMatch
    {
        public GiftTicket Ticket { get; set; }
        public RetailDetail Retail { get; set; }

        public override string ToString()
        {
            String str = "[";
            str += Retail.CostumeID + " ";
            // str += Retail.Discount + " ";
            //str += Retail.SumMoney / Retail.BuyCount + " ";
            if (Ticket != null)
            {
                str += Ticket.Denomination + " ";
                //    str += Ticket.ExpiredDate + " ";
            }
            str += "]";
            return str;
        }
        /// <summary>
        /// 获取满足条件之后的金额信息
        /// </summary>
        /// <returns></returns>
        public int DiscountMoney()
        { 
            if (Ticket != null)
            {
                if (Ticket.IsAnd)
                {
                    // if (Ticket.MinDiscount!=0 && Ticket.MinDiscount <= Retail.Discount && Ticket.MinMoney !=0 &&  Ticket.MinMoney <= Retail.SumMoney)
                    if (  Ticket.MinDiscount <= Retail.Discount && Ticket.MinMoney != 0 && Ticket.MinMoney <= Retail.SumMoney)
                    {
                        //满足条件 
                        return Ticket.Denomination;
                    }
                    else {
                        return 0;
                    }
                }
                else
                {
                    // if (Ticket.MinDiscount !=0 && Ticket.MinDiscount <= Retail.Discount)
                    if (  Ticket.MinDiscount <= Retail.Discount)
                    {
                        //满足条件 
                        return Ticket.Denomination;
                    }
                    if (Ticket.MinMoney !=0 &&  Ticket.MinMoney <= Retail.SumMoney)
                    {
                        //满足条件
                        return Ticket.Denomination;
                    }
                }
            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Tools
{
    public static class GiftTicketHelper
    {
        public static string GetTicketDescription(int denomination, int minMoney, decimal minDiscount, bool isAnd)
        {
            string ticketDescription = "";
            if (minMoney != 0)
            {
                ticketDescription = "售价满" + minMoney + "元";
            }
            if (minDiscount != 0)
            {
                if (ticketDescription != "")
                {
                    if (isAnd)
                    {
                        ticketDescription += "并且";
                    }
                    else
                    {
                        ticketDescription += "或者";
                    }
                }
                minDiscount = minDiscount / 10;
                if (minDiscount == 10)
                {
                    ticketDescription += "正价";
                }
                else
                {
                    ticketDescription += ("折扣高于" + minDiscount + "折");
                }
                
            }
            if (ticketDescription != "")
            {
                return ticketDescription + "减" + denomination + "元/件";
            }
            return "";
        }

        public static string GetEmTicketDescription( int minMoney, decimal minDiscount, bool isAnd)
        {
            string ticketDescription = "";
            if (minMoney != 0)
            {
                ticketDescription = "满" + minMoney;
            }
            if (minDiscount != 0)
            {
                if (ticketDescription != "")
                {
                    if (isAnd)
                    {
                        ticketDescription += " 且 ";
                    }
                    else
                    {
                        ticketDescription += " 或 ";
                    }
                }
                minDiscount = minDiscount / 10;
                if (minDiscount == 10)
                {
                    ticketDescription += "原价";
                }
                else
                {
                    ticketDescription += ("满" + Math.Round(minDiscount,1, MidpointRounding.AwayFromZero) + "折");
                }

            }
            return ticketDescription;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core
{
    /// <summary>
    /// 个体
    /// </summary>
    public class GiftTicketIndividual
    {

        static int defaultGeneLength = 64;
        /// <summary>
        /// 基因
        /// </summary>
        private GiftTicketMatch[] genes = new GiftTicketMatch[defaultGeneLength];
        private int fitness = 0;

        public GiftTicketMatch[] GiftTicketMatches { get { return genes; } }

        //可以用于检测剩余的商品，一般没有剩余
        private List<RetailDetail> retails = new List<RetailDetail>();
        //可以检测是否还有剩余的优惠券，如果有，可以支持变异，抽取剩余的进行变异，把原来的优惠券放回来供后面的其他使用，达到同步性
        public List<GiftTicket> tickets = new List<GiftTicket>();
        public List<RetailDetail> RetailsOrg { get; set; }
        public List<GiftTicket> TicketsOrg { get; set; }
        // 随机的个体
        public void GenerateIndividual(List<RetailDetail> retailsOrg, List<GiftTicket> ticketsOrg)
        {
            this.RetailsOrg = retailsOrg;
            this.TicketsOrg = ticketsOrg;
            retails = new List<RetailDetail>();
            tickets = new List<GiftTicket>();
            retails.AddRange(retailsOrg);
            tickets.AddRange(ticketsOrg);


            for (int i = 0; i < retailsOrg.Count; i++)
            {
                //Random randomDetail = new Random(GlobalUtil.GetRandomSeed());
                //int randomDetailIndex = random.Next(0, retails.Count);

                RetailDetail retail = retailsOrg[i];
                //随机拿一张优惠券
                Random random = new Random(GetRandomSeed());
                GiftTicket ticket = null;
                if (tickets.Count > 0)
                {
                    int pickTicket = random.Next(0, tickets.Count);
                    ticket = tickets[pickTicket];
                }
                SetMatch(i, retail, ticket);
                // int pickTicket = (int)(new Random().NextDouble() * tickets.Count);




                //是否考虑到，优惠券被占用的条件，被占用的话，这个是无效的适应度

            }
        }

        public void SetMatch(int i, GiftTicketMatch match, GiftTicket newTicket)
        { //如果是款号有匹配的优惠券则完成匹配，否则，设置为空，那么优惠券就保留。
            if (String.IsNullOrEmpty(match.Retail.GiftTickets))
            {
                match.Ticket =null;
                genes[i] = match;
            }
            else
            {
                //款号有匹配的优惠券
                String[] retailMatchTickets = match.Retail.GiftTickets.Split(',');
                List<String> retailMatchTicketList = new List<string>(retailMatchTickets);
                if (newTicket != null)
                {
                    if (retailMatchTicketList.Contains(newTicket.ID))
                    {
                        //匹配到了
                        tickets.Add(match.Ticket);
                        match.Ticket = newTicket;
                        tickets.Remove(newTicket);
                        genes[i] = match;
                    }
                    else
                    {
                        tickets.Add(match.Ticket);
                        match.Ticket = null;
                        genes[i] = match;
                    }
                }
            }
        }

        private void SetMatch(int i, RetailDetail retail, GiftTicket ticket)
        {

            if (ticket == null)
            {
              //优惠券不够用了
                genes[i] = new GiftTicketMatch()
                {
                    Retail = retail,
                    Ticket = null
                };
                retails.Remove(retail);
            }

            //如果是款号有匹配的优惠券则完成匹配，否则，设置为空，那么优惠券就保留。
            else if (String.IsNullOrEmpty(retail.MatchGiftTickets))
            {
                //该款号没有匹配的优惠券。
                genes[i] = new GiftTicketMatch()
                {
                    Retail = retail,
                    Ticket = null
                };
                retails.Remove(retail);
            }
            else
            {
                //款号有匹配的优惠券
                String[] retailMatchTickets = retail.MatchGiftTickets.Split(',');
                List<String> retailMatchTicketList = new List<string>(retailMatchTickets);
                if (retailMatchTicketList.Contains(ticket.ID))
                {
                    //匹配到了
                    genes[i] = new GiftTicketMatch()
                    {
                        Retail = retail,
                        Ticket = ticket
                    };
                    retails.Remove(retail);
                    tickets.Remove(ticket);

                }
                else
                {
                    genes[i] = new GiftTicketMatch()
                    {
                        Retail = retail,
                        Ticket = null
                    };
                    retails.Remove(retail);
                }
            }
        }

        // Use this if you want to create individuals with different gene Lengths
        public static void SetDefaultGeneLength(int Length)
        {
            defaultGeneLength = Length;
        }

        public GiftTicketMatch GetGene(int index)
        {
            return genes[index];
        }

        public void SetGene(int index, GiftTicketMatch value)
        {
            List<GiftTicket> tickets = new List<GiftTicket>();
            tickets.AddRange(TicketsOrg);
            //如果
            for (int i = 0; i < genes.Length; i++)
            {
                if (index != i)
                {
                    if (genes[i] != null)
                    {
                        tickets.Remove(genes[i].Ticket);
                    }
                }
            }

            if (tickets.Exists(t => t.ID == value.Ticket?.ID))
            {
                //优惠券没有被占用，可以使用
                genes[index] = value;
                fitness = 0;
            }
            else
            {
                //重新查找新的优惠券匹配
                GiftTicket ticket = null;
                if (tickets.Count > 0) { 
               Random random = new Random(GetRandomSeed());
                int pickTicket = random.Next(0, tickets.Count);
                    //  int pickTicket = (int)(new Random().NextDouble() * tickets.Count);
                    //随机拿一张优惠券
                    ticket = tickets[pickTicket];
                }
                SetMatch(index, value, ticket);
                fitness = 0;
            }
        }
        private int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public int Size()
        {
            return genes.Length;
        }

        public int GetFitness()
        {
            if (fitness == 0)
            {
                fitness = GiftTicketFitnessCalc.GetFitness(this);
            }
            return fitness;
        }


        public override String ToString()
        {
            String geneString = "";
            for (int i = 0; i < Size(); i++)
            {
                geneString += GetGene(i);
            }
            return geneString;
        }
    }

}

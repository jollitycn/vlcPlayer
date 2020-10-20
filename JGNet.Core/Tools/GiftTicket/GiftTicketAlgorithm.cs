using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core

{
    public class GiftTicketAlgorithm
    {

        //配置项
        private const double uniformRate = 0.5;
        private const double mutationRate = 0.015;
        private const int tournamentSize = 5;
        private const bool elitism = true;

        public static List<RetailDetail> RetailDetails { get; set; }
        public static List<GiftTicket> Tickets { get; set; }
        // 进化一个种群
        public static GiftTicketPopulation EvolvePopulation(GiftTicketPopulation pop)
        {
            GiftTicketPopulation newPopulation = new GiftTicketPopulation(pop.Size(), false);

            // 保留最优秀的个体
            if (elitism)
            {
                newPopulation.SaveIndividual(0, pop.GetFittest());
            }
            // 交叉种群
            int elitismOffset;
            if (elitism)
            {
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }
            // 交叉产生新的个体
            for (int i = elitismOffset; i < pop.Size(); i++)
            {
            //    Console.WriteLine("交叉产生新个体");
                //确保不要把最差的个体选进来
                GiftTicketIndividual indiv1 = TournamentSelection(pop);
                GiftTicketIndividual indiv2 = TournamentSelection(pop);
                GiftTicketIndividual newIndiv = Crossover(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            // 变异
            for (int i = elitismOffset; i < newPopulation.Size(); i++)
            {
                Mutate(newPopulation.GetIndividual(i));
            }

            return newPopulation;
        }

        // 交叉
        private static GiftTicketIndividual Crossover(GiftTicketIndividual indiv1, GiftTicketIndividual indiv2)
        {
          //  Console.WriteLine("交叉");
            GiftTicketIndividual newSol = new GiftTicketIndividual();
            newSol.RetailsOrg = GiftTicketAlgorithm.RetailDetails;
            newSol.TicketsOrg = GiftTicketAlgorithm.Tickets;
            // Loop through genes
            for (int i = 0; i < indiv1.Size(); i++)
            {
                // 以一定概率交叉,如果优惠券被占用了？？？那么交叉完了之后这个优惠券就变成空？
                if (new Random().NextDouble() <= uniformRate)
                {
                    //检查优惠券是否被占用？如果被占用是否还有可以替换的优惠券使用？有就替换掉？
                  
                    newSol.SetGene(i, indiv1.GetGene(i));
                }
                else
                {
                    newSol.SetGene(i, indiv2.GetGene(i));
                }
            }
            return newSol;
        }

        // 变异
        private static void Mutate(GiftTicketIndividual indiv)
        {
            // Console.WriteLine("变异");
            // Loop through genes
            for (int i = 0; i < indiv.Size(); i++)
            {
                if (new Random().NextDouble() <= mutationRate)
                {
                    //从剩余的优惠券中，随机一个优惠券
                    GiftTicketMatch gene = indiv.GetGene(i);
                    GiftTicket ticket = null;
                    if (indiv.tickets.Count > 0)
                    {
                        Random random = new Random(GetRandomSeed());
                        int pickTicket = random.Next(0, indiv.tickets.Count);

                        //    int pickTicket = (int)(new Random().NextDouble() * indiv.tickets.Count);
                        ticket = indiv.tickets[pickTicket];
                        indiv.SetMatch(i, gene, ticket);
                    }
                }
            }
        }

        private static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        // 选择用于交叉的个体，确保最差的个体不会进来
        private static GiftTicketIndividual TournamentSelection(GiftTicketPopulation pop)
        {
            GiftTicketPopulation tournament = new GiftTicketPopulation(tournamentSize, false);
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(new Random().NextDouble() * pop.Size());
                tournament.SaveIndividual(i, pop.GetIndividual(randomId));
            }
            GiftTicketIndividual fittest = tournament.GetFittest();
            return fittest;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core
{
    /// <summary>
    /// 种群
    /// </summary>
    public class GiftTicketPopulation
    {
        public override String ToString()
        {
            String geneString = "{";
            for (int i = 0; i < individuals.Length; i++)
            {
                geneString += individuals[i] + ",";
            }
            geneString += "}";
            return geneString;
        }

        GiftTicketIndividual[] individuals;
        // 建立一个总群
        public GiftTicketPopulation(int populationSize, bool initialise)
        {
            individuals = new GiftTicketIndividual[populationSize];
            // 初始化种群
            if (initialise)
            {
                // 建立每一个个体
                for (int i = 0; i < Size(); i++)
                {
                    GiftTicketIndividual newIndividual = new GiftTicketIndividual();
                    newIndividual.GenerateIndividual(GiftTicketAlgorithm.RetailDetails, GiftTicketAlgorithm.Tickets);
                    SaveIndividual(i, newIndividual);
                }
            }
        }

        public GiftTicketIndividual GetIndividual(int index)
        {
            return individuals[index];
        }

        public GiftTicketIndividual GetFittest()
        {
            GiftTicketIndividual fittest = individuals[0];
            // 取得适应度最高的个体作为种群的适应度
            for (int i = 0; i < Size(); i++)
            {
                if (fittest.GetFitness() <= GetIndividual(i).GetFitness())
                {
                    fittest = GetIndividual(i);
                }
            }
            return fittest;
        }

        // Get population size
        public int Size()
        {
            return individuals.Length;
        }

        // Save individual
        public void SaveIndividual(int index, GiftTicketIndividual indiv)
        {
            individuals[index] = indiv;
        }
    }
}

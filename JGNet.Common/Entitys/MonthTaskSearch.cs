using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common.Entitys
{
    public class MonthTaskSearch
    {

        public List<MonthTask> MonthTasks { get; set; }
        public String ShopName { get { return Shop.Name; } }
        public int Year { get; set; }
        public Shop Shop { get; set; }
        public decimal Target1 { get; set; }
        public decimal Target2 { get; set; }
        public decimal Target3 { get; set; }
        public decimal Target4 { get; set; }
        public decimal Target5 { get; set; }
        public decimal Target6 { get; set; }
        public decimal Target7 { get; set; }
        public decimal Target8 { get; set; }
        public decimal Target9 { get; set; }

        public decimal Target10 { get; set; }

        public decimal Target11 { get; set; }

        public decimal Target12 { get; set; }
        public int AutoID1 { get; set; }
        public int AutoID2 { get; set; }
        public int AutoID3 { get; set; }
        public int AutoID4 { get; set; }
        public int AutoID5 { get; set; }
        public int AutoID6 { get; set; }
        public int AutoID7 { get; set; }
        public int AutoID8 { get; set; }
        public int AutoID9 { get; set; }
        public int AutoID10 { get; set; }
        public int AutoID11 { get; set; }
        public int AutoID12 { get; set; }
    }
}

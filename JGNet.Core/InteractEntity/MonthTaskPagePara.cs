using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class MonthTaskPagePara : BasePagePara
    {
        public string ShopID { get; set; }
        public int Year { get; set; }
    }

    public class MonthTaskPage : BasePage
    {
        public List<MonthTask> MonthTasks { get; set; }
         
    }
}

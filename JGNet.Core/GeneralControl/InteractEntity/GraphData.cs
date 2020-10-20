using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    /// <summary>
    /// 曲线图表数据
    /// </summary>
    [Serializable]    
    public class GraphData
    {
        public string Key { get; set; }

        public decimal Value { get; set; }
    }

    [Serializable]
    public class WxChartsData
    {
        public List<string> Keys { get; set; }
        public List<WxChartsSeries> Series { get;set;}
    }
    [Serializable]
    public class WxChartsSeries
    {
        public string Name { get; set; }
        public List<decimal> Data { get; set; }
    }
}

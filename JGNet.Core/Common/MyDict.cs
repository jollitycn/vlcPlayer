using JGNet.Core.Const;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Server.Common
{
    [Serializable]
    public class MyDict<T> where T : new()
    {
        #region string_string_string_T
        private Dictionary<string, Dictionary<string, Dictionary<string, T>>> datas = new Dictionary<string, Dictionary<string, Dictionary<string, T>>>();

        public T GetReportData(string shopID, string key1, string key2)
        {
            if (!this.datas.ContainsKey(shopID))
            {
                this.datas.Add(shopID, new Dictionary<string, Dictionary<string, T>>());
            }

            if (!this.datas[shopID].ContainsKey(key1))
            {
                this.datas[shopID].Add(key1, new Dictionary<string, T>());
            }

            if (!this.datas[shopID][key1].ContainsKey(key2))
            {
                this.datas[shopID][key1].Add(key2, new T());
            }

            return this.datas[shopID][key1][key2];
        }

        public Dictionary<string, Dictionary<string, Dictionary<string, T>>> GetDatas()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, T>>>(this.datas);
        }

        public List<T> GetStr_Str_Str_Ts()
        {
            List<T> list = new List<T>();
            foreach (var item in this.datas)
            {
                Dictionary<string, Dictionary<string, T>> temp = item.Value;
                foreach (var item1 in temp)
                {
                    list.AddRange(item1.Value.Values);
                }
            }
            return list;
        }
        #endregion

        #region string_string_TDict
        private Dictionary<string, Dictionary<string, T>> string_string_TDict = new Dictionary<string, Dictionary<string, T>>();

        public T GetReportData(string key1, string key2)
        {
            if (!this.string_string_TDict.ContainsKey(key1))
            {
                this.string_string_TDict.Add(key1, new Dictionary<string, T>());
            }

            if (!this.string_string_TDict[key1].ContainsKey(key2))
            {
                this.string_string_TDict[key1].Add(key2, new T());
            }
            return this.string_string_TDict[key1][key2];
        }

        public Dictionary<string, Dictionary<string, T>> GetStr_Str_TDict()
        {
            return new Dictionary<string, Dictionary<string, T>>(this.string_string_TDict);
        }
        #endregion

        #region int_string_T
        private Dictionary<int, Dictionary<string, T>> int_string_TDict = new Dictionary<int, Dictionary<string, T>>();

        public T GetReportData(int _int, string _string)
        {
            if (!this.int_string_TDict.ContainsKey(_int))
            {
                this.int_string_TDict.Add(_int, new Dictionary<string, T>());
            }

            if (!this.int_string_TDict[_int].ContainsKey(_string))
            {
                this.int_string_TDict[_int].Add(_string, new T());
            }
            return this.int_string_TDict[_int][_string];
        }
        
        public Dictionary<int, Dictionary<string, T>> GetInt_String_TDict()
        {
            return new Dictionary<int, Dictionary<string, T>>(this.int_string_TDict);
        }
        #endregion
        
    }

    [Serializable]
    public class CostumeStoreSummaryInfo
    {
        public CostumeStoreSummaryInfo()
        {
            this.FirstInboundTime = SystemDefault.DateTimeNull;
        }

        /// <summary>
        /// 剩余库存总数
        /// </summary>
        public int SummaryCount { get; set; }

        /// <summary>
        /// 总的销量
        /// </summary>
        public int QuantityOfSale { get; set; }

        /// <summary>
        /// 总的销售总额
        /// </summary>
        public decimal MoneyOfSale { get; set; }

        //public double SellThroughRate
        //{
        //    get
        //    {
        //        decimal sum = QuantityOfSale + SummaryCount;
        //        if (sum == 0)
        //        {
        //            return 0;
        //        }
        //        return (double)MathHelper.Rounded(QuantityOfSale / sum, 2);
        //    }
        //}

        /// <summary>
        /// 第一次入库时间
        /// </summary>
        public DateTime FirstInboundTime { get; set; }
    }
}

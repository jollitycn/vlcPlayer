using JGNet.Core.InteractEntity;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class PrintTemplate
    {
        public List<PrintColumnInfo> PrintColumnInfos
        {
            get
            {
                List<PrintColumnInfo> info = new List<PrintColumnInfo>();
                if (!string.IsNullOrEmpty(this.ColumnName))
                {
                    List<string> strs = DataHelper.StringToList(this.ColumnName);
                    foreach (string str in strs)
                    {
                        string[] value = str.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        PrintColumnInfo printColumnInfo = new PrintColumnInfo()
                        {
                            Name = value[0],
                            Rate = decimal.Parse(value[1])
                        };
                        info.Add(printColumnInfo);
                    }
                }
                return info;
            }
        }

        public List<string> SystemVariables
        {
            get
            {
                return DataHelper.StringToList(this.SystemVariable);
            }
        }
    }
}

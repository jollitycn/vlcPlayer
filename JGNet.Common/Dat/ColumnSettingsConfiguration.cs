using DataRabbit;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    public class ColumnSettingsConfiguration : CJBasic.Serialization.AgileConfiguration
    {
        public List<ColumnSetting> Columns { get; set; } 
    }

    [Serializable] 
    public class ColumnSetting{
        public Boolean Enabled { get; set; }
        public Boolean Visible { get; set; }
        public String HeaderText { get; set; }
        public String HeaderID { get; set; }
        public int HeaderIndex{ get; set; }
        public int Width { get; set; }
        public int ColWidth { get; set; } 
    } 
}

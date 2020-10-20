using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    [Serializable]
    public class OptionConfiguration : CJBasic.Serialization.AgileConfiguration
    {
        ///// <summary>
        ///// 为零时在报表显示
        ///// </summary>
        public const String OPTION_CONFIGURATION_KEY_REPORT_SHOW_ZERO = "REPORT_SHOW_ZERO";
        /// <summary>
        /// 结算时是否四舍五入
        /// </summary>
     //   public const String OPTION_CONFIGURATION_KEY_BALANCE_ROUND = "BALANCE_ROUND";
        /// <summary>
        /// 盘点时显示差异
        /// </summary>
        public const String OPTION_CONFIGURATION_KEY_DIFFERENT_IN_CHECKSTORE = "DIFFERENT_IN_CHECKSTORE";
        public const String OPTION_CONFIGURATION_KEY_OUT_NOT_ZEROSTORE = "OUT_NOT_ZEROSTORE";
         
        private const String OPTION_CONFIGURATION_PATH = "COMMON.OPTIONS";
        public static Option GetOptionSetting(String optionKey)
        {
            OptionConfiguration config = null;
            try
            {
                config = Load();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
            return config?.Options?.Find(t => t.Key == optionKey);
        }

        public static OptionConfiguration Load() {
            return OptionConfiguration.Load(GetConfigPath()) as OptionConfiguration; 
        }
        public void Save()
        {
             this.Save(GetConfigPath());
        }
        public static String GetConfigPath() {
            return CommonGlobalUtil.AgileConfiguration(OPTION_CONFIGURATION_PATH);
        }
        public List<Option> Options { get; set; }


    }
    public class Option
    {
        public Option() { }
        public Option(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
        public String Key { get; set; }
        public String Value { get; set; }
    }
}

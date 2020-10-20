using JGNet.Core.Common;
using JGNet.Core.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Tools
{
    public class BarCodeInfo
    {
        /// <summary>
        /// 年份，比如2019年:19
        /// </summary>
        public string Year { get; set; }
        
        public string FlowNumber { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public static BarCodeInfo Parsing(string value)
        {
            if (value.Length != 15)
            {
                throw new MyException("条形码长度必须为15位");
            }
            return new BarCodeInfo()
            {
                Year = value.Substring(0, 2),
                FlowNumber = value.Substring(2, 8),
                ColorName = value.Substring(10, 3),
                SizeName = value.Substring(13, 2)
            };
        }

        public static string GetCostumeBarCode(string value)
        {
            if (value.Length != 15)
            {
                throw new MyException("条形码长度必须为15位");
            }
            return value.Substring(0, 10) + "00000";
        }

        public string GetBarCode()
        {
            if (this.Year.Length != 2)
            {
                throw new MyException("年分长度必须为2位");
            }
            if (this.FlowNumber.Length != 8)
            {
                throw new MyException("流水号长度必须为8位");
            }
            this.ColorName = this.ColorName.PadLeft(3, '0');
            if (this.ColorName.Length != 3)
            {
                throw new MyException("颜色长度必须为3位");
            }
            if (this.SizeName.Length != 2)
            {
                throw new MyException("尺码长度必须为2位");
            }
            return string.Format("{0}{1}{2}{3}", this.Year, this.FlowNumber, this.ColorName, this.SizeName);
        }
    }

    public static class BarCodeSizeName
    {
        private const string XSCode = "01";
        private const string SCode = "02";
        private const string MCode = "03";
        private const string LCode = "04";
        private const string XLCode = "05";
        private const string XL2Code = "06";
        private const string XL3Code = "07";
        private const string XL4Code = "08";
        private const string XL5Code = "09";
        private const string XL6Code = "10";
        private const string FCode = "11";

        private static Dictionary<string, string> CodeDict = new Dictionary<string, string>()
        {
            { CostumeSize.XS, BarCodeSizeName.XSCode }, { CostumeSize.S, BarCodeSizeName.SCode }, { CostumeSize.M, BarCodeSizeName.MCode }, { CostumeSize.L, BarCodeSizeName.LCode },
            { CostumeSize.XL, BarCodeSizeName.XLCode }, { CostumeSize.XL2, BarCodeSizeName.XL2Code }, { CostumeSize.XL3, BarCodeSizeName.XL3Code }, { CostumeSize.XL4, BarCodeSizeName.XL4Code },
            { CostumeSize.XL5, BarCodeSizeName.XL5Code }, { CostumeSize.XL6, BarCodeSizeName.XL6Code }, { CostumeSize.F, BarCodeSizeName.FCode }
        };

        private static Dictionary<string, string> SizeNameDict = new Dictionary<string, string>()
        {
            { BarCodeSizeName.XSCode, CostumeSize.XS }, { BarCodeSizeName.SCode, CostumeSize.S }, { BarCodeSizeName.MCode, CostumeSize.M }, { BarCodeSizeName.LCode, CostumeSize.L },
            { BarCodeSizeName.XLCode, CostumeSize.XL }, { BarCodeSizeName.XL2Code, CostumeSize.XL2 }, { BarCodeSizeName.XL3Code, CostumeSize.XL3 }, { BarCodeSizeName.XL4Code, CostumeSize.XL4 },
            { BarCodeSizeName.XL5Code, CostumeSize.XL5 }, { BarCodeSizeName.XL6Code, CostumeSize.XL6 }, { BarCodeSizeName.FCode, CostumeSize.F }
        };

        public static string GetSizeName(string code)
        {
            if (BarCodeSizeName.SizeNameDict.ContainsKey(code))
            {
                return BarCodeSizeName.SizeNameDict[code];
            }
            return code;
        }

        public static string GetCode(string sizeName)
        {
            if (BarCodeSizeName.CodeDict.ContainsKey(sizeName))
            {
                return BarCodeSizeName.CodeDict[sizeName];
            }
            return sizeName;
        }
    } 

    [Serializable]
    public class BarCode4Costume
    {
        public string CostumeID { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }
        
        public string BarCode { get; set; }
    }

    public class BarCode4CostumeInfo : BarCode4Costume
    {
        public string BarCode { get; set; }

        public string BrandName { get; set; }

        public string BrandNamePY { get; set; }

        public string CostumeName { get; set; }

        public string ClassName { get; set; }

        public string Remarks { get; set; }

        public decimal SalePrice { get; set; }
    }
}

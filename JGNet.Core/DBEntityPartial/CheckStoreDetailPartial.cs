using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CheckStoreDetail:IStatisticabled
    {
        public int DateInt { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        public String CostumeName { get; set; }
        public String BrandName { get; set; }
        public String BrandID { get; set; }

        public SizeGroup SizeGroup { get; set; }

        public List<string> SizeNameList { get; set; }

        private int sumCount = 0;
        public int Index { get; set; }
        /// <summary>
        /// 同款号同颜色所有尺码衣服的数量总和
        /// </summary>
        public bool HasNoDiff
        {
            get
            {
                return this.XS == 0 && this.S == 0
               && this.M == 0 && this.L == 0 && this.XL == 0 &&
                this.XL2 == 0 && this.XL3 == 0 && this.XL4 == 0 &&
                this.XL5 == 0 && this.XL6 == 0 && this.F == 0;
            }
        }

        public bool HasNoDiffAtm
        {
            get
            {
                return this.XSAtm == 0 && this.SAtm == 0
               && this.MAtm == 0 && this.LAtm == 0 && this.XLAtm == 0 &&
                this.XL2Atm == 0 && this.XL3Atm == 0 && this.XL4Atm == 0 &&
                this.XL5Atm == 0 && this.XL6Atm == 0 && this.FAtm == 0;
            }
        }


        public bool Selected { get; set; }
        private bool isShow = true;
        public bool IsShow { get { return isShow; } set { isShow = value; } }
        public bool ShowSelected { get; set; }
        /// <summary>
        /// 同款号同颜色所有尺码衣服的数量总和
        /// </summary>
        public int SumCount
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.XS + this.S + this.M + this.L + this.XL + this.XL2 + this.XL3 + this.XL4 + this.XL5 + this.XL6 + this.F;
                }
                return this.sumCount;
            }
            set
            {
                this.sumCount = value;
            }
        }

        private int sumCountAtm = 0;

        public int SumCountAtm
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.XSAtm + this.SAtm + this.MAtm + this.LAtm + this.XLAtm + this.XL2Atm + this.XL3Atm + this.XL4Atm + this.XL5Atm + this.XL6Atm + this.FAtm;
                }
                return this.sumCountAtm;
            }
            set
            {
                this.sumCountAtm = value;
            }
        }

        private int sumCountLost = 0;

        public int SumCountLost
        {
            get
            {
                if (!this.IsStatistics)
                {
                    sumCountLost = 0;
                    sumCountLost += this.XSWinLost < 0 ? this.XSWinLost : 0;
                    sumCountLost += this.SWinLost < 0 ? this.SWinLost : 0;
                    sumCountLost += this.MWinLost < 0 ? this.MWinLost : 0;
                    sumCountLost += this.LWinLost < 0 ? this.LWinLost : 0;
                    sumCountLost += this.XLWinLost < 0 ? this.XLWinLost : 0;
                    sumCountLost += this.XL2WinLost < 0 ? this.XL2WinLost : 0;
                    sumCountLost += this.XL3WinLost < 0 ? this.XL3WinLost : 0;
                    sumCountLost += this.XL4WinLost < 0 ? this.XL4WinLost : 0;
                    sumCountLost += this.XL5WinLost < 0 ? this.XL5WinLost : 0;
                    sumCountLost += this.XL6WinLost < 0 ? this.XL6WinLost : 0;
                    sumCountLost += this.FWinLost < 0 ? this.FWinLost : 0;
                    return sumCountLost;
                }
                return this.sumCountLost;
            }
            set
            {
                this.sumCountLost = value;
            }
        }


        private int sumCountWin = 0;
        
        public int SumCountWin
        {
            get
            {
                if (!this.IsStatistics)
                {
                    sumCountWin = 0;
                    sumCountWin += this.XSWinLost > 0 ? this.XSWinLost : 0;
                    sumCountWin += this.SWinLost > 0 ? this.SWinLost : 0;
                    sumCountWin += this.MWinLost > 0 ? this.MWinLost : 0;
                    sumCountWin += this.LWinLost > 0 ? this.LWinLost : 0; 
                    sumCountWin += this.XLWinLost > 0 ? this.XLWinLost : 0;
                    sumCountWin += this.XL2WinLost > 0 ? this.XL2WinLost : 0;
                    sumCountWin += this.XL3WinLost > 0 ? this.XL3WinLost : 0;
                    sumCountWin += this.XL4WinLost > 0 ? this.XL4WinLost : 0;
                    sumCountWin += this.XL5WinLost > 0 ? this.XL5WinLost : 0;
                    sumCountWin += this.XL6WinLost > 0 ? this.XL6WinLost : 0;
                    sumCountWin += this.FWinLost > 0 ? this.FWinLost : 0;
                    return sumCountWin;
                }
                return this.sumCountWin;
            }
            set
            {
                this.sumCountWin = value;
            }
        }

        private int sumCountWinLost = 0;

        public int SumCountWinLost
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount - this.SumCountAtm;
                }
                return this.sumCountWinLost;
            }
            set
            {
                this.sumCountWinLost = value;
            }
        }



        private decimal sumMoneyWinLost = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总金额）
        /// </summary>
        public decimal SumMoneyWinLost
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCountWinLost * this.Price;
                }
                return this.sumMoneyWinLost;
            }
            set
            {
                this.sumMoneyWinLost = value;
            }

        }

        private decimal sumMoney = 0;
        /// <summary>
        /// 同款号同颜色所有尺码衣服的金额总和（总金额）
        /// </summary>
        public decimal SumMoney
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return this.SumCount * this.Price;
                }
                return this.sumMoney;
            }
            set
            {
                this.sumMoney = value;
            }

        }
        public bool IsStatistics { get ; set ; }

        public decimal CostPrice { get; set; }
        
        public int XSWinLost
        {
            get
            {
                return this.XS - this.XSAtm;
            }
        }

        public int SWinLost
        {
            get
            {
                return this.S - this.SAtm;
            }
        }

        public int MWinLost
        {
            get
            {
                return this.M - this.MAtm;
            }
        }

        public int LWinLost
        {
            get
            {
                return this.L - this.LAtm;
            }
        }

        public int XLWinLost
        {
            get
            {
                return this.XL - this.XLAtm;
            }
        }

        public int XL2WinLost
        {
            get
            {
                return this.XL2 - this.XL2Atm;
            }
        }

        public int XL3WinLost
        {
            get
            {
                return this.XL3 - this.XL3Atm;
            }
        }

        public int XL4WinLost
        {
            get
            {
                return this.XL4 - this.XL4Atm;
            }
        }

        public int XL5WinLost
        {
            get
            {
                return this.XL5 - this.XL5Atm;
            }
        }

        public int XL6WinLost
        {
            get
            {
                return this.XL6 - this.XL6Atm;
            }
        }

        public int FWinLost
        {
            get
            {
                return this.F - this.FAtm;
            }
        }
    }
}

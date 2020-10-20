using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class NumericTextBox : JGNet.Common.TextBox
    {


        private Decimal _value;
        public Decimal Value
        {

            get
            {
                return _value;
            }
            set
            {
                this._value = value;
                if (value != 0)
                {
                    this.SkinTxt.Text = value.ToString();
                }
                else {
                    if (ShowZero)
                    {
                        this.SkinTxt.Text = value.ToString();
                    } else
                    {
                        this.SkinTxt.Text = string.Empty;
                    }
                }

            }

        }

        public Boolean ShowZero { get; set; }



        public Decimal MaxNum { get; set; }
        public Decimal MinNum { get; set; }

        public int DecimalPlaces { get; set; }
        public event System.Action<object> ValueChanged;

        public NumericTextBox()
        {
            this.Text = "";
            this.Value = 0;
            this.MaxNum = decimal.MaxValue;
            this.MinNum = 0;
            this.MaxLength = decimal.MaxValue.ToString().Length;
            InitializeComponent();
            base.SkinTxt.KeyPress += SkinTxt_KeyPress;
            base.SkinTxt.Validating += SkinTxt_Validating;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
        }

        private void SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //取消登登登
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }

        private void SkinTxt_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(this.SkinTxt.Text))
            //{
            //    if (!ValidateUtil.CheckMoney(this.SkinTxt.Text))
            //    {
            //        e.Cancel = true;
            //        _value = 0;
            //    }
            //    else
            //    {
            //        _value = Convert.ToDecimal(this.SkinTxt.Text);
            //    }
            //}
            //  ValueChanged?.Invoke(sender);
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {


            String money = this.SkinTxt.Text;
            if (String.IsNullOrEmpty(money))
            {
                this._value = 0;
            }
            else
            {
                if (ValidateUtil.CheckNumber(money, MinNum, MaxNum))
                {
                    if (money == "-")
                    {
                        money = "0";
                    }
                    _value = Convert.ToDecimal(money);
                }
                else
                {
                    this.SkinTxt.Text = _value.ToString();
                }

            }
            ValueChanged?.Invoke(sender);
        }
    }
}

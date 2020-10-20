using CCWin.SkinControl;
using JGNet.Common.Core;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public enum QuickDateSelectorEnum
    {

        [Description("昨天")]
        YESTODAY,

        [Description("今天")]
        TODAY,

        [Description("本周")]
        THISWEEK,

        [Description("上周")]
        LASTWEEK,
        
        [Description("本月")]
        THISMONTH,

        [Description("上月")]
        LASTMONTH,
        
        [Description("本年")]
        THISYEAR,

        [Description("去年")]
        LASTYEAR,

        [Description("所有")]
        ALL

    }
    public class QuickDateEventArgs : EventArgs
    {
       public QuickDateSelectorEnum Selector { get; set; }
    }

    public partial class QuickDateSelector : SkinToolStrip
    {
        public DateTimePicker StartDateTimePicker { get; set; }
        public DateTimePicker EndDateTimePicker { get; set; }

        public QuickDateSelector()
        {
            InitializeComponent();
        }
        public event CJBasic.Action<object, EventArgs> PickerValueChanged;

        public QuickDateSelector(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

        }

        //public void SetUpPicker(
        //    DateTimePicker start, DateTimePicker end
        //    )
        //{
        //    this.StartDateTimePicker = start;
        //    this.EndDateTimePicker = end;
        //}
        private void 昨日ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_Yestoday(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.YESTODAY
            });
        }

        private void 今日ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           DateTimeUtil.DateTimePicker_Today(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.TODAY
            });
        }

        private void 本月ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_ThisMonth(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.THISMONTH
            });
        }

        private void 本周ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          DateTimeUtil.DateTimePicker_ThisWeek(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.THISWEEK
            });
        }

        private void 所有toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_All(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.ALL
            });
        }

        private void 去年toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_LastYear(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.LASTYEAR
            });
        }

        private void 本年toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_ThisYear(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.THISYEAR
            });
        }

        private void 上月toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          DateTimeUtil.DateTimePicker_LastMonth(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.LASTMONTH
            });
        }

        private void 上周toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTimeUtil.DateTimePicker_LastWeek(this.StartDateTimePicker, this.EndDateTimePicker);
            PickerValueChanged?.Invoke(this, new QuickDateEventArgs()
            {
                Selector = QuickDateSelectorEnum.LASTWEEK
            });
        }
    }
}

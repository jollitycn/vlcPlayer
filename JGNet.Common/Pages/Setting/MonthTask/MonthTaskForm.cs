
using CCWin;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Entitys;
using JGNet.Core.InteractEntity;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class MonthTaskForm : BaseForm
    {
        public event Action<MonthTask> Confirm;
        public event Action<MonthTaskSearch> SearchConfirm;
        private MonthTask task;
        private MonthTaskSearch search;
        private List<TKeyValue<int, int>> list;

        private List<TKeyValue<int, int>> taskAll;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public MonthTaskForm()
        {
            InitializeComponent();
            MenuPermission = RolePermissionMenuEnum.销售目标;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new String[] {
            MonthExpense.DataPropertyName})
            {
                AutoIndexMode = DataGridViewAutoIndexMode.None
            };
            dataGridViewPagingSumCtrl.Initialize();

            dataGridView1.AutoGenerateColumns = false;

        }

        public MonthTaskForm(MonthTaskSearch search, MonthTask task, bool readOnly)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new String[] {
            MonthExpense.DataPropertyName})
            {
                AutoIndexMode = DataGridViewAutoIndexMode.None
            };
            dataGridViewPagingSumCtrl .Initialize();

            dataGridView1.AutoGenerateColumns = false;
            this.task = task;
            this.search = search;
            dataGridView1.ReadOnly = readOnly;
            Initialize();
            MenuPermission = RolePermissionMenuEnum.销售目标;
        }

        private void Initialize()
        {



            if (String.IsNullOrEmpty(task.GuideID))
            {
                //店铺
                this.Text = "店铺日目标";
                this.skinLabelGuide.Text = "店铺：" + search.ShopName;

            }
            else
            {
                //导购员
                this.Text = "导购日目标";
                this.skinLabelGuide.Text = "导购员：" + task.GuideName;
                skinComboBoxMonth.Enabled = false;
            }

            skinComboBoxMonth.SelectedIndexChanged -= skinComboBoxMonth_SelectedIndexChanged;
            SetMonth(task.Month);
            skinComboBoxMonth.SelectedIndexChanged += skinComboBoxMonth_SelectedIndexChanged;
            skinComboBoxMonth.SelectedItem = task.Month;
            DataBinding();
            dataGridView1.ReadOnly = !HasPermission( Core.RolePermissionEnum.编辑);

            //if (IsPos) {
                //skinPanel4.Visible = !IsPos;
            //}

        }

        private void DataBinding()
        {
            int days = DateTime.DaysInMonth(task.Month / 100, task.Month - task.Month / 100 * 100);
            this.dataGridView1.DataSource = null;
            SetTaskAll();
            list = new List<TKeyValue<int, int>>();
            for (int i = 0; i < days; i++)
            {
                list.Add(taskAll[i]);
            }

            dataGridViewPagingSumCtrl.BindingDataSource<TKeyValue<int, int>>(list);
            int day = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;

            //判断日期是否小于今天
            //foreach (DataGridViewColumn item in dataGridView1.Columns)
            //{
            //    item.ReadOnly = true;
            //       item.DefaultCellStyle.ForeColor = Color.DarkGray;
            //}

            //DataGridViewCellStyle styleDark = new DataGridViewCellStyle();
            //styleDark.Font = new Font(dataGridView1.DefaultCellStyle.Font.Name, dataGridView1.DefaultCellStyle.Font.Size, FontStyle.Regular);
            //styleDark.ForeColor = Color.DarkGray;
            //DataGridViewCellStyle styleBlack = new DataGridViewCellStyle();
            //styleBlack.Font = new Font(dataGridView1.DefaultCellStyle.Font.Name, dataGridView1.DefaultCellStyle.Font.Size, FontStyle.Regular);
            //styleBlack.ForeColor = Color.Black;
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    int selectedRowDay = (int)skinComboBoxMonth.SelectedItem * 100 + (item.Index + 1);
            //    if (selectedRowDay < day)
            //    {
            //        item.ReadOnly = true;
            //        item.DefaultCellStyle.ForeColor = Color.DarkGray;

            //    }
            //    else
            //    {
            //        item.ReadOnly = false;
            //        item.DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //}
        }

        private void SetMonth(int month)
        {
            int year = month / 100;
            List<int> months = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                months.Add(year * 100 + i);
            }
            //skinComboBoxMonth.SelectedIndexChanged -= skinComboBoxMonth_SelectedIndexChanged;
            skinComboBoxMonth.DataSource = null;
            skinComboBoxMonth.DataSource = months;
            //  skinComboBoxMonth.SelectedIndexChanged += skinComboBoxMonth_SelectedIndexChanged;
        }

        private void SetTaskAll()
        {
            taskAll = new List<TKeyValue<int, int>>();
            taskAll.Add(new TKeyValue<int, int>(1, task.D1OfSale));
            taskAll.Add(new TKeyValue<int, int>(2, task.D2OfSale));
            taskAll.Add(new TKeyValue<int, int>(3, task.D3OfSale));
            taskAll.Add(new TKeyValue<int, int>(4, task.D4OfSale));
            taskAll.Add(new TKeyValue<int, int>(5, task.D5OfSale));
            taskAll.Add(new TKeyValue<int, int>(6, task.D6OfSale));
            taskAll.Add(new TKeyValue<int, int>(7, task.D7OfSale));
            taskAll.Add(new TKeyValue<int, int>(8, task.D8OfSale));
            taskAll.Add(new TKeyValue<int, int>(9, task.D9OfSale));
            taskAll.Add(new TKeyValue<int, int>(10, task.D10OfSale));
            taskAll.Add(new TKeyValue<int, int>(11, task.D11OfSale));
            taskAll.Add(new TKeyValue<int, int>(12, task.D12OfSale));
            taskAll.Add(new TKeyValue<int, int>(13, task.D13OfSale));
            taskAll.Add(new TKeyValue<int, int>(14, task.D14OfSale));
            taskAll.Add(new TKeyValue<int, int>(15, task.D15OfSale));
            taskAll.Add(new TKeyValue<int, int>(16, task.D16OfSale));
            taskAll.Add(new TKeyValue<int, int>(17, task.D17OfSale));
            taskAll.Add(new TKeyValue<int, int>(18, task.D18OfSale));
            taskAll.Add(new TKeyValue<int, int>(19, task.D19OfSale));
            taskAll.Add(new TKeyValue<int, int>(20, task.D20OfSale));
            taskAll.Add(new TKeyValue<int, int>(21, task.D21OfSale));
            taskAll.Add(new TKeyValue<int, int>(22, task.D22OfSale));
            taskAll.Add(new TKeyValue<int, int>(23, task.D23OfSale));
            taskAll.Add(new TKeyValue<int, int>(24, task.D24OfSale));
            taskAll.Add(new TKeyValue<int, int>(25, task.D25OfSale));
            taskAll.Add(new TKeyValue<int, int>(26, task.D26OfSale));
            taskAll.Add(new TKeyValue<int, int>(27, task.D27OfSale));
            taskAll.Add(new TKeyValue<int, int>(28, task.D28OfSale));
            taskAll.Add(new TKeyValue<int, int>(29, task.D29OfSale));
            taskAll.Add(new TKeyValue<int, int>(30, task.D30OfSale));
            taskAll.Add(new TKeyValue<int, int>(31, task.D31OfSale));
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list.Add(taskAll[i]);
            //    task.D1OfSale = list[i];
            //}

            DataToTask();

            Confirm?.Invoke(task);
            SearchConfirm?.Invoke(search);
            this.DialogResult = DialogResult.OK;
        }

        private void DataToTask()
        {
            if (list == null) { return; }
            task.D1OfSale = list[0].Value;
            task.D2OfSale = list[1].Value;
            task.D3OfSale = list[2].Value;
            task.D4OfSale = list[3].Value;
            task.D5OfSale = list[4].Value;
            task.D6OfSale = list[5].Value;
            task.D7OfSale = list[6].Value;
            task.D8OfSale = list[7].Value;
            task.D9OfSale = list[8].Value;
            task.D10OfSale = list[9].Value;
            task.D11OfSale = list[10].Value;
            task.D12OfSale = list[11].Value;
            task.D13OfSale = list[12].Value;
            task.D14OfSale = list[13].Value;
            task.D15OfSale = list[14].Value;
            task.D16OfSale = list[15].Value;
            task.D17OfSale = list[16].Value;
            task.D18OfSale = list[17].Value;
            task.D19OfSale = list[18].Value;
            task.D20OfSale = list[19].Value;
            task.D21OfSale = list[20].Value;
            task.D22OfSale = list[21].Value;
            task.D23OfSale = list[22].Value;
            task.D24OfSale = list[23].Value;
            task.D25OfSale = list[24].Value;
            task.D26OfSale = list[25].Value;
            task.D27OfSale = list[26].Value;
            task.D28OfSale = list[27].Value;
            if (list.Count > 28)
            {
                task.D29OfSale = list[28].Value;
            }
            else
            {
                task.D29OfSale = 0;
            }
            if (list.Count > 29)
            {
                task.D30OfSale = list[29].Value;
            }
            else
            {
                task.D30OfSale = 0;
            }
            if (list.Count > 30)
            {
                task.D31OfSale = list[30].Value;
            }
            else
            {
                task.D31OfSale = 0;
            }
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridView grid = (DataGridView)sender;
                grid.Rows[e.RowIndex].ErrorText = "";
                //增加了序号
                if (e.ColumnIndex > 0)
                // if (e.ColumnIndex > 1)
                {
                    Int32 newInteger = 0;
                    if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) && !string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        DataGridViewRow dr = grid.Rows[0];
                        e.Cancel = true;
                        grid.Rows[e.RowIndex].ErrorText = "请输入整数";
                        GlobalMessageBox.Show("请输入整数！" , "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            // }
        }

        private void skinComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置原来的值
            DataToTask();
            //设置新的值
            if (search != null)
            {
                task = search.MonthTasks.Find(t => t.Month == (int)skinComboBoxMonth.SelectedItem);
            }
            int month = DateTime.Now.Year * 100 + DateTime.Now.Month;
            if (task.Month < month)
            {
                MonthExpense.ReadOnly = true;
            }
            else
            {
                MonthExpense.ReadOnly = false;
            }
            DataBinding();
        }



        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MonthTaskForm_Shown(object sender, EventArgs e)
        {

        }

        private void MonthTaskForm_Load(object sender, EventArgs e)
        {

            //skinComboBoxMonth.SelectedIndex = 0;
        }

        internal DialogResult ShowDialog(MonthTaskSearch search, MonthTask task, bool readOnly)
        {
            this.search = search;
            this.task = task;
            dataGridView1.ReadOnly = readOnly;
            Initialize();
            return this.ShowDialog();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.Value == null) { return; }

            if (!IsPos)
            {
                int day = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                DataGridViewRow item = dataGridView1.Rows[e.RowIndex];
                int selectedRowDay = (int)skinComboBoxMonth.SelectedItem * 100 + (e.RowIndex + 1);
                if (selectedRowDay < day)
                {
                    //read only  不能在这里设置？？？否则验证会报错？
                    item.ReadOnly = true;
                    item.DefaultCellStyle.ForeColor = Color.DarkGray;

                }
                else
                {
                    //这里不再去设置
                    //  item.ReadOnly = false;
                    item.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void baseButtonConfirm_Click(object sender, EventArgs e)
        {
            int day = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow item = dataGridView1.Rows[i];
                int selectedRowDay = (int)skinComboBoxMonth.SelectedItem * 100 + (i + 1);
                if (!item.ReadOnly)
                {
                    //TKeyValue<int, int> keyValue = item.DataBoundItem as TKeyValue<int, int>;
                    //if (keyValue != null)
                    //{
                    //    keyValue.Value = decimal.ToInt32(numericTextBoxOne.Value);
                    //}
                    item.Cells[MonthExpense.Index].Value = numericTextBoxOne.Value;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewRow item = dataGridView1.Rows[e.RowIndex];
            if (!item.ReadOnly)
            {
                //  item.Cells[MonthExpense.Index].Value = numericTextBoxOne.Value;
              //  dataGridViewPagingSumCtrl.ReLoadSummary<TKeyValue<int, int>>(null);
            }
        }


        //private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    if (e.Exception != null)
        //    {
        //        CommonGlobalUtil.WriteLog(e.Exception);

        //    }
        //    e.Cancel = false;

        //}
    }

}
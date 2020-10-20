using CCWin.SkinControl;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class CostumeStoreTrackSearchProfitDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CostumeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xSAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xLAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL2AtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL3AtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL4AtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL5AtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL6AtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCountAtmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xL6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCountWinLostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumMoneyWinLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreBindingSource)).BeginInit();
            this.skinPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.dataGridView1);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(1152, 618);
            this.skinPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CostumeID,
            this.costumeNameDataGridViewTextBoxColumn,
            this.colorNameDataGridViewTextBoxColumn,
            this.fAtmDataGridViewTextBoxColumn,
            this.xSAtmDataGridViewTextBoxColumn,
            this.sAtmDataGridViewTextBoxColumn,
            this.mAtmDataGridViewTextBoxColumn,
            this.lAtmDataGridViewTextBoxColumn,
            this.xLAtmDataGridViewTextBoxColumn,
            this.xL2AtmDataGridViewTextBoxColumn,
            this.xL3AtmDataGridViewTextBoxColumn,
            this.xL4AtmDataGridViewTextBoxColumn,
            this.xL5AtmDataGridViewTextBoxColumn,
            this.xL6AtmDataGridViewTextBoxColumn,
            this.sumCountAtmDataGridViewTextBoxColumn,
            this.fDataGridViewTextBoxColumn,
            this.xSDataGridViewTextBoxColumn,
            this.sDataGridViewTextBoxColumn,
            this.mDataGridViewTextBoxColumn,
            this.lDataGridViewTextBoxColumn,
            this.xLDataGridViewTextBoxColumn,
            this.xL2DataGridViewTextBoxColumn,
            this.xL3DataGridViewTextBoxColumn,
            this.xL4DataGridViewTextBoxColumn,
            this.xL5DataGridViewTextBoxColumn,
            this.xL6DataGridViewTextBoxColumn,
            this.sumCountDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn1,
            this.sumCountWinLostDataGridViewTextBoxColumn,
            this.SumMoneyWinLost,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.costumeStoreBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1152, 580);
            this.dataGridView1.TabIndex = 41;
            // 
            // CostumeID
            // 
            this.CostumeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostumeID.DataPropertyName = "CostumeID";
            this.CostumeID.HeaderText = "款号";
            this.CostumeID.Name = "CostumeID";
            this.CostumeID.ReadOnly = true;
            this.CostumeID.Width = 80;
            // 
            // costumeNameDataGridViewTextBoxColumn
            // 
            this.costumeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeNameDataGridViewTextBoxColumn.DataPropertyName = "CostumeName";
            this.costumeNameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.costumeNameDataGridViewTextBoxColumn.Name = "costumeNameDataGridViewTextBoxColumn";
            this.costumeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "颜色";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorNameDataGridViewTextBoxColumn.Width = 50;
            // 
            // fAtmDataGridViewTextBoxColumn
            // 
            this.fAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fAtmDataGridViewTextBoxColumn.DataPropertyName = "FAtm";
            this.fAtmDataGridViewTextBoxColumn.HeaderText = "F";
            this.fAtmDataGridViewTextBoxColumn.Name = "fAtmDataGridViewTextBoxColumn";
            this.fAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.fAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xSAtmDataGridViewTextBoxColumn
            // 
            this.xSAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xSAtmDataGridViewTextBoxColumn.DataPropertyName = "XSAtm";
            this.xSAtmDataGridViewTextBoxColumn.HeaderText = "XS";
            this.xSAtmDataGridViewTextBoxColumn.Name = "xSAtmDataGridViewTextBoxColumn";
            this.xSAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xSAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // sAtmDataGridViewTextBoxColumn
            // 
            this.sAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sAtmDataGridViewTextBoxColumn.DataPropertyName = "SAtm";
            this.sAtmDataGridViewTextBoxColumn.HeaderText = "S";
            this.sAtmDataGridViewTextBoxColumn.Name = "sAtmDataGridViewTextBoxColumn";
            this.sAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.sAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // mAtmDataGridViewTextBoxColumn
            // 
            this.mAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mAtmDataGridViewTextBoxColumn.DataPropertyName = "MAtm";
            this.mAtmDataGridViewTextBoxColumn.HeaderText = "M";
            this.mAtmDataGridViewTextBoxColumn.Name = "mAtmDataGridViewTextBoxColumn";
            this.mAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.mAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // lAtmDataGridViewTextBoxColumn
            // 
            this.lAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lAtmDataGridViewTextBoxColumn.DataPropertyName = "LAtm";
            this.lAtmDataGridViewTextBoxColumn.HeaderText = "L";
            this.lAtmDataGridViewTextBoxColumn.Name = "lAtmDataGridViewTextBoxColumn";
            this.lAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.lAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xLAtmDataGridViewTextBoxColumn
            // 
            this.xLAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xLAtmDataGridViewTextBoxColumn.DataPropertyName = "XLAtm";
            this.xLAtmDataGridViewTextBoxColumn.HeaderText = "XL";
            this.xLAtmDataGridViewTextBoxColumn.Name = "xLAtmDataGridViewTextBoxColumn";
            this.xLAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xLAtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL2AtmDataGridViewTextBoxColumn
            // 
            this.xL2AtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL2AtmDataGridViewTextBoxColumn.DataPropertyName = "XL2Atm";
            this.xL2AtmDataGridViewTextBoxColumn.HeaderText = "2XL";
            this.xL2AtmDataGridViewTextBoxColumn.Name = "xL2AtmDataGridViewTextBoxColumn";
            this.xL2AtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xL2AtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL3AtmDataGridViewTextBoxColumn
            // 
            this.xL3AtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL3AtmDataGridViewTextBoxColumn.DataPropertyName = "XL3Atm";
            this.xL3AtmDataGridViewTextBoxColumn.HeaderText = "3XL";
            this.xL3AtmDataGridViewTextBoxColumn.Name = "xL3AtmDataGridViewTextBoxColumn";
            this.xL3AtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xL3AtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL4AtmDataGridViewTextBoxColumn
            // 
            this.xL4AtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL4AtmDataGridViewTextBoxColumn.DataPropertyName = "XL4Atm";
            this.xL4AtmDataGridViewTextBoxColumn.HeaderText = "4XL";
            this.xL4AtmDataGridViewTextBoxColumn.Name = "xL4AtmDataGridViewTextBoxColumn";
            this.xL4AtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xL4AtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL5AtmDataGridViewTextBoxColumn
            // 
            this.xL5AtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL5AtmDataGridViewTextBoxColumn.DataPropertyName = "XL5Atm";
            this.xL5AtmDataGridViewTextBoxColumn.HeaderText = "5XL";
            this.xL5AtmDataGridViewTextBoxColumn.Name = "xL5AtmDataGridViewTextBoxColumn";
            this.xL5AtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xL5AtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL6AtmDataGridViewTextBoxColumn
            // 
            this.xL6AtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL6AtmDataGridViewTextBoxColumn.DataPropertyName = "XL6Atm";
            this.xL6AtmDataGridViewTextBoxColumn.HeaderText = "6XL";
            this.xL6AtmDataGridViewTextBoxColumn.Name = "xL6AtmDataGridViewTextBoxColumn";
            this.xL6AtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.xL6AtmDataGridViewTextBoxColumn.Width = 45;
            // 
            // sumCountAtmDataGridViewTextBoxColumn
            // 
            this.sumCountAtmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumCountAtmDataGridViewTextBoxColumn.DataPropertyName = "SumCountAtm";
            this.sumCountAtmDataGridViewTextBoxColumn.HeaderText = "账面数";
            this.sumCountAtmDataGridViewTextBoxColumn.Name = "sumCountAtmDataGridViewTextBoxColumn";
            this.sumCountAtmDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumCountAtmDataGridViewTextBoxColumn.Width = 60;
            // 
            // fDataGridViewTextBoxColumn
            // 
            this.fDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fDataGridViewTextBoxColumn.DataPropertyName = "F";
            this.fDataGridViewTextBoxColumn.HeaderText = "F";
            this.fDataGridViewTextBoxColumn.Name = "fDataGridViewTextBoxColumn";
            this.fDataGridViewTextBoxColumn.ReadOnly = true;
            this.fDataGridViewTextBoxColumn.Width = 45;
            // 
            // xSDataGridViewTextBoxColumn
            // 
            this.xSDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xSDataGridViewTextBoxColumn.DataPropertyName = "XS";
            this.xSDataGridViewTextBoxColumn.HeaderText = "XS";
            this.xSDataGridViewTextBoxColumn.Name = "xSDataGridViewTextBoxColumn";
            this.xSDataGridViewTextBoxColumn.ReadOnly = true;
            this.xSDataGridViewTextBoxColumn.Width = 45;
            // 
            // sDataGridViewTextBoxColumn
            // 
            this.sDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sDataGridViewTextBoxColumn.DataPropertyName = "S";
            this.sDataGridViewTextBoxColumn.HeaderText = "S";
            this.sDataGridViewTextBoxColumn.Name = "sDataGridViewTextBoxColumn";
            this.sDataGridViewTextBoxColumn.ReadOnly = true;
            this.sDataGridViewTextBoxColumn.Width = 45;
            // 
            // mDataGridViewTextBoxColumn
            // 
            this.mDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mDataGridViewTextBoxColumn.DataPropertyName = "M";
            this.mDataGridViewTextBoxColumn.HeaderText = "M";
            this.mDataGridViewTextBoxColumn.Name = "mDataGridViewTextBoxColumn";
            this.mDataGridViewTextBoxColumn.ReadOnly = true;
            this.mDataGridViewTextBoxColumn.Width = 45;
            // 
            // lDataGridViewTextBoxColumn
            // 
            this.lDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lDataGridViewTextBoxColumn.DataPropertyName = "L";
            this.lDataGridViewTextBoxColumn.HeaderText = "L";
            this.lDataGridViewTextBoxColumn.Name = "lDataGridViewTextBoxColumn";
            this.lDataGridViewTextBoxColumn.ReadOnly = true;
            this.lDataGridViewTextBoxColumn.Width = 45;
            // 
            // xLDataGridViewTextBoxColumn
            // 
            this.xLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xLDataGridViewTextBoxColumn.DataPropertyName = "XL";
            this.xLDataGridViewTextBoxColumn.HeaderText = "XL";
            this.xLDataGridViewTextBoxColumn.Name = "xLDataGridViewTextBoxColumn";
            this.xLDataGridViewTextBoxColumn.ReadOnly = true;
            this.xLDataGridViewTextBoxColumn.Width = 45;
            // 
            // xL2DataGridViewTextBoxColumn
            // 
            this.xL2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL2DataGridViewTextBoxColumn.DataPropertyName = "XL2";
            this.xL2DataGridViewTextBoxColumn.HeaderText = "2XL";
            this.xL2DataGridViewTextBoxColumn.Name = "xL2DataGridViewTextBoxColumn";
            this.xL2DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL2DataGridViewTextBoxColumn.Width = 45;
            // 
            // xL3DataGridViewTextBoxColumn
            // 
            this.xL3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL3DataGridViewTextBoxColumn.DataPropertyName = "XL3";
            this.xL3DataGridViewTextBoxColumn.HeaderText = "3XL";
            this.xL3DataGridViewTextBoxColumn.Name = "xL3DataGridViewTextBoxColumn";
            this.xL3DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL3DataGridViewTextBoxColumn.Width = 45;
            // 
            // xL4DataGridViewTextBoxColumn
            // 
            this.xL4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL4DataGridViewTextBoxColumn.DataPropertyName = "XL4";
            this.xL4DataGridViewTextBoxColumn.HeaderText = "4XL";
            this.xL4DataGridViewTextBoxColumn.Name = "xL4DataGridViewTextBoxColumn";
            this.xL4DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL4DataGridViewTextBoxColumn.Width = 45;
            // 
            // xL5DataGridViewTextBoxColumn
            // 
            this.xL5DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL5DataGridViewTextBoxColumn.DataPropertyName = "XL5";
            this.xL5DataGridViewTextBoxColumn.HeaderText = "5XL";
            this.xL5DataGridViewTextBoxColumn.Name = "xL5DataGridViewTextBoxColumn";
            this.xL5DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL5DataGridViewTextBoxColumn.Width = 45;
            // 
            // xL6DataGridViewTextBoxColumn
            // 
            this.xL6DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL6DataGridViewTextBoxColumn.DataPropertyName = "XL6";
            this.xL6DataGridViewTextBoxColumn.HeaderText = "6XL";
            this.xL6DataGridViewTextBoxColumn.Name = "xL6DataGridViewTextBoxColumn";
            this.xL6DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL6DataGridViewTextBoxColumn.Width = 45;
            // 
            // sumCountDataGridViewTextBoxColumn
            // 
            this.sumCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumCountDataGridViewTextBoxColumn.DataPropertyName = "SumCount";
            this.sumCountDataGridViewTextBoxColumn.HeaderText = "实盘数";
            this.sumCountDataGridViewTextBoxColumn.Name = "sumCountDataGridViewTextBoxColumn";
            this.sumCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumCountDataGridViewTextBoxColumn.Width = 60;
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "单价";
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            this.priceDataGridViewTextBoxColumn1.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn1.Width = 45;
            // 
            // sumCountWinLostDataGridViewTextBoxColumn
            // 
            this.sumCountWinLostDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumCountWinLostDataGridViewTextBoxColumn.DataPropertyName = "SumCountWinLost";
            this.sumCountWinLostDataGridViewTextBoxColumn.HeaderText = "盈亏";
            this.sumCountWinLostDataGridViewTextBoxColumn.Name = "sumCountWinLostDataGridViewTextBoxColumn";
            this.sumCountWinLostDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumCountWinLostDataGridViewTextBoxColumn.Width = 45;
            // 
            // SumMoneyWinLost
            // 
            this.SumMoneyWinLost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SumMoneyWinLost.DataPropertyName = "SumMoneyWinLost";
            this.SumMoneyWinLost.HeaderText = "盈亏金额";
            this.SumMoneyWinLost.Name = "SumMoneyWinLost";
            this.SumMoneyWinLost.ReadOnly = true;
            this.SumMoneyWinLost.Width = 80;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "备注";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Width = 54;
            // 
            // costumeStoreBindingSource
            // 
            this.costumeStoreBindingSource.DataSource = typeof(JGNet.CheckStoreDetail);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton1);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 580);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(1152, 38);
            this.skinPanel3.TabIndex = 2;
            // 
            // BaseButton1
            // 
            this.BaseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(1071, 6);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 4;
            this.BaseButton1.Text = "关闭";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Quit_Click);
            // 
            // CostumeStoreTrackSearchProfitDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = true;
            this.ClientSize = new System.Drawing.Size(1160, 650);
            this.Controls.Add(this.skinPanel1);
            this.Name = "CostumeStoreTrackSearchProfitDetailForm";
            this.Text = "盘点单明细";
            this.Load += new System.EventHandler(this.CostumeStoreTrackSearchProfitDetailForm_Load);
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreBindingSource)).EndInit();
            this.skinPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton1;
        private DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private BindingSource costumeStoreBindingSource;
        private DataGridViewTextBoxColumn CostumeID;
        private DataGridViewTextBoxColumn costumeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xSAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xLAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL2AtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL3AtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL4AtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL5AtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL6AtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sumCountAtmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xSDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL3DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL4DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL5DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xL6DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sumCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sumCountWinLostDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn SumMoneyWinLost;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}
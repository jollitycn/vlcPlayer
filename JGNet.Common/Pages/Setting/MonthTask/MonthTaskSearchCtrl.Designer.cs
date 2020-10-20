using JGNet.Common;

namespace JGNet.Common
{
    partial class  MonthTaskSearchCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.numericUpDown_year = new System.Windows.Forms.NumericUpDown();
            this.skinComboBoxShopID = new JGNet.Common.ShopComboBox();
            this.skinLabel17 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dataGridView_MonthTask = new System.Windows.Forms.DataGridView();
            this.shopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target11DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target12DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSetting = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.monthTaskSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView_RefundDetail = new System.Windows.Forms.DataGridView();
            this.MonthTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuideID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyOfSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSetting2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_year)).BeginInit();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.Panel2.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MonthTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthTaskSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTaskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.numericUpDown_year);
            this.skinPanel1.Controls.Add(this.skinComboBoxShopID);
            this.skinPanel1.Controls.Add(this.skinLabel17);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 39);
            this.skinPanel1.TabIndex = 4;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(342, 3);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 2;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // numericUpDown_year
            // 
            this.numericUpDown_year.Location = new System.Drawing.Point(216, 9);
            this.numericUpDown_year.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_year.Name = "numericUpDown_year";
            this.numericUpDown_year.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown_year.TabIndex = 1;
            this.numericUpDown_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // skinComboBoxShopID
            // 
            this.skinComboBoxShopID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxShopID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxShopID.FormattingEnabled = true;
            this.skinComboBoxShopID.Location = new System.Drawing.Point(41, 8);
            this.skinComboBoxShopID.Name = "skinComboBoxShopID";
            this.skinComboBoxShopID.Size = new System.Drawing.Size(130, 22);
            this.skinComboBoxShopID.TabIndex = 0;
            this.skinComboBoxShopID.WaterText = "";
            this.skinComboBoxShopID.SelectedIndexChanged += new System.EventHandler(this.skinComboBoxShopID_SelectedIndexChanged);
            // 
            // skinLabel17
            // 
            this.skinLabel17.AutoSize = true;
            this.skinLabel17.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel17.BorderColor = System.Drawing.Color.White;
            this.skinLabel17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel17.Location = new System.Drawing.Point(3, 11);
            this.skinLabel17.Name = "skinLabel17";
            this.skinLabel17.Size = new System.Drawing.Size(32, 17);
            this.skinLabel17.TabIndex = 27;
            this.skinLabel17.Text = "店铺";
            this.skinLabel17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(423, 11);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(188, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "可以修改当前月份之后的销售目标";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(177, 11);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 0;
            this.skinLabel2.Text = "年份";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.CollapsePanel = CCWin.SkinControl.CollapsePanel.Panel2;
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 39);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView_MonthTask);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.dataGridView_RefundDetail);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 611);
            this.skinSplitContainer1.SplitterDistance = 199;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 11;
            // 
            // dataGridView_MonthTask
            // 
            this.dataGridView_MonthTask.AllowUserToAddRows = false;
            this.dataGridView_MonthTask.AllowUserToDeleteRows = false;
            this.dataGridView_MonthTask.AutoGenerateColumns = false;
            this.dataGridView_MonthTask.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_MonthTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shopDataGridViewTextBoxColumn,
            this.target1DataGridViewTextBoxColumn,
            this.target2DataGridViewTextBoxColumn,
            this.target3DataGridViewTextBoxColumn,
            this.target4DataGridViewTextBoxColumn,
            this.target5DataGridViewTextBoxColumn,
            this.target6DataGridViewTextBoxColumn,
            this.target7DataGridViewTextBoxColumn,
            this.target8DataGridViewTextBoxColumn,
            this.target9DataGridViewTextBoxColumn,
            this.target10DataGridViewTextBoxColumn,
            this.target11DataGridViewTextBoxColumn,
            this.target12DataGridViewTextBoxColumn,
            this.ColumnSetting,
            this.Column4});
            this.dataGridView_MonthTask.DataSource = this.monthTaskSearchBindingSource;
            this.dataGridView_MonthTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_MonthTask.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_MonthTask.Name = "dataGridView_MonthTask";
            this.dataGridView_MonthTask.RowTemplate.Height = 23;
            this.dataGridView_MonthTask.Size = new System.Drawing.Size(1160, 199);
            this.dataGridView_MonthTask.TabIndex = 3;
            this.dataGridView_MonthTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MonthTask_CellContentClick);
            this.dataGridView_MonthTask.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            this.dataGridView_MonthTask.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MonthTask_CellValueChanged);
            this.dataGridView_MonthTask.SelectionChanged += new System.EventHandler(this.dataGridView_MonthTask_SelectionChanged);
            // 
            // shopDataGridViewTextBoxColumn
            // 
            this.shopDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.shopDataGridViewTextBoxColumn.DataPropertyName = "ShopName";
            this.shopDataGridViewTextBoxColumn.HeaderText = "店铺";
            this.shopDataGridViewTextBoxColumn.Name = "shopDataGridViewTextBoxColumn";
            this.shopDataGridViewTextBoxColumn.ReadOnly = true;
            this.shopDataGridViewTextBoxColumn.Width = 120;
            // 
            // target1DataGridViewTextBoxColumn
            // 
            this.target1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target1DataGridViewTextBoxColumn.DataPropertyName = "Target1";
            this.target1DataGridViewTextBoxColumn.HeaderText = "1月";
            this.target1DataGridViewTextBoxColumn.Name = "target1DataGridViewTextBoxColumn";
            this.target1DataGridViewTextBoxColumn.Width = 75;
            // 
            // target2DataGridViewTextBoxColumn
            // 
            this.target2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target2DataGridViewTextBoxColumn.DataPropertyName = "Target2";
            this.target2DataGridViewTextBoxColumn.HeaderText = "2月";
            this.target2DataGridViewTextBoxColumn.Name = "target2DataGridViewTextBoxColumn";
            this.target2DataGridViewTextBoxColumn.Width = 75;
            // 
            // target3DataGridViewTextBoxColumn
            // 
            this.target3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target3DataGridViewTextBoxColumn.DataPropertyName = "Target3";
            this.target3DataGridViewTextBoxColumn.HeaderText = "3月";
            this.target3DataGridViewTextBoxColumn.Name = "target3DataGridViewTextBoxColumn";
            this.target3DataGridViewTextBoxColumn.Width = 75;
            // 
            // target4DataGridViewTextBoxColumn
            // 
            this.target4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target4DataGridViewTextBoxColumn.DataPropertyName = "Target4";
            this.target4DataGridViewTextBoxColumn.HeaderText = "4月";
            this.target4DataGridViewTextBoxColumn.Name = "target4DataGridViewTextBoxColumn";
            this.target4DataGridViewTextBoxColumn.Width = 75;
            // 
            // target5DataGridViewTextBoxColumn
            // 
            this.target5DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target5DataGridViewTextBoxColumn.DataPropertyName = "Target5";
            this.target5DataGridViewTextBoxColumn.HeaderText = "5月";
            this.target5DataGridViewTextBoxColumn.Name = "target5DataGridViewTextBoxColumn";
            this.target5DataGridViewTextBoxColumn.Width = 75;
            // 
            // target6DataGridViewTextBoxColumn
            // 
            this.target6DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target6DataGridViewTextBoxColumn.DataPropertyName = "Target6";
            this.target6DataGridViewTextBoxColumn.HeaderText = "6月";
            this.target6DataGridViewTextBoxColumn.Name = "target6DataGridViewTextBoxColumn";
            this.target6DataGridViewTextBoxColumn.Width = 75;
            // 
            // target7DataGridViewTextBoxColumn
            // 
            this.target7DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target7DataGridViewTextBoxColumn.DataPropertyName = "Target7";
            this.target7DataGridViewTextBoxColumn.HeaderText = "7月";
            this.target7DataGridViewTextBoxColumn.Name = "target7DataGridViewTextBoxColumn";
            this.target7DataGridViewTextBoxColumn.Width = 75;
            // 
            // target8DataGridViewTextBoxColumn
            // 
            this.target8DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target8DataGridViewTextBoxColumn.DataPropertyName = "Target8";
            this.target8DataGridViewTextBoxColumn.HeaderText = "8月";
            this.target8DataGridViewTextBoxColumn.Name = "target8DataGridViewTextBoxColumn";
            this.target8DataGridViewTextBoxColumn.Width = 75;
            // 
            // target9DataGridViewTextBoxColumn
            // 
            this.target9DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target9DataGridViewTextBoxColumn.DataPropertyName = "Target9";
            this.target9DataGridViewTextBoxColumn.HeaderText = "9月";
            this.target9DataGridViewTextBoxColumn.Name = "target9DataGridViewTextBoxColumn";
            this.target9DataGridViewTextBoxColumn.Width = 75;
            // 
            // target10DataGridViewTextBoxColumn
            // 
            this.target10DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target10DataGridViewTextBoxColumn.DataPropertyName = "Target10";
            this.target10DataGridViewTextBoxColumn.HeaderText = "10月";
            this.target10DataGridViewTextBoxColumn.Name = "target10DataGridViewTextBoxColumn";
            this.target10DataGridViewTextBoxColumn.Width = 75;
            // 
            // target11DataGridViewTextBoxColumn
            // 
            this.target11DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target11DataGridViewTextBoxColumn.DataPropertyName = "Target11";
            this.target11DataGridViewTextBoxColumn.HeaderText = "11月";
            this.target11DataGridViewTextBoxColumn.Name = "target11DataGridViewTextBoxColumn";
            this.target11DataGridViewTextBoxColumn.Width = 75;
            // 
            // target12DataGridViewTextBoxColumn
            // 
            this.target12DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.target12DataGridViewTextBoxColumn.DataPropertyName = "Target12";
            this.target12DataGridViewTextBoxColumn.HeaderText = "12月";
            this.target12DataGridViewTextBoxColumn.Name = "target12DataGridViewTextBoxColumn";
            this.target12DataGridViewTextBoxColumn.Width = 75;
            // 
            // ColumnSetting
            // 
            this.ColumnSetting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSetting.HeaderText = "设置日目标";
            this.ColumnSetting.Name = "ColumnSetting";
            this.ColumnSetting.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSetting.Text = "设置日目标";
            this.ColumnSetting.UseColumnTextForLinkValue = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "查看日目标";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Text = "查看日目标";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.Width = 90;
            // 
            // monthTaskSearchBindingSource
            // 
            this.monthTaskSearchBindingSource.DataSource = typeof(JGNet.Common.Entitys.MonthTaskSearch);
            // 
            // dataGridView_RefundDetail
            // 
            this.dataGridView_RefundDetail.AllowUserToAddRows = false;
            this.dataGridView_RefundDetail.AllowUserToDeleteRows = false;
            this.dataGridView_RefundDetail.AutoGenerateColumns = false;
            this.dataGridView_RefundDetail.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_RefundDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GuideID,
            this.moneyOfSaleDataGridViewTextBoxColumn,
            this.ColumnSetting2,
            this.Column2});
            this.dataGridView_RefundDetail.DataSource = this.MonthTaskBindingSource;
            this.dataGridView_RefundDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RefundDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_RefundDetail.Name = "dataGridView_RefundDetail";
            this.dataGridView_RefundDetail.RowTemplate.Height = 23;
            this.dataGridView_RefundDetail.Size = new System.Drawing.Size(1160, 404);
            this.dataGridView_RefundDetail.TabIndex = 4;
            this.dataGridView_RefundDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RefundDetail_CellContentClick);
            this.dataGridView_RefundDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            this.dataGridView_RefundDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RefundDetail_CellValueChanged);
            // 
            // MonthTaskBindingSource
            // 
            this.MonthTaskBindingSource.DataSource = typeof(JGNet.MonthTask);
            // 
            // GuideID
            // 
            this.GuideID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GuideID.DataPropertyName = "GuideName";
            this.GuideID.HeaderText = "导购员";
            this.GuideID.Name = "GuideID";
            this.GuideID.ReadOnly = true;
            this.GuideID.Width = 470;
            // 
            // moneyOfSaleDataGridViewTextBoxColumn
            // 
            this.moneyOfSaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.moneyOfSaleDataGridViewTextBoxColumn.DataPropertyName = "MoneyOfSale";
            this.moneyOfSaleDataGridViewTextBoxColumn.HeaderText = "月销售目标";
            this.moneyOfSaleDataGridViewTextBoxColumn.Name = "moneyOfSaleDataGridViewTextBoxColumn";
            this.moneyOfSaleDataGridViewTextBoxColumn.Width = 470;
            // 
            // ColumnSetting2
            // 
            this.ColumnSetting2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSetting2.HeaderText = "设置日目标";
            this.ColumnSetting2.Name = "ColumnSetting2";
            this.ColumnSetting2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSetting2.Text = "设置日目标";
            this.ColumnSetting2.UseColumnTextForLinkValue = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "查看日目标";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Text = "查看日目标";
            this.Column2.UseColumnTextForLinkValue = true;
            this.Column2.Width = 71;
            // 
            // MonthTaskSearchCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "MonthTaskSearchCtrl";
            this.Load += new System.EventHandler(this.MonthTaskSearchCtrl_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_year)).EndInit();
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            this.skinSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MonthTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthTaskSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTaskBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.BindingSource MonthTaskBindingSource;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private ShopComboBox skinComboBoxShopID;
        private CCWin.SkinControl.SkinLabel skinLabel17;
        private System.Windows.Forms.NumericUpDown numericUpDown_year;
        private System.Windows.Forms.BindingSource monthTaskSearchBindingSource;
        private System.Windows.Forms.DataGridView dataGridView_MonthTask;
        private System.Windows.Forms.DataGridView dataGridView_RefundDetail;
        private Common.Components.BaseButton BaseButton1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnSetting;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuideID;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyOfSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnSetting2;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
    }
}

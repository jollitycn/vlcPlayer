using CCWin.SkinControl;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class CostumeStoreTrackSearchProfitForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DateInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShopIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorUserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckStoreWinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckStoreLostCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkStoreOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStoreOrderBindingSource)).BeginInit();
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
            this.skinPanel1.Size = new System.Drawing.Size(699, 380);
            this.skinPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.DateInt,
            this.ShopIDColumn,
            this.operatorUserNameDataGridViewTextBoxColumn,
            this.CheckUserID,
            this.CheckStoreWinCount,
            this.CheckStoreLostCount,
            this.State});
            this.dataGridView1.DataSource = this.checkStoreOrderBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(699, 342);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "单据编号";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.iDDataGridViewTextBoxColumn.Width = 115;
            // 
            // DateInt
            // 
            this.DateInt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateInt.DataPropertyName = "CreateTime";
            this.DateInt.HeaderText = "日期";
            this.DateInt.Name = "DateInt";
            this.DateInt.ReadOnly = true;
            // 
            // ShopIDColumn
            // 
            this.ShopIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShopIDColumn.DataPropertyName = "ShopName";
            this.ShopIDColumn.HeaderText = "店铺";
            this.ShopIDColumn.Name = "ShopIDColumn";
            this.ShopIDColumn.ReadOnly = true;
            this.ShopIDColumn.Width = 88;
            // 
            // operatorUserNameDataGridViewTextBoxColumn
            // 
            this.operatorUserNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.operatorUserNameDataGridViewTextBoxColumn.DataPropertyName = "OperatorUserName";
            this.operatorUserNameDataGridViewTextBoxColumn.HeaderText = "操作人";
            this.operatorUserNameDataGridViewTextBoxColumn.Name = "operatorUserNameDataGridViewTextBoxColumn";
            this.operatorUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.operatorUserNameDataGridViewTextBoxColumn.Width = 65;
            // 
            // CheckUserID
            // 
            this.CheckUserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CheckUserID.DataPropertyName = "CheckUserName";
            this.CheckUserID.HeaderText = "审核人";
            this.CheckUserID.Name = "CheckUserID";
            this.CheckUserID.ReadOnly = true;
            this.CheckUserID.Width = 65;
            // 
            // CheckStoreWinCount
            // 
            this.CheckStoreWinCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CheckStoreWinCount.DataPropertyName = "CheckStoreWinCount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CheckStoreWinCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.CheckStoreWinCount.HeaderText = "盘盈数";
            this.CheckStoreWinCount.Name = "CheckStoreWinCount";
            this.CheckStoreWinCount.ReadOnly = true;
            this.CheckStoreWinCount.Width = 70;
            // 
            // CheckStoreLostCount
            // 
            this.CheckStoreLostCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CheckStoreLostCount.DataPropertyName = "CheckStoreLostCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CheckStoreLostCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.CheckStoreLostCount.HeaderText = "盘亏数";
            this.CheckStoreLostCount.Name = "CheckStoreLostCount";
            this.CheckStoreLostCount.ReadOnly = true;
            this.CheckStoreLostCount.Width = 70;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.State.DataPropertyName = "StateName";
            this.State.HeaderText = "状态";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 54;
            // 
            // checkStoreOrderBindingSource
            // 
            this.checkStoreOrderBindingSource.DataSource = typeof(JGNet.CheckStoreOrder);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton1);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 342);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(699, 38);
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
            this.BaseButton1.Location = new System.Drawing.Point(618, 6);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 4;
            this.BaseButton1.Text = "关闭";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Quit_Click);
            // 
            // CostumeStoreTrackSearchProfitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 412);
            this.Controls.Add(this.skinPanel1);
            this.Name = "CostumeStoreTrackSearchProfitForm";
            this.Text = "盈亏明细";
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStoreOrderBindingSource)).EndInit();
            this.skinPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton1;
        private DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private DataGridViewLinkColumn totalCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private BindingSource checkStoreOrderBindingSource;
        private DataGridViewLinkColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DateInt;
        private DataGridViewTextBoxColumn ShopIDColumn;
        private DataGridViewTextBoxColumn operatorUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CheckUserID;
        private DataGridViewTextBoxColumn CheckStoreWinCount;
        private DataGridViewTextBoxColumn CheckStoreLostCount;
        private DataGridViewTextBoxColumn State;
    }
}
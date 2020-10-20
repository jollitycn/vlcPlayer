using CCWin.SkinControl;
using JGNet.Common;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Manage
{
    partial class RetailOrderSelectForm
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
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.memberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton2 = new JGNet.Common.Components.BaseButton();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.CostumeCurrentShopTextBox1 = new JGNet.Common.CostumeFromShopTextBox();
            this.retailOrderIDTextBox1 = new JGNet.Manage.RetailOrderIDTextBox();
            this.baseButton3 = new JGNet.Common.Components.BaseButton();
            this.skinLabel_CostumeID = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_OrderID = new CCWin.SkinControl.SkinLabel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memeberIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guideNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).BeginInit();
            this.skinPanel3.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.dataGridView1);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.Controls.Add(this.skinPanel2);
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
            this.ID,
            this.ShopName,
            this.memeberIDDataGridViewTextBoxColumn,
            this.guideNameDataGridViewTextBoxColumn,
            this.totalCountDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.memberBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(699, 303);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // memberBindingSource
            // 
            this.memberBindingSource.DataSource = typeof(JGNet.RetailOrder);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton2);
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
            // BaseButton2
            // 
            this.BaseButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton2.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton2.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton2.Location = new System.Drawing.Point(537, 6);
            this.BaseButton2.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton2.Name = "BaseButton2";
            this.BaseButton2.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton2.Size = new System.Drawing.Size(75, 32);
            this.BaseButton2.TabIndex = 3;
            this.BaseButton2.Text = "确定";
            this.BaseButton2.UseVisualStyleBackColor = false;
            this.BaseButton2.Click += new System.EventHandler(this.BaseButton_OK_Click);
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
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.CostumeCurrentShopTextBox1);
            this.skinPanel2.Controls.Add(this.retailOrderIDTextBox1);
            this.skinPanel2.Controls.Add(this.baseButton3);
            this.skinPanel2.Controls.Add(this.skinLabel_CostumeID);
            this.skinPanel2.Controls.Add(this.skinLabel_OrderID);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(699, 39);
            this.skinPanel2.TabIndex = 0;
            // 
            // CostumeCurrentShopTextBox1
            // 
            this.CostumeCurrentShopTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CostumeCurrentShopTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.CostumeCurrentShopTextBox1.DownBack = null;
            this.CostumeCurrentShopTextBox1.FilterValid = true;
            this.CostumeCurrentShopTextBox1.Icon = null;
            this.CostumeCurrentShopTextBox1.IconIsButton = false;
            this.CostumeCurrentShopTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.CostumeCurrentShopTextBox1.IsPasswordChat = '\0';
            this.CostumeCurrentShopTextBox1.IsSystemPasswordChar = false;
            this.CostumeCurrentShopTextBox1.Lines = new string[0];
            this.CostumeCurrentShopTextBox1.Location = new System.Drawing.Point(271, 3);
            this.CostumeCurrentShopTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.CostumeCurrentShopTextBox1.MaxLength = 32767;
            this.CostumeCurrentShopTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.CostumeCurrentShopTextBox1.MouseBack = null;
            this.CostumeCurrentShopTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.CostumeCurrentShopTextBox1.Multiline = false;
            this.CostumeCurrentShopTextBox1.Name = "CostumeCurrentShopTextBox1";
            this.CostumeCurrentShopTextBox1.NormlBack = null;
            this.CostumeCurrentShopTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.CostumeCurrentShopTextBox1.ReadOnly = false;
            this.CostumeCurrentShopTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CostumeCurrentShopTextBox1.ShopID = null;
            this.CostumeCurrentShopTextBox1.Size = new System.Drawing.Size(164, 28);
            // 
            // 
            // 
            this.CostumeCurrentShopTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostumeCurrentShopTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CostumeCurrentShopTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.CostumeCurrentShopTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.CostumeCurrentShopTextBox1.SkinTxt.Name = "BaseText";
            this.CostumeCurrentShopTextBox1.SkinTxt.Size = new System.Drawing.Size(154, 18);
            this.CostumeCurrentShopTextBox1.SkinTxt.TabIndex = 0;
            this.CostumeCurrentShopTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.CostumeCurrentShopTextBox1.SkinTxt.WaterText = "输入款号或条形码回车";
            this.CostumeCurrentShopTextBox1.SupplierID = null;
            this.CostumeCurrentShopTextBox1.TabIndex = 9;
            this.CostumeCurrentShopTextBox1.TabStop = true;
            this.CostumeCurrentShopTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CostumeCurrentShopTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.CostumeCurrentShopTextBox1.WaterText = "输入款号或条形码回车";
            this.CostumeCurrentShopTextBox1.WordWrap = true;
            // 
            // retailOrderIDTextBox1
            // 
            this.retailOrderIDTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.retailOrderIDTextBox1.DownBack = null;
            this.retailOrderIDTextBox1.Icon = null;
            this.retailOrderIDTextBox1.IconIsButton = false;
            this.retailOrderIDTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.retailOrderIDTextBox1.IsPasswordChat = '\0';
            this.retailOrderIDTextBox1.IsSystemPasswordChar = false;
            this.retailOrderIDTextBox1.Lines = new string[0];
            this.retailOrderIDTextBox1.Location = new System.Drawing.Point(38, 4);
            this.retailOrderIDTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.retailOrderIDTextBox1.MaxLength = 32767;
            this.retailOrderIDTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.retailOrderIDTextBox1.MouseBack = null;
            this.retailOrderIDTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.retailOrderIDTextBox1.Multiline = false;
            this.retailOrderIDTextBox1.Name = "retailOrderIDTextBox1";
            this.retailOrderIDTextBox1.NormlBack = null;
            this.retailOrderIDTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.retailOrderIDTextBox1.ReadOnly = false;
            this.retailOrderIDTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.retailOrderIDTextBox1.ShopID = null;
            this.retailOrderIDTextBox1.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.retailOrderIDTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.retailOrderIDTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retailOrderIDTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.retailOrderIDTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.retailOrderIDTextBox1.SkinTxt.Name = "BaseText";
            this.retailOrderIDTextBox1.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.retailOrderIDTextBox1.SkinTxt.TabIndex = 0;
            this.retailOrderIDTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.retailOrderIDTextBox1.SkinTxt.WaterText = "输入单号并回车";
            this.retailOrderIDTextBox1.TabIndex = 8;
            this.retailOrderIDTextBox1.TabStop = true;
            this.retailOrderIDTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.retailOrderIDTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.retailOrderIDTextBox1.WaterText = "输入单号并回车";
            this.retailOrderIDTextBox1.WordWrap = true;
            // 
            // baseButton3
            // 
            this.baseButton3.BackColor = System.Drawing.Color.Transparent;
            this.baseButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButton3.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButton3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButton3.Location = new System.Drawing.Point(463, 3);
            this.baseButton3.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButton3.Name = "baseButton3";
            this.baseButton3.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButton3.Size = new System.Drawing.Size(75, 32);
            this.baseButton3.TabIndex = 7;
            this.baseButton3.Text = "查找";
            this.baseButton3.UseVisualStyleBackColor = false;
            this.baseButton3.Click += new System.EventHandler(this.baseButton3_Click);
            // 
            // skinLabel_CostumeID
            // 
            this.skinLabel_CostumeID.AutoSize = true;
            this.skinLabel_CostumeID.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_CostumeID.BorderColor = System.Drawing.Color.White;
            this.skinLabel_CostumeID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_CostumeID.Location = new System.Drawing.Point(236, 9);
            this.skinLabel_CostumeID.Name = "skinLabel_CostumeID";
            this.skinLabel_CostumeID.Size = new System.Drawing.Size(32, 17);
            this.skinLabel_CostumeID.TabIndex = 4;
            this.skinLabel_CostumeID.Text = "款号";
            // 
            // skinLabel_OrderID
            // 
            this.skinLabel_OrderID.AutoSize = true;
            this.skinLabel_OrderID.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_OrderID.BorderColor = System.Drawing.Color.White;
            this.skinLabel_OrderID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_OrderID.Location = new System.Drawing.Point(3, 10);
            this.skinLabel_OrderID.Name = "skinLabel_OrderID";
            this.skinLabel_OrderID.Size = new System.Drawing.Size(32, 17);
            this.skinLabel_OrderID.TabIndex = 5;
            this.skinLabel_OrderID.Text = "单号";
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "销售单号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ShopName
            // 
            this.ShopName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShopName.DataPropertyName = "ShopName";
            this.ShopName.HeaderText = "店铺";
            this.ShopName.Name = "ShopName";
            this.ShopName.ReadOnly = true;
            this.ShopName.Width = 101;
            // 
            // memeberIDDataGridViewTextBoxColumn
            // 
            this.memeberIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.memeberIDDataGridViewTextBoxColumn.DataPropertyName = "MemeberID";
            this.memeberIDDataGridViewTextBoxColumn.HeaderText = "会员账号";
            this.memeberIDDataGridViewTextBoxColumn.Name = "memeberIDDataGridViewTextBoxColumn";
            this.memeberIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // guideNameDataGridViewTextBoxColumn
            // 
            this.guideNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.guideNameDataGridViewTextBoxColumn.DataPropertyName = "EntryUserName";
            this.guideNameDataGridViewTextBoxColumn.HeaderText = "制单人";
            this.guideNameDataGridViewTextBoxColumn.Name = "guideNameDataGridViewTextBoxColumn";
            this.guideNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalCountDataGridViewTextBoxColumn
            // 
            this.totalCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.totalCountDataGridViewTextBoxColumn.DataPropertyName = "TotalCount";
            this.totalCountDataGridViewTextBoxColumn.HeaderText = "总数量";
            this.totalCountDataGridViewTextBoxColumn.Name = "totalCountDataGridViewTextBoxColumn";
            this.totalCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalCountDataGridViewTextBoxColumn.Width = 101;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "开单时间";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarksDataGridViewTextBoxColumn.Width = 54;
            // 
            // RetailOrderSelectForm
            // 
            this.AcceptButton = this.BaseButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 412);
            this.Controls.Add(this.skinPanel1);
            this.Name = "RetailOrderSelectForm";
            this.Text = "销售单资料";
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).EndInit();
            this.skinPanel3.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private SkinPanel skinPanel2;
        private Common.Components.BaseButton BaseButton2;
        private Common.Components.BaseButton BaseButton1;
        private BindingSource memberBindingSource;
        private DataGridView dataGridView1;
        private BaseButton baseButton3;
        private SkinLabel skinLabel_CostumeID;
        private SkinLabel skinLabel_OrderID;
        private RetailOrderIDTextBox retailOrderIDTextBox1;
        private CostumeFromShopTextBox CostumeCurrentShopTextBox1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ShopName;
        private DataGridViewTextBoxColumn memeberIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn guideNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
    }
}
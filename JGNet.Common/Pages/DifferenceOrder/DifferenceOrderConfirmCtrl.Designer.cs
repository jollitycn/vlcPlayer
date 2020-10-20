using JGNet.Common;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class DifferenceOrderConfirmCtrl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.differenceDetailConfirmModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.baseButtonConfirm = new JGNet.Common.Components.BaseButton();
            this.BaseButtonCancel = new JGNet.Common.Components.BaseButton();
            this.guideComboBox1 = new JGNet.Common.GuideComboBox();
            this.skinLabel_operator = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_ReceiveShop = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_SendShop = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_OrderID = new CCWin.SkinControl.SkinLabel();
            this.costumeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outboundCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inboundCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.differenceCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceDetailConfirmModelBindingSource)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.costumeIDDataGridViewTextBoxColumn,
            this.costumeNameDataGridViewTextBoxColumn,
            this.colorNameDataGridViewTextBoxColumn,
            this.sizeNameDataGridViewTextBoxColumn,
            this.outboundCountDataGridViewTextBoxColumn,
            this.inboundCountDataGridViewTextBoxColumn,
            this.differenceCountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.differenceDetailConfirmModelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 612);
            this.dataGridView1.TabIndex = 2;
            // 
            // differenceDetailConfirmModelBindingSource
            // 
            this.differenceDetailConfirmModelBindingSource.DataSource = typeof(JGNet.Common.DifferenceDetailConfirmModel);
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.baseButtonConfirm);
            this.skinPanel1.Controls.Add(this.BaseButtonCancel);
            this.skinPanel1.Controls.Add(this.guideComboBox1);
            this.skinPanel1.Controls.Add(this.skinLabel_operator);
            this.skinPanel1.Controls.Add(this.skinLabel_ReceiveShop);
            this.skinPanel1.Controls.Add(this.skinLabel_SendShop);
            this.skinPanel1.Controls.Add(this.skinLabel_OrderID);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 38);
            this.skinPanel1.TabIndex = 0;
            // 
            // baseButtonConfirm
            // 
            this.baseButtonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseButtonConfirm.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonConfirm.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonConfirm.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonConfirm.Location = new System.Drawing.Point(967, 3);
            this.baseButtonConfirm.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonConfirm.Name = "baseButtonConfirm";
            this.baseButtonConfirm.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonConfirm.Size = new System.Drawing.Size(75, 32);
            this.baseButtonConfirm.TabIndex = 1;
            this.baseButtonConfirm.Text = "确认";
            this.baseButtonConfirm.UseVisualStyleBackColor = false;
            this.baseButtonConfirm.Click += new System.EventHandler(this.BaseButton1_Click);
            // 
            // BaseButtonCancel
            // 
            this.BaseButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButtonCancel.BackColor = System.Drawing.Color.Transparent;
            this.BaseButtonCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButtonCancel.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButtonCancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButtonCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButtonCancel.Location = new System.Drawing.Point(1048, 3);
            this.BaseButtonCancel.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButtonCancel.Name = "BaseButtonCancel";
            this.BaseButtonCancel.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButtonCancel.Size = new System.Drawing.Size(75, 32);
            this.BaseButtonCancel.TabIndex = 1;
            this.BaseButtonCancel.Text = "取消";
            this.BaseButtonCancel.UseVisualStyleBackColor = false;
            this.BaseButtonCancel.Click += new System.EventHandler(this.BaseButtonCancel_Click);
            // 
            // guideComboBox1
            // 
            this.guideComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guideComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guideComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guideComboBox1.FormattingEnabled = true;
            this.guideComboBox1.Location = new System.Drawing.Point(819, 6);
            this.guideComboBox1.Name = "guideComboBox1";
            this.guideComboBox1.ShopID = null;
            this.guideComboBox1.Size = new System.Drawing.Size(142, 22);
            this.guideComboBox1.TabIndex = 0;
            this.guideComboBox1.WaterText = "";
            // 
            // skinLabel_operator
            // 
            this.skinLabel_operator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLabel_operator.AutoSize = true;
            this.skinLabel_operator.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_operator.BorderColor = System.Drawing.Color.White;
            this.skinLabel_operator.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_operator.Location = new System.Drawing.Point(769, 9);
            this.skinLabel_operator.Name = "skinLabel_operator";
            this.skinLabel_operator.Size = new System.Drawing.Size(44, 17);
            this.skinLabel_operator.TabIndex = 8;
            this.skinLabel_operator.Text = "操作人";
            // 
            // skinLabel_ReceiveShop
            // 
            this.skinLabel_ReceiveShop.AutoSize = true;
            this.skinLabel_ReceiveShop.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_ReceiveShop.BorderColor = System.Drawing.Color.White;
            this.skinLabel_ReceiveShop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_ReceiveShop.Location = new System.Drawing.Point(399, 9);
            this.skinLabel_ReceiveShop.Name = "skinLabel_ReceiveShop";
            this.skinLabel_ReceiveShop.Size = new System.Drawing.Size(44, 17);
            this.skinLabel_ReceiveShop.TabIndex = 8;
            this.skinLabel_ReceiveShop.Text = "收货方";
            // 
            // skinLabel_SendShop
            // 
            this.skinLabel_SendShop.AutoSize = true;
            this.skinLabel_SendShop.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_SendShop.BorderColor = System.Drawing.Color.White;
            this.skinLabel_SendShop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_SendShop.Location = new System.Drawing.Point(222, 9);
            this.skinLabel_SendShop.Name = "skinLabel_SendShop";
            this.skinLabel_SendShop.Size = new System.Drawing.Size(44, 17);
            this.skinLabel_SendShop.TabIndex = 8;
            this.skinLabel_SendShop.Text = "发货方";
            // 
            // skinLabel_OrderID
            // 
            this.skinLabel_OrderID.AutoSize = true;
            this.skinLabel_OrderID.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_OrderID.BorderColor = System.Drawing.Color.White;
            this.skinLabel_OrderID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_OrderID.Location = new System.Drawing.Point(33, 9);
            this.skinLabel_OrderID.Name = "skinLabel_OrderID";
            this.skinLabel_OrderID.Size = new System.Drawing.Size(56, 17);
            this.skinLabel_OrderID.TabIndex = 6;
            this.skinLabel_OrderID.Text = "差异单号";
            this.skinLabel_OrderID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // costumeIDDataGridViewTextBoxColumn
            // 
            this.costumeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeIDDataGridViewTextBoxColumn.DataPropertyName = "CostumeID";
            this.costumeIDDataGridViewTextBoxColumn.HeaderText = "款号";
            this.costumeIDDataGridViewTextBoxColumn.Name = "costumeIDDataGridViewTextBoxColumn";
            this.costumeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeIDDataGridViewTextBoxColumn.Width = 160;
            // 
            // costumeNameDataGridViewTextBoxColumn
            // 
            this.costumeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeNameDataGridViewTextBoxColumn.DataPropertyName = "CostumeName";
            this.costumeNameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.costumeNameDataGridViewTextBoxColumn.Name = "costumeNameDataGridViewTextBoxColumn";
            this.costumeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "颜色";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // sizeNameDataGridViewTextBoxColumn
            // 
            this.sizeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeNameDataGridViewTextBoxColumn.DataPropertyName = "DisplaySizeName";
            this.sizeNameDataGridViewTextBoxColumn.HeaderText = "尺码";
            this.sizeNameDataGridViewTextBoxColumn.Name = "sizeNameDataGridViewTextBoxColumn";
            this.sizeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // outboundCountDataGridViewTextBoxColumn
            // 
            this.outboundCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.outboundCountDataGridViewTextBoxColumn.DataPropertyName = "OutboundCount";
            this.outboundCountDataGridViewTextBoxColumn.HeaderText = "出库数";
            this.outboundCountDataGridViewTextBoxColumn.Name = "outboundCountDataGridViewTextBoxColumn";
            this.outboundCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.outboundCountDataGridViewTextBoxColumn.Width = 160;
            // 
            // inboundCountDataGridViewTextBoxColumn
            // 
            this.inboundCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.inboundCountDataGridViewTextBoxColumn.DataPropertyName = "InboundCount";
            this.inboundCountDataGridViewTextBoxColumn.HeaderText = "入库数";
            this.inboundCountDataGridViewTextBoxColumn.Name = "inboundCountDataGridViewTextBoxColumn";
            this.inboundCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.inboundCountDataGridViewTextBoxColumn.Width = 160;
            // 
            // differenceCountDataGridViewTextBoxColumn
            // 
            this.differenceCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.differenceCountDataGridViewTextBoxColumn.DataPropertyName = "DifferenceCount";
            this.differenceCountDataGridViewTextBoxColumn.HeaderText = "差异数";
            this.differenceCountDataGridViewTextBoxColumn.Name = "differenceCountDataGridViewTextBoxColumn";
            this.differenceCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.differenceCountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.differenceCountDataGridViewTextBoxColumn.Width = 66;
            // 
            // DifferenceOrderConfirmCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "DifferenceOrderConfirmCtrl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceDetailConfirmModelBindingSource)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel_ReceiveShop;
        private CCWin.SkinControl.SkinLabel skinLabel_SendShop;
        private CCWin.SkinControl.SkinLabel skinLabel_OrderID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource differenceDetailConfirmModelBindingSource;
        private CCWin.SkinControl.SkinLabel skinLabel_operator;
        private GuideComboBox guideComboBox1;
        private Common.Components.BaseButton BaseButtonCancel;
        private Components.BaseButton baseButtonConfirm;
        private DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costumeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sizeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn outboundCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inboundCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn differenceCountDataGridViewTextBoxColumn;
    }
}

using CCWin.SkinControl;

namespace JGNet.Common
{
    partial class MemberManageCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberManageCtrl));
            this.memberBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.skinPanelSendGift = new System.Windows.Forms.Panel();
            this.downTemplateButton1 = new JGNet.Common.Components.DownTemplateButton();
            this.unconsumedComboBox = new CCWin.SkinControl.SkinComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baseButtonImport = new JGNet.Common.Components.BaseButton();
            this.guideComboBox1 = new JGNet.Common.GuideComboBox();
            this.skinComboBoxShopID = new JGNet.Common.ShopComboBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.baseButtonExport = new JGNet.Common.Components.BaseButton();
            this.skinCheckBox_showCurrentShopOnly = new CCWin.SkinControl.SkinCheckBox();
            this.skinComboBoxBigClass = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.baseButtonSendGift = new JGNet.Common.Components.BaseButton();
            this.baseButtonRecharge = new JGNet.Common.Components.BaseButton();
            this.BaseButtonAdd = new JGNet.Common.Components.BaseButton();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinTextBox_ID = new JGNet.Common.TextBox();
            this.phoneNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentIntegrationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accruedIntegrationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accruedSpendDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityOfBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guideIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).BeginInit();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.skinPanelSendGift.SuspendLayout();
            this.SuspendLayout();
            // 
            // memberBindingSource3
            // 
            this.memberBindingSource3.DataSource = typeof(JGNet.Member);
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.dataGridView1);
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.Location = new System.Drawing.Point(0, 71);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1160, 579);
            this.skinPanel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneNumberDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.sexNameDataGridViewTextBoxColumn,
            this.shopIDDataGridViewTextBoxColumn1,
            this.balanceDataGridViewTextBoxColumn1,
            this.currentIntegrationDataGridViewTextBoxColumn1,
            this.accruedIntegrationDataGridViewTextBoxColumn1,
            this.accruedSpendDataGridViewTextBoxColumn1,
            this.BuyCount,
            this.QuantityOfBuy,
            this.guideIDDataGridViewTextBoxColumn1,
            this.CreatedTime,
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column2});
            this.dataGridView1.DataSource = this.memberBindingSource3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 579);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // skinPanelSendGift
            // 
            this.skinPanelSendGift.AutoSize = true;
            this.skinPanelSendGift.BackColor = System.Drawing.Color.Transparent;
            this.skinPanelSendGift.Controls.Add(this.downTemplateButton1);
            this.skinPanelSendGift.Controls.Add(this.unconsumedComboBox);
            this.skinPanelSendGift.Controls.Add(this.label1);
            this.skinPanelSendGift.Controls.Add(this.baseButtonImport);
            this.skinPanelSendGift.Controls.Add(this.guideComboBox1);
            this.skinPanelSendGift.Controls.Add(this.skinComboBoxShopID);
            this.skinPanelSendGift.Controls.Add(this.skinLabel3);
            this.skinPanelSendGift.Controls.Add(this.skinLabel5);
            this.skinPanelSendGift.Controls.Add(this.baseButtonExport);
            this.skinPanelSendGift.Controls.Add(this.skinCheckBox_showCurrentShopOnly);
            this.skinPanelSendGift.Controls.Add(this.skinComboBoxBigClass);
            this.skinPanelSendGift.Controls.Add(this.skinLabel2);
            this.skinPanelSendGift.Controls.Add(this.skinLabel1);
            this.skinPanelSendGift.Controls.Add(this.baseButtonSendGift);
            this.skinPanelSendGift.Controls.Add(this.baseButtonRecharge);
            this.skinPanelSendGift.Controls.Add(this.BaseButtonAdd);
            this.skinPanelSendGift.Controls.Add(this.BaseButton1);
            this.skinPanelSendGift.Controls.Add(this.skinTextBox_ID);
            this.skinPanelSendGift.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanelSendGift.Location = new System.Drawing.Point(0, 0);
            this.skinPanelSendGift.Name = "skinPanelSendGift";
            this.skinPanelSendGift.Size = new System.Drawing.Size(1160, 71);
            this.skinPanelSendGift.TabIndex = 0;
            this.skinPanelSendGift.Paint += new System.Windows.Forms.PaintEventHandler(this.skinPanelSendGift_Paint);
            // 
            // downTemplateButton1
            // 
            this.downTemplateButton1.BackColor = System.Drawing.Color.Transparent;
            this.downTemplateButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.downTemplateButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("downTemplateButton1.DownBack")));
            this.downTemplateButton1.DownName = "会员导入模板.xls";
            this.downTemplateButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.downTemplateButton1.FileName = "importMember.xls";
            this.downTemplateButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downTemplateButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.downTemplateButton1.Location = new System.Drawing.Point(783, 36);
            this.downTemplateButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("downTemplateButton1.MouseBack")));
            this.downTemplateButton1.Name = "downTemplateButton1";
            this.downTemplateButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("downTemplateButton1.NormlBack")));
            this.downTemplateButton1.Size = new System.Drawing.Size(75, 32);
            this.downTemplateButton1.TabIndex = 145;
            this.downTemplateButton1.Text = "下载模板";
            this.downTemplateButton1.UseVisualStyleBackColor = false;
            this.downTemplateButton1.Click += new System.EventHandler(this.downTemplateButton1_Click);
            // 
            // unconsumedComboBox
            // 
            this.unconsumedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.unconsumedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unconsumedComboBox.FormattingEnabled = true;
            this.unconsumedComboBox.Location = new System.Drawing.Point(463, 6);
            this.unconsumedComboBox.Name = "unconsumedComboBox";
            this.unconsumedComboBox.Size = new System.Drawing.Size(120, 22);
            this.unconsumedComboBox.TabIndex = 19;
            this.unconsumedComboBox.WaterText = "";
            this.unconsumedComboBox.SelectedIndexChanged += new System.EventHandler(this.unconsumedComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "未消费天数";
            // 
            // baseButtonImport
            // 
            this.baseButtonImport.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonImport.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonImport.DownBack = ((System.Drawing.Image)(resources.GetObject("baseButtonImport.DownBack")));
            this.baseButtonImport.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonImport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonImport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.baseButtonImport.Location = new System.Drawing.Point(621, 36);
            this.baseButtonImport.MouseBack = ((System.Drawing.Image)(resources.GetObject("baseButtonImport.MouseBack")));
            this.baseButtonImport.Name = "baseButtonImport";
            this.baseButtonImport.NormlBack = ((System.Drawing.Image)(resources.GetObject("baseButtonImport.NormlBack")));
            this.baseButtonImport.Size = new System.Drawing.Size(75, 32);
            this.baseButtonImport.TabIndex = 16;
            this.baseButtonImport.Text = "导入";
            this.baseButtonImport.UseVisualStyleBackColor = false;
            this.baseButtonImport.Click += new System.EventHandler(this.baseButtonImport_Click);
            // 
            // guideComboBox1
            // 
            this.guideComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guideComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guideComboBox1.FormattingEnabled = true;
            this.guideComboBox1.Location = new System.Drawing.Point(265, 41);
            this.guideComboBox1.Name = "guideComboBox1";
            this.guideComboBox1.ShopID = null;
            this.guideComboBox1.Size = new System.Drawing.Size(115, 22);
            this.guideComboBox1.TabIndex = 15;
            this.guideComboBox1.WaterText = "";
            // 
            // skinComboBoxShopID
            // 
            this.skinComboBoxShopID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxShopID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxShopID.FormattingEnabled = true;
            this.skinComboBoxShopID.Location = new System.Drawing.Point(91, 42);
            this.skinComboBoxShopID.Name = "skinComboBoxShopID";
            this.skinComboBoxShopID.Size = new System.Drawing.Size(108, 22);
            this.skinComboBoxShopID.TabIndex = 13;
            this.skinComboBoxShopID.WaterText = "";
            this.skinComboBoxShopID.SelectedIndexChanged += new System.EventHandler(this.skinComboBoxShopID_SelectedIndexChanged);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(223, 44);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(36, 17);
            this.skinLabel3.TabIndex = 14;
            this.skinLabel3.Text = " 导购";
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(56, 45);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 14;
            this.skinLabel5.Text = "店铺";
            // 
            // baseButtonExport
            // 
            this.baseButtonExport.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonExport.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonExport.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonExport.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonExport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonExport.Location = new System.Drawing.Point(702, 36);
            this.baseButtonExport.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonExport.Name = "baseButtonExport";
            this.baseButtonExport.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonExport.Size = new System.Drawing.Size(75, 32);
            this.baseButtonExport.TabIndex = 12;
            this.baseButtonExport.Text = "导出";
            this.baseButtonExport.UseVisualStyleBackColor = false;
            this.baseButtonExport.Click += new System.EventHandler(this.baseButtonExport_Click);
            // 
            // skinCheckBox_showCurrentShopOnly
            // 
            this.skinCheckBox_showCurrentShopOnly.AutoSize = true;
            this.skinCheckBox_showCurrentShopOnly.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_showCurrentShopOnly.Checked = true;
            this.skinCheckBox_showCurrentShopOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox_showCurrentShopOnly.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_showCurrentShopOnly.DownBack = null;
            this.skinCheckBox_showCurrentShopOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_showCurrentShopOnly.Location = new System.Drawing.Point(394, 42);
            this.skinCheckBox_showCurrentShopOnly.MouseBack = null;
            this.skinCheckBox_showCurrentShopOnly.Name = "skinCheckBox_showCurrentShopOnly";
            this.skinCheckBox_showCurrentShopOnly.NormlBack = null;
            this.skinCheckBox_showCurrentShopOnly.SelectedDownBack = null;
            this.skinCheckBox_showCurrentShopOnly.SelectedMouseBack = null;
            this.skinCheckBox_showCurrentShopOnly.SelectedNormlBack = null;
            this.skinCheckBox_showCurrentShopOnly.Size = new System.Drawing.Size(75, 21);
            this.skinCheckBox_showCurrentShopOnly.TabIndex = 11;
            this.skinCheckBox_showCurrentShopOnly.Text = "只看本店";
            this.skinCheckBox_showCurrentShopOnly.UseVisualStyleBackColor = false;
            this.skinCheckBox_showCurrentShopOnly.CheckedChanged += new System.EventHandler(this.skinCheckBox_showCurrentShopOnly_CheckedChanged);
            // 
            // skinComboBoxBigClass
            // 
            this.skinComboBoxBigClass.DisplayMember = "BigClass";
            this.skinComboBoxBigClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxBigClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxBigClass.FormattingEnabled = true;
            this.skinComboBoxBigClass.Location = new System.Drawing.Point(265, 6);
            this.skinComboBoxBigClass.Name = "skinComboBoxBigClass";
            this.skinComboBoxBigClass.Size = new System.Drawing.Size(115, 22);
            this.skinComboBoxBigClass.TabIndex = 5;
            this.skinComboBoxBigClass.ValueMember = "BigClass";
            this.skinComboBoxBigClass.WaterText = "";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(203, 9);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(56, 17);
            this.skinLabel2.TabIndex = 4;
            this.skinLabel2.Text = "开卡时间";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(3, 10);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(85, 17);
            this.skinLabel1.TabIndex = 4;
            this.skinLabel1.Text = "会员卡号/姓名";
            // 
            // baseButtonSendGift
            // 
            this.baseButtonSendGift.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonSendGift.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonSendGift.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonSendGift.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonSendGift.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonSendGift.Location = new System.Drawing.Point(864, 3);
            this.baseButtonSendGift.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonSendGift.Name = "baseButtonSendGift";
            this.baseButtonSendGift.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonSendGift.Size = new System.Drawing.Size(83, 32);
            this.baseButtonSendGift.TabIndex = 2;
            this.baseButtonSendGift.Text = "发放优惠券";
            this.baseButtonSendGift.UseVisualStyleBackColor = false;
            this.baseButtonSendGift.Click += new System.EventHandler(this.baseButtonSendGift_Click);
            // 
            // baseButtonRecharge
            // 
            this.baseButtonRecharge.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonRecharge.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonRecharge.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonRecharge.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonRecharge.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonRecharge.Location = new System.Drawing.Point(783, 3);
            this.baseButtonRecharge.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonRecharge.Name = "baseButtonRecharge";
            this.baseButtonRecharge.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonRecharge.Size = new System.Drawing.Size(75, 32);
            this.baseButtonRecharge.TabIndex = 2;
            this.baseButtonRecharge.Text = "充值";
            this.baseButtonRecharge.UseVisualStyleBackColor = false;
            this.baseButtonRecharge.Click += new System.EventHandler(this.baseButtonRecharge_Click);
            // 
            // BaseButtonAdd
            // 
            this.BaseButtonAdd.BackColor = System.Drawing.Color.Transparent;
            this.BaseButtonAdd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButtonAdd.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButtonAdd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButtonAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButtonAdd.Location = new System.Drawing.Point(702, 3);
            this.BaseButtonAdd.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButtonAdd.Name = "BaseButtonAdd";
            this.BaseButtonAdd.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButtonAdd.Size = new System.Drawing.Size(75, 32);
            this.BaseButtonAdd.TabIndex = 2;
            this.BaseButtonAdd.Text = "开卡";
            this.BaseButtonAdd.UseVisualStyleBackColor = false;
            this.BaseButtonAdd.Click += new System.EventHandler(this.BaseButtonAdd_Click);
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(621, 3);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 1;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinTextBox_ID
            // 
            this.skinTextBox_ID.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_ID.DownBack = null;
            this.skinTextBox_ID.Icon = null;
            this.skinTextBox_ID.IconIsButton = false;
            this.skinTextBox_ID.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_ID.IsPasswordChat = '\0';
            this.skinTextBox_ID.IsSystemPasswordChar = false;
            this.skinTextBox_ID.Lines = new string[0];
            this.skinTextBox_ID.Location = new System.Drawing.Point(91, 4);
            this.skinTextBox_ID.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_ID.MaxLength = 32767;
            this.skinTextBox_ID.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_ID.MouseBack = null;
            this.skinTextBox_ID.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_ID.Multiline = false;
            this.skinTextBox_ID.Name = "skinTextBox_ID";
            this.skinTextBox_ID.NormlBack = null;
            this.skinTextBox_ID.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_ID.ReadOnly = false;
            this.skinTextBox_ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_ID.Size = new System.Drawing.Size(108, 28);
            // 
            // 
            // 
            this.skinTextBox_ID.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_ID.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_ID.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_ID.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_ID.SkinTxt.Name = "BaseText";
            this.skinTextBox_ID.SkinTxt.Size = new System.Drawing.Size(98, 18);
            this.skinTextBox_ID.SkinTxt.TabIndex = 0;
            this.skinTextBox_ID.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_ID.SkinTxt.WaterText = "会员卡号/姓名";
            this.skinTextBox_ID.TabIndex = 0;
            this.skinTextBox_ID.TabStop = true;
            this.skinTextBox_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_ID.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_ID.WaterText = "会员卡号/姓名";
            this.skinTextBox_ID.WordWrap = true;
            // 
            // phoneNumberDataGridViewTextBoxColumn1
            // 
            this.phoneNumberDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.phoneNumberDataGridViewTextBoxColumn1.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn1.HeaderText = "会员卡号";
            this.phoneNumberDataGridViewTextBoxColumn1.Name = "phoneNumberDataGridViewTextBoxColumn1";
            this.phoneNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.phoneNumberDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.phoneNumberDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "会员姓名";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sexNameDataGridViewTextBoxColumn
            // 
            this.sexNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sexNameDataGridViewTextBoxColumn.DataPropertyName = "SexName";
            this.sexNameDataGridViewTextBoxColumn.HeaderText = "性别";
            this.sexNameDataGridViewTextBoxColumn.Name = "sexNameDataGridViewTextBoxColumn";
            this.sexNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sexNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sexNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // shopIDDataGridViewTextBoxColumn1
            // 
            this.shopIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.shopIDDataGridViewTextBoxColumn1.DataPropertyName = "ShopName";
            this.shopIDDataGridViewTextBoxColumn1.HeaderText = "所属店铺";
            this.shopIDDataGridViewTextBoxColumn1.Name = "shopIDDataGridViewTextBoxColumn1";
            this.shopIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.shopIDDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shopIDDataGridViewTextBoxColumn1.Visible = false;
            this.shopIDDataGridViewTextBoxColumn1.Width = 80;
            // 
            // balanceDataGridViewTextBoxColumn1
            // 
            this.balanceDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.balanceDataGridViewTextBoxColumn1.DataPropertyName = "Balance";
            this.balanceDataGridViewTextBoxColumn1.HeaderText = "余额";
            this.balanceDataGridViewTextBoxColumn1.Name = "balanceDataGridViewTextBoxColumn1";
            this.balanceDataGridViewTextBoxColumn1.ReadOnly = true;
            this.balanceDataGridViewTextBoxColumn1.Width = 75;
            // 
            // currentIntegrationDataGridViewTextBoxColumn1
            // 
            this.currentIntegrationDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.currentIntegrationDataGridViewTextBoxColumn1.DataPropertyName = "CurrentIntegration";
            this.currentIntegrationDataGridViewTextBoxColumn1.HeaderText = "当前积分";
            this.currentIntegrationDataGridViewTextBoxColumn1.Name = "currentIntegrationDataGridViewTextBoxColumn1";
            this.currentIntegrationDataGridViewTextBoxColumn1.ReadOnly = true;
            this.currentIntegrationDataGridViewTextBoxColumn1.Width = 75;
            // 
            // accruedIntegrationDataGridViewTextBoxColumn1
            // 
            this.accruedIntegrationDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.accruedIntegrationDataGridViewTextBoxColumn1.DataPropertyName = "AccruedIntegration";
            this.accruedIntegrationDataGridViewTextBoxColumn1.HeaderText = "累计积分";
            this.accruedIntegrationDataGridViewTextBoxColumn1.Name = "accruedIntegrationDataGridViewTextBoxColumn1";
            this.accruedIntegrationDataGridViewTextBoxColumn1.ReadOnly = true;
            this.accruedIntegrationDataGridViewTextBoxColumn1.Width = 75;
            // 
            // accruedSpendDataGridViewTextBoxColumn1
            // 
            this.accruedSpendDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.accruedSpendDataGridViewTextBoxColumn1.DataPropertyName = "AccruedSpend";
            this.accruedSpendDataGridViewTextBoxColumn1.HeaderText = "累计消费";
            this.accruedSpendDataGridViewTextBoxColumn1.Name = "accruedSpendDataGridViewTextBoxColumn1";
            this.accruedSpendDataGridViewTextBoxColumn1.ReadOnly = true;
            this.accruedSpendDataGridViewTextBoxColumn1.Width = 75;
            // 
            // BuyCount
            // 
            this.BuyCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BuyCount.DataPropertyName = "BuyCount";
            this.BuyCount.HeaderText = "购买笔数";
            this.BuyCount.Name = "BuyCount";
            this.BuyCount.ReadOnly = true;
            // 
            // QuantityOfBuy
            // 
            this.QuantityOfBuy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantityOfBuy.DataPropertyName = "QuantityOfBuy";
            this.QuantityOfBuy.HeaderText = "购买数量";
            this.QuantityOfBuy.Name = "QuantityOfBuy";
            this.QuantityOfBuy.ReadOnly = true;
            // 
            // guideIDDataGridViewTextBoxColumn1
            // 
            this.guideIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.guideIDDataGridViewTextBoxColumn1.DataPropertyName = "GuideName";
            this.guideIDDataGridViewTextBoxColumn1.HeaderText = "办卡人";
            this.guideIDDataGridViewTextBoxColumn1.Name = "guideIDDataGridViewTextBoxColumn1";
            this.guideIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.guideIDDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.guideIDDataGridViewTextBoxColumn1.Visible = false;
            this.guideIDDataGridViewTextBoxColumn1.Width = 75;
            // 
            // CreatedTime
            // 
            this.CreatedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreatedTime.DataPropertyName = "CreatedTime";
            this.CreatedTime.HeaderText = "开卡时间";
            this.CreatedTime.Name = "CreatedTime";
            this.CreatedTime.ReadOnly = true;
            this.CreatedTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CreatedTime.Width = 120;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "编辑";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Text = "编辑";
            this.Column3.UseColumnTextForLinkValue = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "消费历史";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Text = "消费历史";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.Width = 80;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "充值记录";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Text = "充值记录";
            this.Column1.UseColumnTextForLinkValue = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "优惠券";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Text = "优惠券";
            this.Column2.UseColumnTextForLinkValue = true;
            this.Column2.Width = 66;
            // 
            // MemberManageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanelSendGift);
            this.Name = "MemberManageCtrl";
            this.Load += new System.EventHandler(this.MemberManageCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.skinPanelSendGift.ResumeLayout(false);
            this.skinPanelSendGift.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel skinPanelSendGift;
        private  JGNet.Common.TextBox skinTextBox_ID;
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.BindingSource memberBindingSource3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Common.Components.BaseButton BaseButton1;
        private Common.Components.BaseButton BaseButtonAdd;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private Components.BaseButton baseButtonSendGift;
        private CCWin.SkinControl.SkinComboBox skinComboBoxBigClass;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_showCurrentShopOnly;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private Components.BaseButton baseButtonExport;
        private ShopComboBox skinComboBoxShopID;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private GuideComboBox guideComboBox1;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private Components.BaseButton baseButtonRecharge;
        private Components.BaseButton baseButtonImport;
        private SkinComboBox unconsumedComboBox;
        private System.Windows.Forms.Label label1;
        private Components.DownTemplateButton downTemplateButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentIntegrationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn accruedIntegrationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn accruedSpendDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityOfBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn guideIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedTime;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
    }
}

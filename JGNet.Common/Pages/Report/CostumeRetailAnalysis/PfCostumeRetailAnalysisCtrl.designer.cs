using CCWin.SkinControl;
using JGNet.Common;

namespace JGNet.Common
{
    partial class PfCostumeRetailAnalysisCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PfCostumeRetailAnalysisCtrl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.salesAnalysisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.baseButton1 = new JGNet.Common.Components.BaseButton();
            this.pfCustomerComboBox1 = new JGNet.Common.PfCustomerComboBox();
            this.baseButton2 = new JGNet.Common.Components.BaseButton();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBoxBigClass = new JGNet.Common.CostumeClassSelector();
            this.label4 = new System.Windows.Forms.Label();
            this.skinComboBox_Brand = new JGNet.Common.BrandComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBoxID = new JGNet.Common.CostumeTextBox();
            this.quickDateSelector1 = new JGNet.Common.Components.QuickDateSelector(this.components);
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBoxGroup = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.BaseButton_Search = new JGNet.Common.Components.BaseButton();
            this.skinComboBoxSupplier = new JGNet.Common.Components.SupllierComboBox();
            this.TypeValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeValue8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailCostPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailBenefitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailBenefitRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesAnalysisBindingSource)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.dataGridView1);
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.Location = new System.Drawing.Point(0, 68);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1160, 582);
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
            this.TypeValue1,
            this.TypeValue2,
            this.TypeValue3,
            this.TypeValue4,
            this.TypeValue5,
            this.TypeValue6,
            this.TypeValue7,
            this.TypeValue8,
            this.retailCountDataGridViewTextBoxColumn,
            this.Column2,
            this.Column3,
            this.Column4,
            this.retailCostPriceDataGridViewTextBoxColumn,
            this.retailBenefitDataGridViewTextBoxColumn,
            this.retailBenefitRateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.salesAnalysisBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 582);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // salesAnalysisBindingSource
            // 
            this.salesAnalysisBindingSource.DataSource = typeof(JGNet.Core.InteractEntity.PfRetailAnalysisInfo);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.baseButton1);
            this.skinPanel1.Controls.Add(this.pfCustomerComboBox1);
            this.skinPanel1.Controls.Add(this.baseButton2);
            this.skinPanel1.Controls.Add(this.skinLabel6);
            this.skinPanel1.Controls.Add(this.skinComboBoxBigClass);
            this.skinPanel1.Controls.Add(this.label4);
            this.skinPanel1.Controls.Add(this.skinComboBox_Brand);
            this.skinPanel1.Controls.Add(this.label3);
            this.skinPanel1.Controls.Add(this.skinLabel5);
            this.skinPanel1.Controls.Add(this.skinTextBoxID);
            this.skinPanel1.Controls.Add(this.quickDateSelector1);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.skinComboBoxGroup);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.BaseButton_Search);
            this.skinPanel1.Controls.Add(this.skinComboBoxSupplier);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 68);
            this.skinPanel1.TabIndex = 0;
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.Color.Transparent;
            this.baseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButton1.Location = new System.Drawing.Point(769, 33);
            this.baseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButton1.Size = new System.Drawing.Size(75, 32);
            this.baseButton1.TabIndex = 146;
            this.baseButton1.Text = "导出";
            this.baseButton1.UseVisualStyleBackColor = false;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // pfCustomerComboBox1
            // 
            this.pfCustomerComboBox1.CheckPfCustomer = false;
            this.pfCustomerComboBox1.curSelectStr = null;
            this.pfCustomerComboBox1.CustomerTypeValue = -1;
            this.pfCustomerComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pfCustomerComboBox1.FormattingEnabled = true;
            this.pfCustomerComboBox1.HideEmpty = false;
            this.pfCustomerComboBox1.Location = new System.Drawing.Point(326, 7);
            this.pfCustomerComboBox1.Name = "pfCustomerComboBox1";
            this.pfCustomerComboBox1.Size = new System.Drawing.Size(142, 22);
            this.pfCustomerComboBox1.TabIndex = 145;
            this.pfCustomerComboBox1.WaterText = "";
            // 
            // baseButton2
            // 
            this.baseButton2.BackColor = System.Drawing.Color.Transparent;
            this.baseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButton2.DownBack = ((System.Drawing.Image)(resources.GetObject("baseButton2.DownBack")));
            this.baseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButton2.Location = new System.Drawing.Point(231, 3);
            this.baseButton2.MouseBack = ((System.Drawing.Image)(resources.GetObject("baseButton2.MouseBack")));
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.NormlBack = ((System.Drawing.Image)(resources.GetObject("baseButton2.NormlBack")));
            this.baseButton2.Size = new System.Drawing.Size(50, 32);
            this.baseButton2.TabIndex = 144;
            this.baseButton2.Text = "...";
            this.baseButton2.UseVisualStyleBackColor = false;
            this.baseButton2.Click += new System.EventHandler(this.baseButton2_Click);
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(472, 9);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(44, 17);
            this.skinLabel6.TabIndex = 143;
            this.skinLabel6.Text = "供应商";
            // 
            // skinComboBoxBigClass
            // 
            this.skinComboBoxBigClass.AutoSize = true;
            this.skinComboBoxBigClass.Location = new System.Drawing.Point(858, 3);
            this.skinComboBoxBigClass.Name = "skinComboBoxBigClass";
            this.skinComboBoxBigClass.SelectedValue = ((JGNet.Costume)(resources.GetObject("skinComboBoxBigClass.SelectedValue")));
            this.skinComboBoxBigClass.Size = new System.Drawing.Size(151, 29);
            this.skinComboBoxBigClass.TabIndex = 138;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(823, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 141;
            this.label4.Text = "类别";
            // 
            // skinComboBox_Brand
            // 
            this.skinComboBox_Brand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Brand.FormattingEnabled = true;
            this.skinComboBox_Brand.Location = new System.Drawing.Point(697, 7);
            this.skinComboBox_Brand.Name = "skinComboBox_Brand";
            this.skinComboBox_Brand.SelectStr = null;
            this.skinComboBox_Brand.ShowAll = true;
            this.skinComboBox_Brand.Size = new System.Drawing.Size(108, 22);
            this.skinComboBox_Brand.SupplierID = null;
            this.skinComboBox_Brand.TabIndex = 140;
            this.skinComboBox_Brand.WaterText = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 139;
            this.label3.Text = "品牌";
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(26, 42);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 131;
            this.skinLabel5.Text = "款号";
            // 
            // skinTextBoxID
            // 
            this.skinTextBoxID.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxID.DownBack = null;
            this.skinTextBoxID.FilterValid = true;
            this.skinTextBoxID.Icon = null;
            this.skinTextBoxID.IconIsButton = false;
            this.skinTextBoxID.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxID.IsPasswordChat = '\0';
            this.skinTextBoxID.IsSystemPasswordChar = false;
            this.skinTextBoxID.Lines = new string[0];
            this.skinTextBoxID.Location = new System.Drawing.Point(66, 36);
            this.skinTextBoxID.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxID.MaxLength = 32767;
            this.skinTextBoxID.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxID.MouseBack = null;
            this.skinTextBoxID.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxID.Multiline = false;
            this.skinTextBoxID.Name = "skinTextBoxID";
            this.skinTextBoxID.NormlBack = null;
            this.skinTextBoxID.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxID.ReadOnly = false;
            this.skinTextBoxID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxID.Size = new System.Drawing.Size(156, 28);
            // 
            // 
            // 
            this.skinTextBoxID.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxID.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxID.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxID.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxID.SkinTxt.Name = "BaseText";
            this.skinTextBoxID.SkinTxt.Size = new System.Drawing.Size(146, 18);
            this.skinTextBoxID.SkinTxt.TabIndex = 0;
            this.skinTextBoxID.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxID.SkinTxt.WaterText = "";
            this.skinTextBoxID.TabIndex = 130;
            this.skinTextBoxID.TabStop = true;
            this.skinTextBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxID.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxID.WaterText = "";
            this.skinTextBoxID.WordWrap = true;
            this.skinTextBoxID.CostumeSelected += new CJBasic.Action<JGNet.Costume, bool>(this.skinTextBoxID_CostumeSelected);
            // 
            // quickDateSelector1
            // 
            this.quickDateSelector1.Arrow = System.Drawing.Color.Black;
            this.quickDateSelector1.Back = System.Drawing.Color.White;
            this.quickDateSelector1.BackRadius = 4;
            this.quickDateSelector1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.quickDateSelector1.Base = System.Drawing.Color.Transparent;
            this.quickDateSelector1.BaseFore = System.Drawing.Color.Black;
            this.quickDateSelector1.BaseForeAnamorphosis = false;
            this.quickDateSelector1.BaseForeAnamorphosisBorder = 4;
            this.quickDateSelector1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.quickDateSelector1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.quickDateSelector1.BaseHoverFore = System.Drawing.Color.White;
            this.quickDateSelector1.BaseItemAnamorphosis = true;
            this.quickDateSelector1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.BaseItemBorderShow = true;
            this.quickDateSelector1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("quickDateSelector1.BaseItemDown")));
            this.quickDateSelector1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("quickDateSelector1.BaseItemMouse")));
            this.quickDateSelector1.BaseItemNorml = null;
            this.quickDateSelector1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.BaseItemRadius = 4;
            this.quickDateSelector1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.BindTabControl = null;
            this.quickDateSelector1.Dock = System.Windows.Forms.DockStyle.None;
            this.quickDateSelector1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.quickDateSelector1.EndDateTimePicker = this.dateTimePicker_End;
            this.quickDateSelector1.Fore = System.Drawing.Color.Black;
            this.quickDateSelector1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.quickDateSelector1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.quickDateSelector1.HoverFore = System.Drawing.Color.White;
            this.quickDateSelector1.ItemAnamorphosis = true;
            this.quickDateSelector1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemBorderShow = true;
            this.quickDateSelector1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemRadius = 4;
            this.quickDateSelector1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Location = new System.Drawing.Point(653, 38);
            this.quickDateSelector1.Name = "quickDateSelector1";
            this.quickDateSelector1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Size = new System.Drawing.Size(32, 25);
            this.quickDateSelector1.SkinAllColor = true;
            this.quickDateSelector1.StartDateTimePicker = this.dateTimePicker_Start;
            this.quickDateSelector1.TabIndex = 129;
            this.quickDateSelector1.Text = "quickDateSelector1";
            this.quickDateSelector1.TitleAnamorphosis = true;
            this.quickDateSelector1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.quickDateSelector1.TitleRadius = 4;
            this.quickDateSelector1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.PickerValueChanged += new CJBasic.Action<object, System.EventArgs>(this.BaseButton_Search_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(512, 40);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker_End.TabIndex = 126;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(326, 40);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker_Start.TabIndex = 125;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(474, 42);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 127;
            this.skinLabel1.Text = "结束";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(287, 42);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 128;
            this.skinLabel2.Text = "开始";
            // 
            // skinComboBoxGroup
            // 
            this.skinComboBoxGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxGroup.FormattingEnabled = true;
            this.skinComboBoxGroup.Location = new System.Drawing.Point(67, 6);
            this.skinComboBoxGroup.Name = "skinComboBoxGroup";
            this.skinComboBoxGroup.Size = new System.Drawing.Size(158, 22);
            this.skinComboBoxGroup.TabIndex = 28;
            this.skinComboBoxGroup.WaterText = "";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(5, 9);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(56, 17);
            this.skinLabel3.TabIndex = 30;
            this.skinLabel3.Text = "汇总方式";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(288, 9);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(32, 17);
            this.skinLabel4.TabIndex = 36;
            this.skinLabel4.Text = "客户";
            this.skinLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BaseButton_Search
            // 
            this.BaseButton_Search.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Search.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Search.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Search.Location = new System.Drawing.Point(688, 34);
            this.BaseButton_Search.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_Search.Name = "BaseButton_Search";
            this.BaseButton_Search.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_Search.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_Search.TabIndex = 34;
            this.BaseButton_Search.Text = "查询";
            this.BaseButton_Search.UseVisualStyleBackColor = false;
            this.BaseButton_Search.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinComboBoxSupplier
            // 
            this.skinComboBoxSupplier.AutoSize = true;
            this.skinComboBoxSupplier.BackColor = System.Drawing.Color.Transparent;
            this.skinComboBoxSupplier.EnabledSupplier = true;
            this.skinComboBoxSupplier.HideAll = false;
            this.skinComboBoxSupplier.Location = new System.Drawing.Point(524, 6);
            this.skinComboBoxSupplier.Name = "skinComboBoxSupplier";
            this.skinComboBoxSupplier.SelectedItem = ((JGNet.Supplier)(resources.GetObject("skinComboBoxSupplier.SelectedItem")));
            this.skinComboBoxSupplier.SelectedValue = null;
            this.skinComboBoxSupplier.ShowAdd = false;
            this.skinComboBoxSupplier.Size = new System.Drawing.Size(119, 26);
            this.skinComboBoxSupplier.TabIndex = 142;
            this.skinComboBoxSupplier.Title = null;
            // 
            // TypeValue1
            // 
            this.TypeValue1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue1.DataPropertyName = "TypeValue1";
            this.TypeValue1.HeaderText = "TypeValue1";
            this.TypeValue1.Name = "TypeValue1";
            this.TypeValue1.ReadOnly = true;
            this.TypeValue1.Visible = false;
            // 
            // TypeValue2
            // 
            this.TypeValue2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue2.DataPropertyName = "TypeValue2";
            this.TypeValue2.HeaderText = "TypeValue2";
            this.TypeValue2.Name = "TypeValue2";
            this.TypeValue2.ReadOnly = true;
            this.TypeValue2.Visible = false;
            // 
            // TypeValue3
            // 
            this.TypeValue3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue3.DataPropertyName = "TypeValue3";
            this.TypeValue3.HeaderText = "TypeValue3";
            this.TypeValue3.Name = "TypeValue3";
            this.TypeValue3.ReadOnly = true;
            this.TypeValue3.Visible = false;
            // 
            // TypeValue4
            // 
            this.TypeValue4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue4.DataPropertyName = "TypeValue4";
            this.TypeValue4.HeaderText = "TypeValue4";
            this.TypeValue4.Name = "TypeValue4";
            this.TypeValue4.ReadOnly = true;
            this.TypeValue4.Visible = false;
            // 
            // TypeValue5
            // 
            this.TypeValue5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue5.DataPropertyName = "TypeValue5";
            this.TypeValue5.HeaderText = "TypeValue5";
            this.TypeValue5.Name = "TypeValue5";
            this.TypeValue5.ReadOnly = true;
            this.TypeValue5.Visible = false;
            // 
            // TypeValue6
            // 
            this.TypeValue6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue6.DataPropertyName = "TypeValue6";
            this.TypeValue6.HeaderText = "TypeValue6";
            this.TypeValue6.Name = "TypeValue6";
            this.TypeValue6.ReadOnly = true;
            this.TypeValue6.Visible = false;
            // 
            // TypeValue7
            // 
            this.TypeValue7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue7.DataPropertyName = "TypeValue7";
            this.TypeValue7.HeaderText = "TypeValue7";
            this.TypeValue7.Name = "TypeValue7";
            this.TypeValue7.ReadOnly = true;
            this.TypeValue7.Visible = false;
            // 
            // TypeValue8
            // 
            this.TypeValue8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TypeValue8.DataPropertyName = "TypeValue8";
            this.TypeValue8.HeaderText = "TypeValue8";
            this.TypeValue8.Name = "TypeValue8";
            this.TypeValue8.ReadOnly = true;
            this.TypeValue8.Visible = false;
            // 
            // retailCountDataGridViewTextBoxColumn
            // 
            this.retailCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.retailCountDataGridViewTextBoxColumn.DataPropertyName = "RetailCount";
            this.retailCountDataGridViewTextBoxColumn.HeaderText = "销量";
            this.retailCountDataGridViewTextBoxColumn.Name = "retailCountDataGridViewTextBoxColumn";
            this.retailCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailCountDataGridViewTextBoxColumn.Width = 160;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "RetailRate";
            dataGridViewCellStyle1.Format = "P0";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "销量占比";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ToolTipText = "这个分组的销量 / 所有分组加起来的总销量";
            this.Column2.Width = 159;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "RetailMoney";
            this.Column3.HeaderText = "销售额";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 160;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "RetailMoneyRate";
            dataGridViewCellStyle2.Format = "P0";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "销售占比";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.ToolTipText = "这个分组的销售额 / 所有分组加起来的总销售额";
            this.Column4.Width = 159;
            // 
            // retailCostPriceDataGridViewTextBoxColumn
            // 
            this.retailCostPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.retailCostPriceDataGridViewTextBoxColumn.DataPropertyName = "RetailCostPrice";
            this.retailCostPriceDataGridViewTextBoxColumn.HeaderText = "销售成本";
            this.retailCostPriceDataGridViewTextBoxColumn.Name = "retailCostPriceDataGridViewTextBoxColumn";
            this.retailCostPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailCostPriceDataGridViewTextBoxColumn.Width = 160;
            // 
            // retailBenefitDataGridViewTextBoxColumn
            // 
            this.retailBenefitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.retailBenefitDataGridViewTextBoxColumn.DataPropertyName = "RetailBenefit";
            this.retailBenefitDataGridViewTextBoxColumn.HeaderText = "毛利";
            this.retailBenefitDataGridViewTextBoxColumn.Name = "retailBenefitDataGridViewTextBoxColumn";
            this.retailBenefitDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailBenefitDataGridViewTextBoxColumn.Width = 159;
            // 
            // retailBenefitRateDataGridViewTextBoxColumn
            // 
            this.retailBenefitRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.retailBenefitRateDataGridViewTextBoxColumn.DataPropertyName = "RetailBenefitRate";
            this.retailBenefitRateDataGridViewTextBoxColumn.HeaderText = "毛利率";
            this.retailBenefitRateDataGridViewTextBoxColumn.Name = "retailBenefitRateDataGridViewTextBoxColumn";
            this.retailBenefitRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailBenefitRateDataGridViewTextBoxColumn.Width = 160;
            // 
            // PfCostumeRetailAnalysisCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanel1);
            this.Name = "PfCostumeRetailAnalysisCtrl";
            this.Load += new System.EventHandler(this.CostumeManageCtrl_Load);
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesAnalysisBindingSource)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SkinComboBox skinComboBoxGroup;
        private SkinLabel skinLabel3;
        private SkinLabel skinLabel4;
        private Common.Components.BaseButton BaseButton_Search;
        private Components.QuickDateSelector quickDateSelector1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private SkinLabel skinLabel1;
        private SkinLabel skinLabel2;
        private SkinLabel skinLabel5;
        private CostumeTextBox skinTextBoxID;
        private CostumeClassSelector skinComboBoxBigClass;
        private System.Windows.Forms.Label label4;
        private BrandComboBox skinComboBox_Brand;
        private System.Windows.Forms.Label label3;
        private SkinLabel skinLabel6;
        private Components.SupllierComboBox skinComboBoxSupplier;
        private Components.BaseButton baseButton2;
        private System.Windows.Forms.BindingSource salesAnalysisBindingSource;
        private PfCustomerComboBox pfCustomerComboBox1;
        private Components.BaseButton baseButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue6;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeValue8;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailCostPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailBenefitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailBenefitRateDataGridViewTextBoxColumn;
    }
}

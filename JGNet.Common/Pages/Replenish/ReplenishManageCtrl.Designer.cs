namespace JGNet.Common
{
    partial class ReplenishManageCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplenishManageCtrl));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.replenishOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.quickDateSelector1 = new JGNet.Common.Components.QuickDateSelector(this.components);
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.BaseButton_search = new JGNet.Common.Components.BaseButton();
            this.imageHelp1 = new JGNet.Common.Components.ImageHelp();
            this.costumeTextBox1 = new JGNet.Common.CostumeTextBox();
            this.skinComboBoxShopID = new JGNet.Common.ShopComboBox();
            this.skinComboBoxState = new CCWin.SkinControl.SkinComboBox();
            this.skinTextBox_OrderID = new JGNet.Common.TextBox();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column_ShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuideName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_send = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnCancel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnReject = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPick = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replenishOrderBindingSource)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Column_ShopName,
            this.totalCountDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn,
            this.GuideName,
            this.createTimeDataGridViewTextBoxColumn,
            this.FinishedTime,
            this.stateNameDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.column_send,
            this.ColumnCancel,
            this.ColumnReject,
            this.ColumnPick,
            this.Column1,
            this.ColumnPrint});
            this.dataGridView1.DataSource = this.replenishOrderBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 216);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // replenishOrderBindingSource
            // 
            this.replenishOrderBindingSource.DataSource = typeof(JGNet.ReplenishOrder);
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.quickDateSelector1);
            this.skinPanel1.Controls.Add(this.BaseButton_search);
            this.skinPanel1.Controls.Add(this.imageHelp1);
            this.skinPanel1.Controls.Add(this.costumeTextBox1);
            this.skinPanel1.Controls.Add(this.skinComboBoxShopID);
            this.skinPanel1.Controls.Add(this.skinComboBoxState);
            this.skinPanel1.Controls.Add(this.skinTextBox_OrderID);
            this.skinPanel1.Controls.Add(this.skinLabel10);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.skinLabel5);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 62);
            this.skinPanel1.TabIndex = 0;
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
            this.quickDateSelector1.Location = new System.Drawing.Point(735, 6);
            this.quickDateSelector1.Name = "quickDateSelector1";
            this.quickDateSelector1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Size = new System.Drawing.Size(32, 25);
            this.quickDateSelector1.SkinAllColor = true;
            this.quickDateSelector1.StartDateTimePicker = this.dateTimePicker_Start;
            this.quickDateSelector1.TabIndex = 123;
            this.quickDateSelector1.Text = "quickDateSelector1";
            this.quickDateSelector1.TitleAnamorphosis = true;
            this.quickDateSelector1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.quickDateSelector1.TitleRadius = 4;
            this.quickDateSelector1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.PickerValueChanged += new CJBasic.Action<object, System.EventArgs>(this.BaseButton_Search_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(587, 8);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(401, 8);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 2;
            // 
            // BaseButton_search
            // 
            this.BaseButton_search.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_search.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_search.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_search.Location = new System.Drawing.Point(770, 3);
            this.BaseButton_search.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_search.Name = "BaseButton_search";
            this.BaseButton_search.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_search.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_search.TabIndex = 6;
            this.BaseButton_search.Text = "查询";
            this.BaseButton_search.UseVisualStyleBackColor = false;
            this.BaseButton_search.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // imageHelp1
            // 
            this.imageHelp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageHelp1.BackColor = System.Drawing.Color.Transparent;
            this.imageHelp1.Control = this;
            this.imageHelp1.Image = global::JGNet.Common.Properties.Resources.补货流程;
            this.imageHelp1.Location = new System.Drawing.Point(1133, 0);
            this.imageHelp1.Name = "imageHelp1";
            this.imageHelp1.Size = new System.Drawing.Size(24, 24);
            this.imageHelp1.TabIndex = 16;
            // 
            // costumeTextBox1
            // 
            this.costumeTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.costumeTextBox1.DownBack = null;
            this.costumeTextBox1.FilterValid = true;
            this.costumeTextBox1.Icon = null;
            this.costumeTextBox1.IconIsButton = false;
            this.costumeTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.costumeTextBox1.IsPasswordChat = '\0';
            this.costumeTextBox1.IsSystemPasswordChar = false;
            this.costumeTextBox1.Lines = new string[0];
            this.costumeTextBox1.Location = new System.Drawing.Point(218, 5);
            this.costumeTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.costumeTextBox1.MaxLength = 32767;
            this.costumeTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.costumeTextBox1.MouseBack = null;
            this.costumeTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.costumeTextBox1.Multiline = false;
            this.costumeTextBox1.Name = "costumeTextBox1";
            this.costumeTextBox1.NormlBack = null;
            this.costumeTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.costumeTextBox1.ReadOnly = false;
            this.costumeTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.costumeTextBox1.Size = new System.Drawing.Size(142, 28);
            // 
            // 
            // 
            this.costumeTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.costumeTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.costumeTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.costumeTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.costumeTextBox1.SkinTxt.Name = "BaseText";
            this.costumeTextBox1.SkinTxt.Size = new System.Drawing.Size(132, 18);
            this.costumeTextBox1.SkinTxt.TabIndex = 0;
            this.costumeTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.costumeTextBox1.SkinTxt.WaterText = "";
            this.costumeTextBox1.TabIndex = 1;
            this.costumeTextBox1.TabStop = true;
            this.costumeTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.costumeTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.costumeTextBox1.WaterText = "";
            this.costumeTextBox1.WordWrap = true;
            this.costumeTextBox1.CostumeSelected += new CJBasic.Action<JGNet.Costume, bool>(this.costumeTextBox1_CostumeSelected);
            // 
            // skinComboBoxShopID
            // 
            this.skinComboBoxShopID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxShopID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxShopID.FormattingEnabled = true;
            this.skinComboBoxShopID.Location = new System.Drawing.Point(38, 37);
            this.skinComboBoxShopID.Name = "skinComboBoxShopID";
            this.skinComboBoxShopID.Size = new System.Drawing.Size(142, 22);
            this.skinComboBoxShopID.TabIndex = 4;
            this.skinComboBoxShopID.WaterText = "";
            this.skinComboBoxShopID.SelectedIndexChanged += new System.EventHandler(this.skinComboBoxShopID_SelectedIndexChanged);
            // 
            // skinComboBoxState
            // 
            this.skinComboBoxState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxState.FormattingEnabled = true;
            this.skinComboBoxState.Location = new System.Drawing.Point(218, 37);
            this.skinComboBoxState.Name = "skinComboBoxState";
            this.skinComboBoxState.Size = new System.Drawing.Size(142, 22);
            this.skinComboBoxState.TabIndex = 5;
            this.skinComboBoxState.WaterText = "";
            // 
            // skinTextBox_OrderID
            // 
            this.skinTextBox_OrderID.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_OrderID.DownBack = null;
            this.skinTextBox_OrderID.Icon = null;
            this.skinTextBox_OrderID.IconIsButton = false;
            this.skinTextBox_OrderID.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_OrderID.IsPasswordChat = '\0';
            this.skinTextBox_OrderID.IsSystemPasswordChar = false;
            this.skinTextBox_OrderID.Lines = new string[0];
            this.skinTextBox_OrderID.Location = new System.Drawing.Point(38, 5);
            this.skinTextBox_OrderID.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_OrderID.MaxLength = 32767;
            this.skinTextBox_OrderID.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_OrderID.MouseBack = null;
            this.skinTextBox_OrderID.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_OrderID.Multiline = false;
            this.skinTextBox_OrderID.Name = "skinTextBox_OrderID";
            this.skinTextBox_OrderID.NormlBack = null;
            this.skinTextBox_OrderID.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_OrderID.ReadOnly = false;
            this.skinTextBox_OrderID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_OrderID.Size = new System.Drawing.Size(142, 28);
            // 
            // 
            // 
            this.skinTextBox_OrderID.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_OrderID.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_OrderID.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_OrderID.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_OrderID.SkinTxt.Name = "BaseText";
            this.skinTextBox_OrderID.SkinTxt.Size = new System.Drawing.Size(132, 18);
            this.skinTextBox_OrderID.SkinTxt.TabIndex = 0;
            this.skinTextBox_OrderID.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_OrderID.SkinTxt.WaterText = "";
            this.skinTextBox_OrderID.TabIndex = 0;
            this.skinTextBox_OrderID.TabStop = true;
            this.skinTextBox_OrderID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_OrderID.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_OrderID.WaterText = "";
            this.skinTextBox_OrderID.WordWrap = true;
            // 
            // skinLabel10
            // 
            this.skinLabel10.AutoSize = true;
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel10.Location = new System.Drawing.Point(3, 11);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(32, 17);
            this.skinLabel10.TabIndex = 3;
            this.skinLabel10.Text = "单号";
            this.skinLabel10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(183, 11);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(32, 17);
            this.skinLabel4.TabIndex = 9;
            this.skinLabel4.Text = "款号";
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(3, 40);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 9;
            this.skinLabel5.Text = "店铺";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(183, 40);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 9;
            this.skinLabel1.Text = "状态";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(549, 11);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(32, 17);
            this.skinLabel3.TabIndex = 9;
            this.skinLabel3.Text = "结束";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(363, 11);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 10;
            this.skinLabel2.Text = "开始";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 62);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 588);
            this.skinSplitContainer1.SplitterDistance = 216;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 2;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "补货申请单";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // Column_ShopName
            // 
            this.Column_ShopName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ShopName.DataPropertyName = "ShopName";
            this.Column_ShopName.HeaderText = "店铺";
            this.Column_ShopName.Name = "Column_ShopName";
            this.Column_ShopName.ReadOnly = true;
            this.Column_ShopName.Width = 120;
            // 
            // totalCountDataGridViewTextBoxColumn
            // 
            this.totalCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.totalCountDataGridViewTextBoxColumn.DataPropertyName = "TotalCount";
            this.totalCountDataGridViewTextBoxColumn.HeaderText = "总数量";
            this.totalCountDataGridViewTextBoxColumn.Name = "totalCountDataGridViewTextBoxColumn";
            this.totalCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "总金额";
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GuideName
            // 
            this.GuideName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GuideName.DataPropertyName = "GuideName";
            this.GuideName.HeaderText = "开单员";
            this.GuideName.Name = "GuideName";
            this.GuideName.ReadOnly = true;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "单据时间";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // FinishedTime
            // 
            this.FinishedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FinishedTime.DataPropertyName = "FinishedTime";
            this.FinishedTime.HeaderText = "完成日期";
            this.FinishedTime.Name = "FinishedTime";
            this.FinishedTime.ReadOnly = true;
            this.FinishedTime.Width = 120;
            // 
            // stateNameDataGridViewTextBoxColumn
            // 
            this.stateNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stateNameDataGridViewTextBoxColumn.DataPropertyName = "StateName";
            this.stateNameDataGridViewTextBoxColumn.HeaderText = "状态";
            this.stateNameDataGridViewTextBoxColumn.Name = "stateNameDataGridViewTextBoxColumn";
            this.stateNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateNameDataGridViewTextBoxColumn.Width = 82;
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
            // column_send
            // 
            this.column_send.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.column_send.DataPropertyName = "StateName";
            this.column_send.HeaderText = "发货";
            this.column_send.Name = "column_send";
            this.column_send.ReadOnly = true;
            this.column_send.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column_send.Text = "发货";
            this.column_send.UseColumnTextForLinkValue = true;
            this.column_send.Width = 40;
            // 
            // ColumnCancel
            // 
            this.ColumnCancel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCancel.HeaderText = "取消";
            this.ColumnCancel.Name = "ColumnCancel";
            this.ColumnCancel.ReadOnly = true;
            this.ColumnCancel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnCancel.Text = "取消";
            this.ColumnCancel.UseColumnTextForLinkValue = true;
            this.ColumnCancel.Width = 40;
            // 
            // ColumnReject
            // 
            this.ColumnReject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnReject.HeaderText = "拒绝";
            this.ColumnReject.Name = "ColumnReject";
            this.ColumnReject.ReadOnly = true;
            this.ColumnReject.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnReject.Text = "拒绝";
            this.ColumnReject.UseColumnTextForLinkValue = true;
            this.ColumnReject.Width = 40;
            // 
            // ColumnPick
            // 
            this.ColumnPick.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPick.DataPropertyName = "Operation";
            this.ColumnPick.HeaderText = "提单";
            this.ColumnPick.Name = "ColumnPick";
            this.ColumnPick.ReadOnly = true;
            this.ColumnPick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPick.Text = "提单";
            this.ColumnPick.UseColumnTextForLinkValue = true;
            this.ColumnPick.Width = 40;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "导出";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Text = "导出";
            this.Column1.UseColumnTextForLinkValue = true;
            this.Column1.Width = 40;
            // 
            // ColumnPrint
            // 
            this.ColumnPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPrint.DataPropertyName = "Operation";
            this.ColumnPrint.HeaderText = "打印";
            this.ColumnPrint.Name = "ColumnPrint";
            this.ColumnPrint.ReadOnly = true;
            this.ColumnPrint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPrint.Text = "打印";
            this.ColumnPrint.UseColumnTextForLinkValue = true;
            this.ColumnPrint.Width = 40;
            // 
            // ReplenishManageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "ReplenishManageCtrl";
            this.Load += new System.EventHandler(this.ReplenishManageCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replenishOrderBindingSource)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private  JGNet.Common.TextBox skinTextBox_OrderID;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource replenishOrderBindingSource;
        private CCWin.SkinControl.SkinComboBox skinComboBoxState;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private ShopComboBox skinComboBoxShopID;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Common.CostumeTextBox costumeTextBox1;
        private Components.ImageHelp imageHelp1;
        private Common.Components.BaseButton BaseButton_search;
        private Components.QuickDateSelector quickDateSelector1;
        private System.Windows.Forms.DataGridViewLinkColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ShopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuideName;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn column_send;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnCancel;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnReject;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPick;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrint;
    }
}

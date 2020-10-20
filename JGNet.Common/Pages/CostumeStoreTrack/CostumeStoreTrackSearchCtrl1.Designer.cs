using JGNet.Common; 
using System;

namespace JGNet.Common
{
    partial class CostumeStoreTrackSearchCtrl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostumeStoreTrackSearchCtrl1));
            this.costumeStoreTrackBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new JGNet.Common.DataMergedView();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_Size = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_Color = new CCWin.SkinControl.SkinComboBox();
            this.quickDateSelector1 = new JGNet.Common.Components.QuickDateSelector(this.components);
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinComboBox_DestShop = new JGNet.Common.ShopComboBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.costumeTextBox1 = new JGNet.Common.CostumeTextBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.intoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.returnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.turnOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.retailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.scrapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.profitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.costumeStoreCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreTrackBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // costumeStoreTrackBindingSource
            // 
            this.costumeStoreTrackBindingSource.DataSource = typeof(JGNet.Core.InteractEntity.CostumeStoreChangeInfo);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.inDataGridViewTextBoxColumn,
            this.intoDataGridViewTextBoxColumn,
            this.returnDataGridViewTextBoxColumn,
            this.turnOutDataGridViewTextBoxColumn,
            this.retailDataGridViewTextBoxColumn,
            this.scrapDataGridViewTextBoxColumn,
            this.profitDataGridViewTextBoxColumn,
            this.costumeStoreCountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.costumeStoreTrackBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGridView1.MergeColumnNames")));
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 246);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinLabel6);
            this.skinPanel1.Controls.Add(this.skinLabel7);
            this.skinPanel1.Controls.Add(this.skinComboBox_Size);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.skinComboBox_Color);
            this.skinPanel1.Controls.Add(this.quickDateSelector1);
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.skinComboBox_DestShop);
            this.skinPanel1.Controls.Add(this.skinLabel5);
            this.skinPanel1.Controls.Add(this.costumeTextBox1);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 59);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.ForeColor = System.Drawing.Color.Red;
            this.skinLabel6.Location = new System.Drawing.Point(418, 39);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(652, 17);
            this.skinLabel6.TabIndex = 125;
            this.skinLabel6.Text = "进货：采购进货单；转入：调入单、批发退货单；退货：采购退货单；转出：调出单、批发发货单；销售：零售单           ";
            // 
            // skinLabel7
            // 
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(573, 9);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(32, 17);
            this.skinLabel7.TabIndex = 123;
            this.skinLabel7.Text = "尺码";
            // 
            // skinComboBox_Size
            // 
            this.skinComboBox_Size.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Size.FormattingEnabled = true;
            this.skinComboBox_Size.Location = new System.Drawing.Point(609, 6);
            this.skinComboBox_Size.Name = "skinComboBox_Size";
            this.skinComboBox_Size.Size = new System.Drawing.Size(140, 22);
            this.skinComboBox_Size.TabIndex = 124;
            this.skinComboBox_Size.WaterText = "";
            this.skinComboBox_Size.DropDown += new System.EventHandler(this.skinComboBox_Size_DropDown);
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(385, 9);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(32, 17);
            this.skinLabel4.TabIndex = 122;
            this.skinLabel4.Text = "颜色";
            // 
            // skinComboBox_Color
            // 
            this.skinComboBox_Color.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Color.FormattingEnabled = true;
            this.skinComboBox_Color.Location = new System.Drawing.Point(421, 6);
            this.skinComboBox_Color.Name = "skinComboBox_Color";
            this.skinComboBox_Color.Size = new System.Drawing.Size(140, 22);
            this.skinComboBox_Color.TabIndex = 121;
            this.skinComboBox_Color.WaterText = "";
            this.skinComboBox_Color.DropDown += new System.EventHandler(this.skinComboBox_Color_DropDown);
            this.skinComboBox_Color.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_Color_SelectedIndexChanged);
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
            this.quickDateSelector1.Location = new System.Drawing.Point(383, 33);
            this.quickDateSelector1.Name = "quickDateSelector1";
            this.quickDateSelector1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Size = new System.Drawing.Size(32, 25);
            this.quickDateSelector1.SkinAllColor = true;
            this.quickDateSelector1.StartDateTimePicker = this.dateTimePicker_Start;
            this.quickDateSelector1.TabIndex = 120;
            this.quickDateSelector1.Text = "quickDateSelector1";
            this.quickDateSelector1.TitleAnamorphosis = true;
            this.quickDateSelector1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.quickDateSelector1.TitleRadius = 4;
            this.quickDateSelector1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.PickerValueChanged += new CJBasic.Action<object, System.EventArgs>(this.BaseButton_Search_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(235, 35);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_End.TabIndex = 5;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(49, 35);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 4;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(755, 3);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 6;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinComboBox_DestShop
            // 
            this.skinComboBox_DestShop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_DestShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_DestShop.FormattingEnabled = true;
            this.skinComboBox_DestShop.Location = new System.Drawing.Point(49, 6);
            this.skinComboBox_DestShop.Name = "skinComboBox_DestShop";
            this.skinComboBox_DestShop.Size = new System.Drawing.Size(142, 22);
            this.skinComboBox_DestShop.TabIndex = 3;
            this.skinComboBox_DestShop.WaterText = "";
            this.skinComboBox_DestShop.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_DestShop_SelectedIndexChanged);
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(14, 9);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 115;
            this.skinLabel5.Text = "店铺";
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
            this.costumeTextBox1.Location = new System.Drawing.Point(235, 3);
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
            this.costumeTextBox1.TabIndex = 0;
            this.costumeTextBox1.TabStop = true;
            this.costumeTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.costumeTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.costumeTextBox1.WaterText = "";
            this.costumeTextBox1.WordWrap = true;
            this.costumeTextBox1.CostumeSelected += new CJBasic.Action<JGNet.Costume, bool>(this.costumeTextBox1_CostumeSelected);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(200, 37);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(32, 17);
            this.skinLabel3.TabIndex = 16;
            this.skinLabel3.Text = "结束";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(14, 37);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 17;
            this.skinLabel2.Text = "开始";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(200, 9);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 14;
            this.skinLabel1.Text = "款号";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 59);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 591);
            this.skinSplitContainer1.SplitterDistance = 246;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 3;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.FillWeight = 228.4264F;
            this.dateDataGridViewTextBoxColumn.HeaderText = "日期";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 80;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dateDataGridViewTextBoxColumn.Width = 284;
            // 
            // inDataGridViewTextBoxColumn
            // 
            this.inDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.inDataGridViewTextBoxColumn.DataPropertyName = "In";
            this.inDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.inDataGridViewTextBoxColumn.HeaderText = "进货";
            this.inDataGridViewTextBoxColumn.Name = "inDataGridViewTextBoxColumn";
            this.inDataGridViewTextBoxColumn.ReadOnly = true;
            this.inDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.inDataGridViewTextBoxColumn.Text = "";
            this.inDataGridViewTextBoxColumn.Width = 120;
            // 
            // intoDataGridViewTextBoxColumn
            // 
            this.intoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.intoDataGridViewTextBoxColumn.DataPropertyName = "Into";
            this.intoDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.intoDataGridViewTextBoxColumn.HeaderText = "转入";
            this.intoDataGridViewTextBoxColumn.Name = "intoDataGridViewTextBoxColumn";
            this.intoDataGridViewTextBoxColumn.ReadOnly = true;
            this.intoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.intoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.intoDataGridViewTextBoxColumn.Text = "";
            this.intoDataGridViewTextBoxColumn.Width = 120;
            // 
            // returnDataGridViewTextBoxColumn
            // 
            this.returnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.returnDataGridViewTextBoxColumn.DataPropertyName = "Return";
            this.returnDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.returnDataGridViewTextBoxColumn.HeaderText = "退货";
            this.returnDataGridViewTextBoxColumn.Name = "returnDataGridViewTextBoxColumn";
            this.returnDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.returnDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.returnDataGridViewTextBoxColumn.Width = 120;
            // 
            // turnOutDataGridViewTextBoxColumn
            // 
            this.turnOutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.turnOutDataGridViewTextBoxColumn.DataPropertyName = "TurnOut";
            this.turnOutDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.turnOutDataGridViewTextBoxColumn.HeaderText = "转出";
            this.turnOutDataGridViewTextBoxColumn.Name = "turnOutDataGridViewTextBoxColumn";
            this.turnOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.turnOutDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.turnOutDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.turnOutDataGridViewTextBoxColumn.Width = 120;
            // 
            // retailDataGridViewTextBoxColumn
            // 
            this.retailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.retailDataGridViewTextBoxColumn.DataPropertyName = "Retail";
            this.retailDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.retailDataGridViewTextBoxColumn.HeaderText = "销售";
            this.retailDataGridViewTextBoxColumn.Name = "retailDataGridViewTextBoxColumn";
            this.retailDataGridViewTextBoxColumn.ReadOnly = true;
            this.retailDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.retailDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.retailDataGridViewTextBoxColumn.Width = 120;
            // 
            // scrapDataGridViewTextBoxColumn
            // 
            this.scrapDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.scrapDataGridViewTextBoxColumn.DataPropertyName = "Scrap";
            this.scrapDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.scrapDataGridViewTextBoxColumn.HeaderText = "报损";
            this.scrapDataGridViewTextBoxColumn.Name = "scrapDataGridViewTextBoxColumn";
            this.scrapDataGridViewTextBoxColumn.ReadOnly = true;
            this.scrapDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.scrapDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.scrapDataGridViewTextBoxColumn.Width = 120;
            // 
            // profitDataGridViewTextBoxColumn
            // 
            this.profitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.profitDataGridViewTextBoxColumn.DataPropertyName = "Profit";
            this.profitDataGridViewTextBoxColumn.FillWeight = 41.98113F;
            this.profitDataGridViewTextBoxColumn.HeaderText = "盈亏";
            this.profitDataGridViewTextBoxColumn.Name = "profitDataGridViewTextBoxColumn";
            this.profitDataGridViewTextBoxColumn.ReadOnly = true;
            this.profitDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.profitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // costumeStoreCountDataGridViewTextBoxColumn
            // 
            this.costumeStoreCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeStoreCountDataGridViewTextBoxColumn.DataPropertyName = "CostumeStoreCount";
            this.costumeStoreCountDataGridViewTextBoxColumn.FillWeight = 89.94176F;
            this.costumeStoreCountDataGridViewTextBoxColumn.HeaderText = "结存";
            this.costumeStoreCountDataGridViewTextBoxColumn.Name = "costumeStoreCountDataGridViewTextBoxColumn";
            this.costumeStoreCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeStoreCountDataGridViewTextBoxColumn.Width = 54;
            // 
            // CostumeStoreTrackSearchCtrl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "CostumeStoreTrackSearchCtrl1";
            this.Load += new System.EventHandler(this.CostumeStoreTrackSearchCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreTrackBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CostumeTextBox costumeTextBox1;
        private System.Windows.Forms.BindingSource costumeStoreTrackBindingSource;
        private ShopComboBox skinComboBox_DestShop;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private Common.Components.BaseButton BaseButton1; 
        private Components.QuickDateSelector quickDateSelector1;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Color;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Size; 
        private DataMergedView dataGridView1;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn inDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn intoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn returnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn turnOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn retailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn scrapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn profitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costumeStoreCountDataGridViewTextBoxColumn;
    }
}

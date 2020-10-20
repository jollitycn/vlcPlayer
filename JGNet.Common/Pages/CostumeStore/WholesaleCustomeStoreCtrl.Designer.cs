using JGNet.Common;
using JGNet.Manage;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class WholesaleCustomeStoreCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WholesaleCustomeStoreCtrl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.baseButtonExport = new JGNet.Common.Components.BaseButton();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_Color = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBoxBigClass = new JGNet.Common.CostumeClassSelector();
            this.skinLabel12 = new CCWin.SkinControl.SkinLabel();
            this.supllierComboBox1 = new JGNet.Common.Components.SupllierComboBox();
            this.skinComboBox_Season = new CCWin.SkinControl.SkinComboBox();
            this.skinComboBox_Year = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.skinckbCostPrice = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox_ShowPrice = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBoxShowColor = new CCWin.SkinControl.SkinCheckBox();
            this.skinckbNoZeroStore = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBoxShowImage = new CCWin.SkinControl.SkinCheckBox();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinComboBoxSupplier = new JGNet.Common.PfCustomerComboBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.CostumeCurrentShopTextBox1 = new JGNet.Common.CostumeTextBox();
            this.skinComboBox_Brand = new JGNet.Common.BrandComboBox();
            this.skinLabel11 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.costumeStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShopIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SumCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPriceSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumPfMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.baseButtonExport);
            this.skinPanel1.Controls.Add(this.skinLabel5);
            this.skinPanel1.Controls.Add(this.skinComboBox_Color);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinComboBoxBigClass);
            this.skinPanel1.Controls.Add(this.skinLabel12);
            this.skinPanel1.Controls.Add(this.supllierComboBox1);
            this.skinPanel1.Controls.Add(this.skinComboBox_Season);
            this.skinPanel1.Controls.Add(this.skinComboBox_Year);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.flowLayoutPanel1);
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.skinComboBoxSupplier);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.CostumeCurrentShopTextBox1);
            this.skinPanel1.Controls.Add(this.skinComboBox_Brand);
            this.skinPanel1.Controls.Add(this.skinLabel11);
            this.skinPanel1.Controls.Add(this.skinLabel10);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 106);
            this.skinPanel1.TabIndex = 0;
            // 
            // baseButtonExport
            // 
            this.baseButtonExport.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonExport.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonExport.DownBack = ((System.Drawing.Image)(resources.GetObject("baseButtonExport.DownBack")));
            this.baseButtonExport.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonExport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonExport.Location = new System.Drawing.Point(861, 16);
            this.baseButtonExport.MouseBack = ((System.Drawing.Image)(resources.GetObject("baseButtonExport.MouseBack")));
            this.baseButtonExport.Name = "baseButtonExport";
            this.baseButtonExport.NormlBack = ((System.Drawing.Image)(resources.GetObject("baseButtonExport.NormlBack")));
            this.baseButtonExport.Size = new System.Drawing.Size(75, 32);
            this.baseButtonExport.TabIndex = 111;
            this.baseButtonExport.Text = "导出";
            this.baseButtonExport.UseVisualStyleBackColor = false;
            this.baseButtonExport.Click += new System.EventHandler(this.baseButtonExport_Click);
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(581, 39);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(32, 17);
            this.skinLabel5.TabIndex = 109;
            this.skinLabel5.Text = "颜色";
            // 
            // skinComboBox_Color
            // 
            this.skinComboBox_Color.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Color.FormattingEnabled = true;
            this.skinComboBox_Color.Location = new System.Drawing.Point(619, 36);
            this.skinComboBox_Color.Name = "skinComboBox_Color";
            this.skinComboBox_Color.Size = new System.Drawing.Size(142, 22);
            this.skinComboBox_Color.TabIndex = 108;
            this.skinComboBox_Color.WaterText = "";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(194, 41);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(44, 17);
            this.skinLabel3.TabIndex = 107;
            this.skinLabel3.Text = "供应商";
            // 
            // skinComboBoxBigClass
            // 
            this.skinComboBoxBigClass.AutoSize = true;
            this.skinComboBoxBigClass.Location = new System.Drawing.Point(429, 35);
            this.skinComboBoxBigClass.Name = "skinComboBoxBigClass";
            this.skinComboBoxBigClass.SelectedValue = ((JGNet.Costume)(resources.GetObject("skinComboBoxBigClass.SelectedValue")));
            this.skinComboBoxBigClass.Size = new System.Drawing.Size(153, 29);
            this.skinComboBoxBigClass.TabIndex = 110;
            // 
            // skinLabel12
            // 
            this.skinLabel12.AutoSize = true;
            this.skinLabel12.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel12.BorderColor = System.Drawing.Color.White;
            this.skinLabel12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel12.Location = new System.Drawing.Point(393, 41);
            this.skinLabel12.Name = "skinLabel12";
            this.skinLabel12.Size = new System.Drawing.Size(32, 17);
            this.skinLabel12.TabIndex = 106;
            this.skinLabel12.Text = "类别";
            this.skinLabel12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // supllierComboBox1
            // 
            this.supllierComboBox1.AutoSize = true;
            this.supllierComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.supllierComboBox1.EnabledSupplier = true;
            this.supllierComboBox1.HideAll = false;
            this.supllierComboBox1.Location = new System.Drawing.Point(244, 38);
            this.supllierComboBox1.Name = "supllierComboBox1";
            this.supllierComboBox1.SelectedItem = ((JGNet.Supplier)(resources.GetObject("supllierComboBox1.SelectedItem")));
            this.supllierComboBox1.SelectedValue = null;
            this.supllierComboBox1.ShowAdd = false;
            this.supllierComboBox1.Size = new System.Drawing.Size(172, 26);
            this.supllierComboBox1.TabIndex = 105;
            this.supllierComboBox1.Title = null;
            // 
            // skinComboBox_Season
            // 
            this.skinComboBox_Season.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Season.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Season.FormattingEnabled = true;
            this.skinComboBox_Season.Location = new System.Drawing.Point(620, 7);
            this.skinComboBox_Season.Name = "skinComboBox_Season";
            this.skinComboBox_Season.Size = new System.Drawing.Size(142, 22);
            this.skinComboBox_Season.TabIndex = 104;
            this.skinComboBox_Season.WaterText = "";
            // 
            // skinComboBox_Year
            // 
            this.skinComboBox_Year.DisplayMember = "BigClass";
            this.skinComboBox_Year.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Year.FormattingEnabled = true;
            this.skinComboBox_Year.Location = new System.Drawing.Point(432, 7);
            this.skinComboBox_Year.Name = "skinComboBox_Year";
            this.skinComboBox_Year.Size = new System.Drawing.Size(142, 22);
            this.skinComboBox_Year.TabIndex = 101;
            this.skinComboBox_Year.ValueMember = "BigClass";
            this.skinComboBox_Year.WaterText = "";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(582, 10);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 102;
            this.skinLabel2.Text = "季节";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(394, 10);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 103;
            this.skinLabel1.Text = "年份";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.skinckbCostPrice);
            this.flowLayoutPanel1.Controls.Add(this.skinCheckBox_ShowPrice);
            this.flowLayoutPanel1.Controls.Add(this.skinCheckBoxShowColor);
            this.flowLayoutPanel1.Controls.Add(this.skinckbNoZeroStore);
            this.flowLayoutPanel1.Controls.Add(this.skinCheckBoxShowImage);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(45, 69);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 26);
            this.flowLayoutPanel1.TabIndex = 100;
            // 
            // skinckbCostPrice
            // 
            this.skinckbCostPrice.AutoSize = true;
            this.skinckbCostPrice.BackColor = System.Drawing.Color.Transparent;
            this.skinckbCostPrice.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinckbCostPrice.DownBack = null;
            this.skinckbCostPrice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinckbCostPrice.Location = new System.Drawing.Point(3, 3);
            this.skinckbCostPrice.MouseBack = null;
            this.skinckbCostPrice.Name = "skinckbCostPrice";
            this.skinckbCostPrice.NormlBack = null;
            this.skinckbCostPrice.SelectedDownBack = null;
            this.skinckbCostPrice.SelectedMouseBack = null;
            this.skinckbCostPrice.SelectedNormlBack = null;
            this.skinckbCostPrice.Size = new System.Drawing.Size(75, 21);
            this.skinckbCostPrice.TabIndex = 111;
            this.skinckbCostPrice.Text = "显示成本";
            this.skinckbCostPrice.UseVisualStyleBackColor = false;
            // 
            // skinCheckBox_ShowPrice
            // 
            this.skinCheckBox_ShowPrice.AutoSize = true;
            this.skinCheckBox_ShowPrice.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_ShowPrice.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_ShowPrice.DownBack = null;
            this.skinCheckBox_ShowPrice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_ShowPrice.Location = new System.Drawing.Point(84, 3);
            this.skinCheckBox_ShowPrice.MouseBack = null;
            this.skinCheckBox_ShowPrice.Name = "skinCheckBox_ShowPrice";
            this.skinCheckBox_ShowPrice.NormlBack = null;
            this.skinCheckBox_ShowPrice.SelectedDownBack = null;
            this.skinCheckBox_ShowPrice.SelectedMouseBack = null;
            this.skinCheckBox_ShowPrice.SelectedNormlBack = null;
            this.skinCheckBox_ShowPrice.Size = new System.Drawing.Size(87, 21);
            this.skinCheckBox_ShowPrice.TabIndex = 9;
            this.skinCheckBox_ShowPrice.Text = "显示批发价";
            this.skinCheckBox_ShowPrice.UseVisualStyleBackColor = false;
            this.skinCheckBox_ShowPrice.CheckedChanged += new System.EventHandler(this.skinCheckBox_ShowPrice_CheckedChanged);
            // 
            // skinCheckBoxShowColor
            // 
            this.skinCheckBoxShowColor.AutoSize = true;
            this.skinCheckBoxShowColor.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBoxShowColor.Checked = true;
            this.skinCheckBoxShowColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBoxShowColor.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBoxShowColor.DownBack = null;
            this.skinCheckBoxShowColor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBoxShowColor.Location = new System.Drawing.Point(177, 3);
            this.skinCheckBoxShowColor.MouseBack = null;
            this.skinCheckBoxShowColor.Name = "skinCheckBoxShowColor";
            this.skinCheckBoxShowColor.NormlBack = null;
            this.skinCheckBoxShowColor.SelectedDownBack = null;
            this.skinCheckBoxShowColor.SelectedMouseBack = null;
            this.skinCheckBoxShowColor.SelectedNormlBack = null;
            this.skinCheckBoxShowColor.Size = new System.Drawing.Size(75, 21);
            this.skinCheckBoxShowColor.TabIndex = 112;
            this.skinCheckBoxShowColor.Text = "显示颜色";
            this.skinCheckBoxShowColor.UseVisualStyleBackColor = false;
            // 
            // skinckbNoZeroStore
            // 
            this.skinckbNoZeroStore.AutoSize = true;
            this.skinckbNoZeroStore.BackColor = System.Drawing.Color.Transparent;
            this.skinckbNoZeroStore.Checked = true;
            this.skinckbNoZeroStore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinckbNoZeroStore.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinckbNoZeroStore.DownBack = null;
            this.skinckbNoZeroStore.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinckbNoZeroStore.Location = new System.Drawing.Point(258, 3);
            this.skinckbNoZeroStore.MouseBack = null;
            this.skinckbNoZeroStore.Name = "skinckbNoZeroStore";
            this.skinckbNoZeroStore.NormlBack = null;
            this.skinckbNoZeroStore.SelectedDownBack = null;
            this.skinckbNoZeroStore.SelectedMouseBack = null;
            this.skinckbNoZeroStore.SelectedNormlBack = null;
            this.skinckbNoZeroStore.Size = new System.Drawing.Size(111, 21);
            this.skinckbNoZeroStore.TabIndex = 11;
            this.skinckbNoZeroStore.Text = "仅显示非零库存";
            this.skinckbNoZeroStore.UseVisualStyleBackColor = false;
            // 
            // skinCheckBoxShowImage
            // 
            this.skinCheckBoxShowImage.AutoSize = true;
            this.skinCheckBoxShowImage.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBoxShowImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBoxShowImage.DownBack = null;
            this.skinCheckBoxShowImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBoxShowImage.Location = new System.Drawing.Point(375, 3);
            this.skinCheckBoxShowImage.MouseBack = null;
            this.skinCheckBoxShowImage.Name = "skinCheckBoxShowImage";
            this.skinCheckBoxShowImage.NormlBack = null;
            this.skinCheckBoxShowImage.SelectedDownBack = null;
            this.skinCheckBoxShowImage.SelectedMouseBack = null;
            this.skinCheckBoxShowImage.SelectedNormlBack = null;
            this.skinCheckBoxShowImage.Size = new System.Drawing.Size(75, 21);
            this.skinCheckBoxShowImage.TabIndex = 101;
            this.skinCheckBoxShowImage.Text = "显示图片";
            this.skinCheckBoxShowImage.UseVisualStyleBackColor = false;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.DownBack")));
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(780, 16);
            this.BaseButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.MouseBack")));
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.NormlBack")));
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 11;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinComboBoxSupplier
            // 
            this.skinComboBoxSupplier.CheckPfCustomer = false;
            this.skinComboBoxSupplier.curSelectStr = null;
            this.skinComboBoxSupplier.CustomerTypeValue = -1;
            this.skinComboBoxSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxSupplier.FormattingEnabled = true;
            this.skinComboBoxSupplier.HideEmpty = false;
            this.skinComboBoxSupplier.Location = new System.Drawing.Point(48, 38);
            this.skinComboBoxSupplier.Name = "skinComboBoxSupplier";
            this.skinComboBoxSupplier.Size = new System.Drawing.Size(140, 22);
            this.skinComboBoxSupplier.TabIndex = 5;
            this.skinComboBoxSupplier.WaterText = "";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(10, 41);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(32, 17);
            this.skinLabel4.TabIndex = 99;
            this.skinLabel4.Text = "客户";
            // 
            // CostumeCurrentShopTextBox1
            // 
            this.CostumeCurrentShopTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.CostumeCurrentShopTextBox1.DownBack = null;
            this.CostumeCurrentShopTextBox1.FilterValid = true;
            this.CostumeCurrentShopTextBox1.Icon = null;
            this.CostumeCurrentShopTextBox1.IconIsButton = false;
            this.CostumeCurrentShopTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.CostumeCurrentShopTextBox1.IsPasswordChat = '\0';
            this.CostumeCurrentShopTextBox1.IsSystemPasswordChar = false;
            this.CostumeCurrentShopTextBox1.Lines = new string[0];
            this.CostumeCurrentShopTextBox1.Location = new System.Drawing.Point(46, 3);
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
            this.CostumeCurrentShopTextBox1.Size = new System.Drawing.Size(142, 28);
            // 
            // 
            // 
            this.CostumeCurrentShopTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostumeCurrentShopTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CostumeCurrentShopTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.CostumeCurrentShopTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.CostumeCurrentShopTextBox1.SkinTxt.Name = "BaseText";
            this.CostumeCurrentShopTextBox1.SkinTxt.Size = new System.Drawing.Size(132, 18);
            this.CostumeCurrentShopTextBox1.SkinTxt.TabIndex = 0;
            this.CostumeCurrentShopTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.CostumeCurrentShopTextBox1.SkinTxt.WaterText = "输入款号或条形码回车";
            this.CostumeCurrentShopTextBox1.TabIndex = 0;
            this.CostumeCurrentShopTextBox1.TabStop = true;
            this.CostumeCurrentShopTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CostumeCurrentShopTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.CostumeCurrentShopTextBox1.WaterText = "输入款号或条形码回车";
            this.CostumeCurrentShopTextBox1.WordWrap = true;
            this.CostumeCurrentShopTextBox1.CostumeSelected += new CJBasic.Action<JGNet.Costume, bool>(this.CostumeCurrentShopTextBox1_CostumeSelected);
            // 
            // skinComboBox_Brand
            // 
            this.skinComboBox_Brand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.skinComboBox_Brand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.skinComboBox_Brand.DisplayMember = "AutoID";
            this.skinComboBox_Brand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Brand.FormattingEnabled = true;
            this.skinComboBox_Brand.Location = new System.Drawing.Point(242, 6);
            this.skinComboBox_Brand.Name = "skinComboBox_Brand";
            this.skinComboBox_Brand.SelectStr = null;
            this.skinComboBox_Brand.ShowAll = true;
            this.skinComboBox_Brand.Size = new System.Drawing.Size(142, 22);
            this.skinComboBox_Brand.SupplierID = null;
            this.skinComboBox_Brand.TabIndex = 6;
            this.skinComboBox_Brand.ValueMember = "AutoID";
            this.skinComboBox_Brand.WaterText = "";
            // 
            // skinLabel11
            // 
            this.skinLabel11.AutoSize = true;
            this.skinLabel11.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel11.BorderColor = System.Drawing.Color.White;
            this.skinLabel11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel11.Location = new System.Drawing.Point(207, 9);
            this.skinLabel11.Name = "skinLabel11";
            this.skinLabel11.Size = new System.Drawing.Size(32, 17);
            this.skinLabel11.TabIndex = 10;
            this.skinLabel11.Text = "品牌";
            this.skinLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinLabel10
            // 
            this.skinLabel10.AutoSize = true;
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel10.Location = new System.Drawing.Point(11, 9);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(32, 17);
            this.skinLabel10.TabIndex = 4;
            this.skinLabel10.Text = "款号";
            this.skinLabel10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShopIDColumn,
            this.costumeIDDataGridViewTextBoxColumn,
            this.CostumeName,
            this.BrandName,
            this.ClassName,
            this.colorNameDataGridViewTextBoxColumn,
            this.CostPrice1,
            this.CostPrice,
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
            this.SumCount,
            this.CostPriceSum,
            this.SumPfMoney,
            this.Remarks});
            this.dataGridView1.DataSource = this.costumeStoreBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 106);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 544);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // costumeStoreBindingSource
            // 
            this.costumeStoreBindingSource.DataSource = typeof(JGNet.PfCustomerStore);
            // 
            // ShopIDColumn
            // 
            this.ShopIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShopIDColumn.DataPropertyName = "PfCustomerName";
            this.ShopIDColumn.HeaderText = "客户";
            this.ShopIDColumn.Name = "ShopIDColumn";
            this.ShopIDColumn.ReadOnly = true;
            this.ShopIDColumn.Width = 62;
            // 
            // costumeIDDataGridViewTextBoxColumn
            // 
            this.costumeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeIDDataGridViewTextBoxColumn.DataPropertyName = "CostumeID";
            this.costumeIDDataGridViewTextBoxColumn.HeaderText = "款号";
            this.costumeIDDataGridViewTextBoxColumn.Name = "costumeIDDataGridViewTextBoxColumn";
            this.costumeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeIDDataGridViewTextBoxColumn.Width = 90;
            // 
            // CostumeName
            // 
            this.CostumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostumeName.DataPropertyName = "CostumeName";
            this.CostumeName.HeaderText = "名称";
            this.CostumeName.Name = "CostumeName";
            this.CostumeName.ReadOnly = true;
            // 
            // BrandName
            // 
            this.BrandName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BrandName.DataPropertyName = "BrandName";
            this.BrandName.HeaderText = "品牌";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "类别";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "颜色";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorNameDataGridViewTextBoxColumn.Width = 90;
            // 
            // CostPrice1
            // 
            this.CostPrice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostPrice1.DataPropertyName = "CostPrice";
            this.CostPrice1.HeaderText = "成本价";
            this.CostPrice1.Name = "CostPrice1";
            this.CostPrice1.ReadOnly = true;
            // 
            // CostPrice
            // 
            this.CostPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostPrice.DataPropertyName = "PfPrice";
            this.CostPrice.HeaderText = "批发价";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 62;
            // 
            // fDataGridViewTextBoxColumn
            // 
            this.fDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fDataGridViewTextBoxColumn.DataPropertyName = "F";
            this.fDataGridViewTextBoxColumn.HeaderText = "F";
            this.fDataGridViewTextBoxColumn.Name = "fDataGridViewTextBoxColumn";
            this.fDataGridViewTextBoxColumn.ReadOnly = true;
            this.fDataGridViewTextBoxColumn.Width = 62;
            // 
            // xSDataGridViewTextBoxColumn
            // 
            this.xSDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xSDataGridViewTextBoxColumn.DataPropertyName = "XS";
            this.xSDataGridViewTextBoxColumn.HeaderText = "XS";
            this.xSDataGridViewTextBoxColumn.Name = "xSDataGridViewTextBoxColumn";
            this.xSDataGridViewTextBoxColumn.ReadOnly = true;
            this.xSDataGridViewTextBoxColumn.Width = 62;
            // 
            // sDataGridViewTextBoxColumn
            // 
            this.sDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sDataGridViewTextBoxColumn.DataPropertyName = "S";
            this.sDataGridViewTextBoxColumn.HeaderText = "S";
            this.sDataGridViewTextBoxColumn.Name = "sDataGridViewTextBoxColumn";
            this.sDataGridViewTextBoxColumn.ReadOnly = true;
            this.sDataGridViewTextBoxColumn.Width = 62;
            // 
            // mDataGridViewTextBoxColumn
            // 
            this.mDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mDataGridViewTextBoxColumn.DataPropertyName = "M";
            this.mDataGridViewTextBoxColumn.HeaderText = "M";
            this.mDataGridViewTextBoxColumn.Name = "mDataGridViewTextBoxColumn";
            this.mDataGridViewTextBoxColumn.ReadOnly = true;
            this.mDataGridViewTextBoxColumn.Width = 62;
            // 
            // lDataGridViewTextBoxColumn
            // 
            this.lDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lDataGridViewTextBoxColumn.DataPropertyName = "L";
            this.lDataGridViewTextBoxColumn.HeaderText = "L";
            this.lDataGridViewTextBoxColumn.Name = "lDataGridViewTextBoxColumn";
            this.lDataGridViewTextBoxColumn.ReadOnly = true;
            this.lDataGridViewTextBoxColumn.Width = 63;
            // 
            // xLDataGridViewTextBoxColumn
            // 
            this.xLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xLDataGridViewTextBoxColumn.DataPropertyName = "XL";
            this.xLDataGridViewTextBoxColumn.HeaderText = "XL";
            this.xLDataGridViewTextBoxColumn.Name = "xLDataGridViewTextBoxColumn";
            this.xLDataGridViewTextBoxColumn.ReadOnly = true;
            this.xLDataGridViewTextBoxColumn.Width = 62;
            // 
            // xL2DataGridViewTextBoxColumn
            // 
            this.xL2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL2DataGridViewTextBoxColumn.DataPropertyName = "XL2";
            this.xL2DataGridViewTextBoxColumn.HeaderText = "2XL";
            this.xL2DataGridViewTextBoxColumn.Name = "xL2DataGridViewTextBoxColumn";
            this.xL2DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL2DataGridViewTextBoxColumn.Width = 62;
            // 
            // xL3DataGridViewTextBoxColumn
            // 
            this.xL3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL3DataGridViewTextBoxColumn.DataPropertyName = "XL3";
            this.xL3DataGridViewTextBoxColumn.HeaderText = "3XL";
            this.xL3DataGridViewTextBoxColumn.Name = "xL3DataGridViewTextBoxColumn";
            this.xL3DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL3DataGridViewTextBoxColumn.Width = 62;
            // 
            // xL4DataGridViewTextBoxColumn
            // 
            this.xL4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL4DataGridViewTextBoxColumn.DataPropertyName = "XL4";
            this.xL4DataGridViewTextBoxColumn.HeaderText = "4XL";
            this.xL4DataGridViewTextBoxColumn.Name = "xL4DataGridViewTextBoxColumn";
            this.xL4DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL4DataGridViewTextBoxColumn.Width = 62;
            // 
            // xL5DataGridViewTextBoxColumn
            // 
            this.xL5DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL5DataGridViewTextBoxColumn.DataPropertyName = "XL5";
            this.xL5DataGridViewTextBoxColumn.HeaderText = "5XL";
            this.xL5DataGridViewTextBoxColumn.Name = "xL5DataGridViewTextBoxColumn";
            this.xL5DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL5DataGridViewTextBoxColumn.Width = 62;
            // 
            // xL6DataGridViewTextBoxColumn
            // 
            this.xL6DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xL6DataGridViewTextBoxColumn.DataPropertyName = "XL6";
            this.xL6DataGridViewTextBoxColumn.HeaderText = "6XL";
            this.xL6DataGridViewTextBoxColumn.Name = "xL6DataGridViewTextBoxColumn";
            this.xL6DataGridViewTextBoxColumn.ReadOnly = true;
            this.xL6DataGridViewTextBoxColumn.Width = 62;
            // 
            // SumCount
            // 
            this.SumCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SumCount.DataPropertyName = "SumCount";
            this.SumCount.HeaderText = "数量";
            this.SumCount.Name = "SumCount";
            this.SumCount.ReadOnly = true;
            this.SumCount.Width = 62;
            // 
            // CostPriceSum
            // 
            this.CostPriceSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostPriceSum.DataPropertyName = "CostPriceSum";
            this.CostPriceSum.HeaderText = "成本总额";
            this.CostPriceSum.Name = "CostPriceSum";
            this.CostPriceSum.ReadOnly = true;
            // 
            // SumPfMoney
            // 
            this.SumPfMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SumPfMoney.DataPropertyName = "SumPfMoney";
            this.SumPfMoney.HeaderText = "批发总额";
            this.SumPfMoney.Name = "SumPfMoney";
            this.SumPfMoney.ReadOnly = true;
            this.SumPfMoney.Width = 62;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 54;
            // 
            // WholesaleCustomeStoreCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "WholesaleCustomeStoreCtrl";
            this.Load += new System.EventHandler(this.CostumeStoreSearchCtrl_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costumeStoreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private CCWin.SkinControl.SkinLabel skinLabel11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource costumeStoreBindingSource;
        private  BrandComboBox skinComboBox_Brand;
        private CostumeTextBox CostumeCurrentShopTextBox1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_ShowPrice;
        private Common.Components.BaseButton BaseButton1;
        private  PfCustomerComboBox skinComboBoxSupplier; 
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private CCWin.SkinControl.SkinCheckBox skinckbNoZeroStore;
        private CCWin.SkinControl.SkinCheckBox skinCheckBoxShowImage;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Season;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Year;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Color;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CostumeClassSelector skinComboBoxBigClass;
        private CCWin.SkinControl.SkinLabel skinLabel12;
        private Components.SupllierComboBox supllierComboBox1;
        private CCWin.SkinControl.SkinCheckBox skinckbCostPrice;
        private CCWin.SkinControl.SkinCheckBox skinCheckBoxShowColor;
        private Components.BaseButton baseButtonExport;
        private DataGridViewTextBoxColumn ShopIDColumn;
        private DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CostumeName;
        private DataGridViewTextBoxColumn BrandName;
        private DataGridViewTextBoxColumn ClassName;
        private DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CostPrice1;
        private DataGridViewTextBoxColumn CostPrice;
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
        private DataGridViewTextBoxColumn SumCount;
        private DataGridViewTextBoxColumn CostPriceSum;
        private DataGridViewTextBoxColumn SumPfMoney;
        private DataGridViewTextBoxColumn Remarks;
    }
}

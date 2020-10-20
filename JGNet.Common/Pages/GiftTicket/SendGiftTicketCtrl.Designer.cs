using System.Windows.Forms;

namespace JGNet.Manage.Pages.BasicSettings.Costume
{
    partial class SendGiftTicketCtrl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.skinSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMembers = new System.Windows.Forms.DataGridView();
            this.memberBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.BaseButton6 = new JGNet.Common.Components.BaseButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBoxMemberId = new JGNet.Common.MemberIDTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baseButtonSave = new JGNet.Common.Components.BaseButton();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.textBoxRemarks = new JGNet.Common.TextBox();
            this.textBoxCount = new JGNet.Common.NumericTextBox();
            this.skinTextBoxMoney = new JGNet.Common.TextBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_giftTicket = new CCWin.SkinControl.SkinComboBox();
            this.phoneNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.skinPanel1.SuspendLayout();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.Panel2.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).BeginInit();
            this.skinPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 10);
            this.panel1.TabIndex = 53;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinSplitContainer1);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.Location = new System.Drawing.Point(0, 10);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 640);
            this.skinPanel1.TabIndex = 54;
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.skinSplitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 640);
            this.skinSplitContainer1.SplitterDistance = 580;
            this.skinSplitContainer1.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewMembers);
            this.groupBox1.Controls.Add(this.skinPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(580, 640);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择会员";
            // 
            // dataGridViewMembers
            // 
            this.dataGridViewMembers.AllowUserToAddRows = false;
            this.dataGridViewMembers.AllowUserToDeleteRows = false;
            this.dataGridViewMembers.AutoGenerateColumns = false;
            this.dataGridViewMembers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phoneNumberDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.Column2});
            this.dataGridViewMembers.DataSource = this.memberBindingSource3;
            this.dataGridViewMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMembers.Location = new System.Drawing.Point(5, 53);
            this.dataGridViewMembers.MultiSelect = false;
            this.dataGridViewMembers.Name = "dataGridViewMembers";
            this.dataGridViewMembers.ReadOnly = true;
            this.dataGridViewMembers.RowTemplate.Height = 23;
            this.dataGridViewMembers.Size = new System.Drawing.Size(570, 582);
            this.dataGridViewMembers.TabIndex = 10;
            this.dataGridViewMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMembers_CellClick);
            // 
            // memberBindingSource3
            // 
            this.memberBindingSource3.DataSource = typeof(JGNet.Member);
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.BaseButton6);
            this.skinPanel2.Controls.Add(this.skinLabel1);
            this.skinPanel2.Controls.Add(this.skinTextBoxMemberId);
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.Location = new System.Drawing.Point(5, 19);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(570, 34);
            this.skinPanel2.TabIndex = 9;
            // 
            // BaseButton6
            // 
            this.BaseButton6.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton6.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton6.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton6.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton6.Location = new System.Drawing.Point(402, 2);
            this.BaseButton6.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton6.Name = "BaseButton6";
            this.BaseButton6.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton6.Size = new System.Drawing.Size(65, 32);
            this.BaseButton6.TabIndex = 3;
            this.BaseButton6.Text = "...";
            this.BaseButton6.UseVisualStyleBackColor = false;
            this.BaseButton6.Click += new System.EventHandler(this.BaseButton6_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(114, 9);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(97, 17);
            this.skinLabel1.TabIndex = 2;
            this.skinLabel1.Text = "会员卡号/姓名：";
            // 
            // skinTextBoxMemberId
            // 
            this.skinTextBoxMemberId.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxMemberId.CheckMember = false;
            this.skinTextBoxMemberId.DownBack = null;
            this.skinTextBoxMemberId.Icon = null;
            this.skinTextBoxMemberId.IconIsButton = false;
            this.skinTextBoxMemberId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxMemberId.IsPasswordChat = '\0';
            this.skinTextBoxMemberId.IsSystemPasswordChar = false;
            this.skinTextBoxMemberId.Lines = new string[0];
            this.skinTextBoxMemberId.Location = new System.Drawing.Point(214, 3);
            this.skinTextBoxMemberId.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxMemberId.MaxLength = 32767;
            this.skinTextBoxMemberId.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxMemberId.MouseBack = null;
            this.skinTextBoxMemberId.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxMemberId.Multiline = false;
            this.skinTextBoxMemberId.Name = "skinTextBoxMemberId";
            this.skinTextBoxMemberId.NormlBack = null;
            this.skinTextBoxMemberId.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxMemberId.ReadOnly = false;
            this.skinTextBoxMemberId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxMemberId.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBoxMemberId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxMemberId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxMemberId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxMemberId.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxMemberId.SkinTxt.Name = "BaseText";
            this.skinTextBoxMemberId.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.skinTextBoxMemberId.SkinTxt.TabIndex = 0;
            this.skinTextBoxMemberId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMemberId.SkinTxt.WaterText = "输入卡号/姓名并回车";
            this.skinTextBoxMemberId.TabIndex = 0;
            this.skinTextBoxMemberId.TabStop = true;
            this.skinTextBoxMemberId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxMemberId.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMemberId.WaterText = "输入卡号/姓名并回车";
            this.skinTextBoxMemberId.WordWrap = true;
            this.skinTextBoxMemberId.MemberSelected += new System.Action<JGNet.Member>(this.skinTextBoxMemberId_MemberSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseButtonSave);
            this.groupBox2.Controls.Add(this.dateTimePickerEndDate);
            this.groupBox2.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox2.Controls.Add(this.skinLabel5);
            this.groupBox2.Controls.Add(this.skinLabel4);
            this.groupBox2.Controls.Add(this.textBoxRemarks);
            this.groupBox2.Controls.Add(this.textBoxCount);
            this.groupBox2.Controls.Add(this.skinTextBoxMoney);
            this.groupBox2.Controls.Add(this.skinLabel6);
            this.groupBox2.Controls.Add(this.skinLabel3);
            this.groupBox2.Controls.Add(this.skinLabel2);
            this.groupBox2.Controls.Add(this.skinLabel10);
            this.groupBox2.Controls.Add(this.skinComboBox_giftTicket);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(576, 640);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "优惠券发放";
            // 
            // baseButtonSave
            // 
            this.baseButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonSave.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonSave.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonSave.Location = new System.Drawing.Point(228, 228);
            this.baseButtonSave.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonSave.Name = "baseButtonSave";
            this.baseButtonSave.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonSave.Size = new System.Drawing.Size(65, 32);
            this.baseButtonSave.TabIndex = 3;
            this.baseButtonSave.Text = "保存";
            this.baseButtonSave.UseVisualStyleBackColor = false;
            this.baseButtonSave.Click += new System.EventHandler(this.baseButtonSave_Click);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(75, 152);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(392, 21);
            this.dateTimePickerEndDate.TabIndex = 147;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(75, 123);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(392, 21);
            this.dateTimePickerStartDate.TabIndex = 147;
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(13, 154);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(56, 17);
            this.skinLabel5.TabIndex = 149;
            this.skinLabel5.Text = "截止日期";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(13, 125);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(56, 17);
            this.skinLabel4.TabIndex = 149;
            this.skinLabel4.Text = "生效日期";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRemarks.DownBack = null;
            this.textBoxRemarks.Icon = null;
            this.textBoxRemarks.IconIsButton = false;
            this.textBoxRemarks.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxRemarks.IsPasswordChat = '\0';
            this.textBoxRemarks.IsSystemPasswordChar = false;
            this.textBoxRemarks.Lines = new string[0];
            this.textBoxRemarks.Location = new System.Drawing.Point(75, 178);
            this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxRemarks.MaxLength = 32767;
            this.textBoxRemarks.MinimumSize = new System.Drawing.Size(28, 28);
            this.textBoxRemarks.MouseBack = null;
            this.textBoxRemarks.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxRemarks.Multiline = false;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.NormlBack = null;
            this.textBoxRemarks.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxRemarks.ReadOnly = false;
            this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxRemarks.Size = new System.Drawing.Size(393, 28);
            // 
            // 
            // 
            this.textBoxRemarks.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRemarks.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRemarks.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxRemarks.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxRemarks.SkinTxt.Name = "BaseText";
            this.textBoxRemarks.SkinTxt.Size = new System.Drawing.Size(383, 18);
            this.textBoxRemarks.SkinTxt.TabIndex = 0;
            this.textBoxRemarks.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxRemarks.SkinTxt.WaterText = "";
            this.textBoxRemarks.TabIndex = 21;
            this.textBoxRemarks.TabStop = true;
            this.textBoxRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxRemarks.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxRemarks.WaterText = "";
            this.textBoxRemarks.WordWrap = true;
            // 
            // textBoxCount
            // 
            this.textBoxCount.BackColor = System.Drawing.Color.Transparent;
            this.textBoxCount.DecimalPlaces = 0;
            this.textBoxCount.DownBack = null;
            this.textBoxCount.Icon = null;
            this.textBoxCount.IconIsButton = false;
            this.textBoxCount.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxCount.IsPasswordChat = '\0';
            this.textBoxCount.IsSystemPasswordChar = false;
            this.textBoxCount.Lines = new string[] {
        "1"};
            this.textBoxCount.Location = new System.Drawing.Point(75, 89);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCount.MaxLength = 32767;
            this.textBoxCount.MaxNum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.textBoxCount.MinimumSize = new System.Drawing.Size(28, 28);
            this.textBoxCount.MinNum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxCount.MouseBack = null;
            this.textBoxCount.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxCount.Multiline = false;
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.NormlBack = null;
            this.textBoxCount.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxCount.ReadOnly = false;
            this.textBoxCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxCount.ShowZero = false;
            this.textBoxCount.Size = new System.Drawing.Size(393, 28);
            // 
            // 
            // 
            this.textBoxCount.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCount.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCount.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxCount.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxCount.SkinTxt.Name = "BaseText";
            this.textBoxCount.SkinTxt.Size = new System.Drawing.Size(383, 18);
            this.textBoxCount.SkinTxt.TabIndex = 0;
            this.textBoxCount.SkinTxt.Text = "1";
            this.textBoxCount.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxCount.SkinTxt.WaterText = "";
            this.textBoxCount.TabIndex = 21;
            this.textBoxCount.TabStop = true;
            this.textBoxCount.Text = "1";
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxCount.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxCount.WaterText = "";
            this.textBoxCount.WordWrap = true;
            // 
            // skinTextBoxMoney
            // 
            this.skinTextBoxMoney.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxMoney.DownBack = null;
            this.skinTextBoxMoney.Icon = null;
            this.skinTextBoxMoney.IconIsButton = false;
            this.skinTextBoxMoney.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxMoney.IsPasswordChat = '\0';
            this.skinTextBoxMoney.IsSystemPasswordChar = false;
            this.skinTextBoxMoney.Lines = new string[0];
            this.skinTextBoxMoney.Location = new System.Drawing.Point(75, 53);
            this.skinTextBoxMoney.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxMoney.MaxLength = 32767;
            this.skinTextBoxMoney.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxMoney.MouseBack = null;
            this.skinTextBoxMoney.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxMoney.Multiline = false;
            this.skinTextBoxMoney.Name = "skinTextBoxMoney";
            this.skinTextBoxMoney.NormlBack = null;
            this.skinTextBoxMoney.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxMoney.ReadOnly = true;
            this.skinTextBoxMoney.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxMoney.Size = new System.Drawing.Size(393, 28);
            // 
            // 
            // 
            this.skinTextBoxMoney.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxMoney.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxMoney.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxMoney.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxMoney.SkinTxt.Name = "BaseText";
            this.skinTextBoxMoney.SkinTxt.ReadOnly = true;
            this.skinTextBoxMoney.SkinTxt.Size = new System.Drawing.Size(383, 18);
            this.skinTextBoxMoney.SkinTxt.TabIndex = 0;
            this.skinTextBoxMoney.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMoney.SkinTxt.WaterText = "";
            this.skinTextBoxMoney.TabIndex = 21;
            this.skinTextBoxMoney.TabStop = true;
            this.skinTextBoxMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxMoney.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMoney.WaterText = "";
            this.skinTextBoxMoney.WordWrap = true;
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(37, 183);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(32, 17);
            this.skinLabel6.TabIndex = 20;
            this.skinLabel6.Text = "备注";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(13, 95);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(56, 17);
            this.skinLabel3.TabIndex = 20;
            this.skinLabel3.Text = "发放数量";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(37, 59);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 20;
            this.skinLabel2.Text = "面额";
            // 
            // skinLabel10
            // 
            this.skinLabel10.AutoSize = true;
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel10.Location = new System.Drawing.Point(25, 28);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(44, 17);
            this.skinLabel10.TabIndex = 19;
            this.skinLabel10.Text = "优惠券";
            // 
            // skinComboBox_giftTicket
            // 
            this.skinComboBox_giftTicket.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_giftTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_giftTicket.FormattingEnabled = true;
            this.skinComboBox_giftTicket.Location = new System.Drawing.Point(75, 25);
            this.skinComboBox_giftTicket.Name = "skinComboBox_giftTicket";
            this.skinComboBox_giftTicket.Size = new System.Drawing.Size(393, 22);
            this.skinComboBox_giftTicket.TabIndex = 1;
            this.skinComboBox_giftTicket.WaterText = "";
            this.skinComboBox_giftTicket.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_giftTicket_SelectedIndexChanged);
            // 
            // phoneNumberDataGridViewTextBoxColumn1
            // 
            this.phoneNumberDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.phoneNumberDataGridViewTextBoxColumn1.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn1.HeaderText = "会员卡号";
            this.phoneNumberDataGridViewTextBoxColumn1.Name = "phoneNumberDataGridViewTextBoxColumn1";
            this.phoneNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.phoneNumberDataGridViewTextBoxColumn1.Width = 240;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "会员姓名";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Text = "删除";
            this.Column2.UseColumnTextForLinkValue = true;
            this.Column2.Width = 40;
            // 
            // SendGiftTicketCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "SendGiftTicketCtrl";
            this.Load += new System.EventHandler(this.SendGiftTicketCtrl_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            this.skinSplitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel skinPanel1;
        private SplitContainer skinSplitContainer1;
        private GroupBox groupBox1;
        private Common.MemberIDTextBox skinTextBoxMemberId;
        private Panel skinPanel2;
        private GroupBox groupBox2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private Common.Components.BaseButton BaseButton6;
        private CCWin.SkinControl.SkinComboBox skinComboBox_giftTicket;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private Common.NumericTextBox textBoxCount;
        private Common.TextBox skinTextBoxMoney;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private DateTimePicker dateTimePickerStartDate;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private DateTimePicker dateTimePickerEndDate;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Common.TextBox textBoxRemarks;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private Common.Components.BaseButton baseButtonSave;
        private BindingSource memberBindingSource3;
        private DataGridView dataGridViewMembers;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewLinkColumn Column2;
    }
}

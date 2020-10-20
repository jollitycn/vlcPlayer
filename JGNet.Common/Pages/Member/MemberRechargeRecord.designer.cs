namespace JGNet.Common
{
    partial class MemberRechargeRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberRechargeRecord));
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.memberBalanceChangeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanelSendGift = new System.Windows.Forms.Panel();
            this.quickDateSelector1 = new JGNet.Common.Components.QuickDateSelector(this.components);
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBoxMemberId = new JGNet.Common.MemberIDTextBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.dateIntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rechargeMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DonateMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reatilMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBalanceChangeBindingSource)).BeginInit();
            this.skinPanelSendGift.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.dataGridView1);
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.Location = new System.Drawing.Point(0, 75);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1160, 575);
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
            this.dateIntDataGridViewTextBoxColumn,
            this.rechargeMoneyDataGridViewTextBoxColumn,
            this.DonateMoney,
            this.reatilMoneyDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.memberBalanceChangeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 575);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // memberBalanceChangeBindingSource
            // 
            this.memberBalanceChangeBindingSource.DataSource = typeof(JGNet.Core.InteractEntity.MemberBalanceChange);
            // 
            // skinPanelSendGift
            // 
            this.skinPanelSendGift.BackColor = System.Drawing.Color.Transparent;
            this.skinPanelSendGift.Controls.Add(this.quickDateSelector1);
            this.skinPanelSendGift.Controls.Add(this.dateTimePicker_End);
            this.skinPanelSendGift.Controls.Add(this.dateTimePicker_Start);
            this.skinPanelSendGift.Controls.Add(this.skinLabel6);
            this.skinPanelSendGift.Controls.Add(this.skinLabel7);
            this.skinPanelSendGift.Controls.Add(this.skinTextBoxMemberId);
            this.skinPanelSendGift.Controls.Add(this.skinLabel3);
            this.skinPanelSendGift.Controls.Add(this.BaseButton1);
            this.skinPanelSendGift.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanelSendGift.Location = new System.Drawing.Point(0, 0);
            this.skinPanelSendGift.Name = "skinPanelSendGift";
            this.skinPanelSendGift.Size = new System.Drawing.Size(1160, 75);
            this.skinPanelSendGift.TabIndex = 0;
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
            this.quickDateSelector1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.quickDateSelector1.ItemAnamorphosis = true;
            this.quickDateSelector1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemBorderShow = true;
            this.quickDateSelector1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.quickDateSelector1.ItemRadius = 4;
            this.quickDateSelector1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Location = new System.Drawing.Point(350, 11);
            this.quickDateSelector1.Name = "quickDateSelector1";
            this.quickDateSelector1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.Size = new System.Drawing.Size(36, 27);
            this.quickDateSelector1.SkinAllColor = true;
            this.quickDateSelector1.StartDateTimePicker = this.dateTimePicker_Start;
            this.quickDateSelector1.TabIndex = 128;
            this.quickDateSelector1.Text = "quickDateSelector1";
            this.quickDateSelector1.TitleAnamorphosis = true;
            this.quickDateSelector1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.quickDateSelector1.TitleRadius = 4;
            this.quickDateSelector1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.quickDateSelector1.PickerValueChanged += new CJBasic.Action<object, System.EventArgs>(this.BaseButton_Search_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.CustomFormat = "";
            this.dateTimePicker_End.Location = new System.Drawing.Point(217, 14);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker_End.TabIndex = 124;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(41, 15);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(130, 21);
            this.dateTimePicker_Start.TabIndex = 123;
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(181, 17);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(32, 17);
            this.skinLabel6.TabIndex = 125;
            this.skinLabel6.Text = "结束";
            // 
            // skinLabel7
            // 
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(3, 17);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(32, 17);
            this.skinLabel7.TabIndex = 126;
            this.skinLabel7.Text = "开始";
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
            this.skinTextBoxMemberId.Location = new System.Drawing.Point(423, 12);
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
            this.skinTextBoxMemberId.Size = new System.Drawing.Size(142, 28);
            // 
            // 
            // 
            this.skinTextBoxMemberId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxMemberId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxMemberId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxMemberId.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxMemberId.SkinTxt.Name = "BaseText";
            this.skinTextBoxMemberId.SkinTxt.Size = new System.Drawing.Size(132, 18);
            this.skinTextBoxMemberId.SkinTxt.TabIndex = 0;
            this.skinTextBoxMemberId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMemberId.SkinTxt.WaterText = "输入卡号/姓名并回车";
            this.skinTextBoxMemberId.TabIndex = 6;
            this.skinTextBoxMemberId.TabStop = true;
            this.skinTextBoxMemberId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxMemberId.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxMemberId.WaterText = "输入卡号/姓名并回车";
            this.skinTextBoxMemberId.WordWrap = true;
            this.skinTextBoxMemberId.MemberSelected += new System.Action<JGNet.Member>(this.skinTextBoxMemberId_MemberSelected);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(387, 17);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(32, 17);
            this.skinLabel3.TabIndex = 4;
            this.skinLabel3.Text = "会员";
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.DownBack")));
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(580, 11);
            this.BaseButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.MouseBack")));
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.NormlBack")));
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 1;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // dateIntDataGridViewTextBoxColumn
            // 
            this.dateIntDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dateIntDataGridViewTextBoxColumn.DataPropertyName = "DateInt";
            this.dateIntDataGridViewTextBoxColumn.HeaderText = "日期";
            this.dateIntDataGridViewTextBoxColumn.MaxInputLength = 12767;
            this.dateIntDataGridViewTextBoxColumn.Name = "dateIntDataGridViewTextBoxColumn";
            this.dateIntDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateIntDataGridViewTextBoxColumn.Width = 280;
            // 
            // rechargeMoneyDataGridViewTextBoxColumn
            // 
            this.rechargeMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName = "RechargeMoney";
            this.rechargeMoneyDataGridViewTextBoxColumn.HeaderText = "充值金额";
            this.rechargeMoneyDataGridViewTextBoxColumn.Name = "rechargeMoneyDataGridViewTextBoxColumn";
            this.rechargeMoneyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rechargeMoneyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rechargeMoneyDataGridViewTextBoxColumn.Width = 280;
            // 
            // DonateMoney
            // 
            this.DonateMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DonateMoney.DataPropertyName = "DonateMoney";
            this.DonateMoney.HeaderText = "赠送金额";
            this.DonateMoney.Name = "DonateMoney";
            this.DonateMoney.ReadOnly = true;
            this.DonateMoney.Width = 250;
            // 
            // reatilMoneyDataGridViewTextBoxColumn
            // 
            this.reatilMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.reatilMoneyDataGridViewTextBoxColumn.DataPropertyName = "ReatilMoney";
            this.reatilMoneyDataGridViewTextBoxColumn.HeaderText = "消费金额";
            this.reatilMoneyDataGridViewTextBoxColumn.Name = "reatilMoneyDataGridViewTextBoxColumn";
            this.reatilMoneyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reatilMoneyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.reatilMoneyDataGridViewTextBoxColumn.Width = 280;
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "结余余额";
            this.balanceDataGridViewTextBoxColumn.MaxInputLength = 12767;
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            this.balanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.balanceDataGridViewTextBoxColumn.Width = 78;
            // 
            // MemberRechargeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanelSendGift);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MemberRechargeRecord";
            this.Load += new System.EventHandler(this.MemberconsumptionSearch_Load);
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBalanceChangeBindingSource)).EndInit();
            this.skinPanelSendGift.ResumeLayout(false);
            this.skinPanelSendGift.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel skinPanelSendGift;
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Common.Components.BaseButton BaseButton1;
        private MemberIDTextBox skinTextBoxMemberId;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private System.Windows.Forms.BindingSource memberBalanceChangeBindingSource;
        private Components.QuickDateSelector quickDateSelector1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateIntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn rechargeMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonateMoney;
        private System.Windows.Forms.DataGridViewLinkColumn reatilMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
    }
}

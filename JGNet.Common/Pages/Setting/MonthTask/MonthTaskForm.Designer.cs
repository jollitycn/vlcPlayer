using CCWin.SkinControl;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class MonthTaskForm
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
            this.ReportMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinFlowLayoutPanel1 = new CCWin.SkinControl.SkinFlowLayoutPanel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinComboBoxMonth = new CCWin.SkinControl.SkinComboBox();
            this.skinLabelGuide = new CCWin.SkinControl.SkinLabel();
            this.skinLabelMonth = new CCWin.SkinControl.SkinLabel();
            this.skinPanel4 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.numericTextBoxOne = new JGNet.Common.NumericTextBox();
            this.baseButtonConfirm = new JGNet.Common.Components.BaseButton();
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton2 = new JGNet.Common.Components.BaseButton();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.memberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.skinFlowLayoutPanel1.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.skinPanel4.SuspendLayout();
            this.skinPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.dataGridView1);
            this.skinPanel1.Controls.Add(this.skinFlowLayoutPanel1);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(378, 493);
            this.skinPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportMonth,
            this.MonthExpense});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(378, 374);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // ReportMonth
            // 
            this.ReportMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ReportMonth.DataPropertyName = "Key";
            this.ReportMonth.Frozen = true;
            this.ReportMonth.HeaderText = "日期";
            this.ReportMonth.Name = "ReportMonth";
            this.ReportMonth.ReadOnly = true;
            this.ReportMonth.Width = 54;
            // 
            // MonthExpense
            // 
            this.MonthExpense.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MonthExpense.DataPropertyName = "Value";
            this.MonthExpense.HeaderText = "日销售目标";
            this.MonthExpense.Name = "MonthExpense";
            this.MonthExpense.Width = 90;
            // 
            // skinFlowLayoutPanel1
            // 
            this.skinFlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinFlowLayoutPanel1.Controls.Add(this.skinPanel2);
            this.skinFlowLayoutPanel1.Controls.Add(this.skinPanel4);
            this.skinFlowLayoutPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinFlowLayoutPanel1.DownBack = null;
            this.skinFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinFlowLayoutPanel1.MouseBack = null;
            this.skinFlowLayoutPanel1.Name = "skinFlowLayoutPanel1";
            this.skinFlowLayoutPanel1.NormlBack = null;
            this.skinFlowLayoutPanel1.Size = new System.Drawing.Size(378, 81);
            this.skinFlowLayoutPanel1.TabIndex = 8;
            // 
            // skinPanel2
            // 
            this.skinPanel2.AutoSize = true;
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.skinComboBoxMonth);
            this.skinPanel2.Controls.Add(this.skinLabelGuide);
            this.skinPanel2.Controls.Add(this.skinLabelMonth);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(3, 3);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(378, 33);
            this.skinPanel2.TabIndex = 4;
            // 
            // skinComboBoxMonth
            // 
            this.skinComboBoxMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxMonth.FormattingEnabled = true;
            this.skinComboBoxMonth.Location = new System.Drawing.Point(245, 8);
            this.skinComboBoxMonth.Name = "skinComboBoxMonth";
            this.skinComboBoxMonth.Size = new System.Drawing.Size(130, 22);
            this.skinComboBoxMonth.TabIndex = 6;
            this.skinComboBoxMonth.WaterText = "";
            // 
            // skinLabelGuide
            // 
            this.skinLabelGuide.AutoSize = true;
            this.skinLabelGuide.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelGuide.BorderColor = System.Drawing.Color.White;
            this.skinLabelGuide.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelGuide.Location = new System.Drawing.Point(5, 11);
            this.skinLabelGuide.Name = "skinLabelGuide";
            this.skinLabelGuide.Size = new System.Drawing.Size(44, 17);
            this.skinLabelGuide.TabIndex = 5;
            this.skinLabelGuide.Text = "导购员";
            // 
            // skinLabelMonth
            // 
            this.skinLabelMonth.AutoSize = true;
            this.skinLabelMonth.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelMonth.BorderColor = System.Drawing.Color.White;
            this.skinLabelMonth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelMonth.Location = new System.Drawing.Point(213, 11);
            this.skinLabelMonth.Name = "skinLabelMonth";
            this.skinLabelMonth.Size = new System.Drawing.Size(32, 17);
            this.skinLabelMonth.TabIndex = 5;
            this.skinLabelMonth.Text = "月份";
            // 
            // skinPanel4
            // 
            this.skinPanel4.AutoSize = true;
            this.skinPanel4.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel4.Controls.Add(this.skinLabel1);
            this.skinPanel4.Controls.Add(this.numericTextBoxOne);
            this.skinPanel4.Controls.Add(this.baseButtonConfirm);
            this.skinPanel4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel4.DownBack = null;
            this.skinPanel4.Location = new System.Drawing.Point(3, 42);
            this.skinPanel4.MouseBack = null;
            this.skinPanel4.Name = "skinPanel4";
            this.skinPanel4.NormlBack = null;
            this.skinPanel4.Size = new System.Drawing.Size(375, 35);
            this.skinPanel4.TabIndex = 161;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(95, 8);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 8;
            this.skinLabel1.Text = "统一目标";
            // 
            // numericTextBoxOne
            // 
            this.numericTextBoxOne.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericTextBoxOne.BackColor = System.Drawing.Color.Transparent;
            this.numericTextBoxOne.DecimalPlaces = 0;
            this.numericTextBoxOne.DownBack = null;
            this.numericTextBoxOne.Icon = null;
            this.numericTextBoxOne.IconIsButton = false;
            this.numericTextBoxOne.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.numericTextBoxOne.IsPasswordChat = '\0';
            this.numericTextBoxOne.IsSystemPasswordChar = false;
            this.numericTextBoxOne.Lines = new string[0];
            this.numericTextBoxOne.Location = new System.Drawing.Point(154, 2);
            this.numericTextBoxOne.Margin = new System.Windows.Forms.Padding(0);
            this.numericTextBoxOne.MaxLength = 32767;
            this.numericTextBoxOne.MaxNum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericTextBoxOne.MinimumSize = new System.Drawing.Size(28, 28);
            this.numericTextBoxOne.MinNum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericTextBoxOne.MouseBack = null;
            this.numericTextBoxOne.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.numericTextBoxOne.Multiline = false;
            this.numericTextBoxOne.Name = "numericTextBoxOne";
            this.numericTextBoxOne.NormlBack = null;
            this.numericTextBoxOne.Padding = new System.Windows.Forms.Padding(5);
            this.numericTextBoxOne.ReadOnly = false;
            this.numericTextBoxOne.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericTextBoxOne.ShowZero = false;
            this.numericTextBoxOne.Size = new System.Drawing.Size(140, 28);
            // 
            // 
            // 
            this.numericTextBoxOne.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericTextBoxOne.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextBoxOne.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.numericTextBoxOne.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.numericTextBoxOne.SkinTxt.Name = "BaseText";
            this.numericTextBoxOne.SkinTxt.Size = new System.Drawing.Size(130, 18);
            this.numericTextBoxOne.SkinTxt.TabIndex = 0;
            this.numericTextBoxOne.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.numericTextBoxOne.SkinTxt.WaterText = "";
            this.numericTextBoxOne.TabIndex = 160;
            this.numericTextBoxOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericTextBoxOne.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericTextBoxOne.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.numericTextBoxOne.WaterText = "";
            this.numericTextBoxOne.WordWrap = true;
            // 
            // baseButtonConfirm
            // 
            this.baseButtonConfirm.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonConfirm.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonConfirm.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonConfirm.Location = new System.Drawing.Point(297, 0);
            this.baseButtonConfirm.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonConfirm.Name = "baseButtonConfirm";
            this.baseButtonConfirm.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonConfirm.Size = new System.Drawing.Size(75, 32);
            this.baseButtonConfirm.TabIndex = 7;
            this.baseButtonConfirm.Text = "确定";
            this.baseButtonConfirm.UseVisualStyleBackColor = false;
            this.baseButtonConfirm.Click += new System.EventHandler(this.baseButtonConfirm_Click);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton2);
            this.skinPanel3.Controls.Add(this.BaseButton1);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 455);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(378, 38);
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
            this.BaseButton2.Location = new System.Drawing.Point(216, 6);
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
            this.BaseButton1.Location = new System.Drawing.Point(297, 6);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 4;
            this.BaseButton1.Text = "关闭";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton1_Click);
            // 
            // MonthTaskForm
            // 
            this.AcceptButton = this.BaseButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = true;
            this.ClientSize = new System.Drawing.Size(386, 525);
            this.Controls.Add(this.skinPanel1);
            this.Name = "MonthTaskForm";
            this.Text = "日销售目标";
            this.Load += new System.EventHandler(this.MonthTaskForm_Load);
            this.Shown += new System.EventHandler(this.MonthTaskForm_Shown);
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.skinFlowLayoutPanel1.ResumeLayout(false);
            this.skinFlowLayoutPanel1.PerformLayout();
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.skinPanel4.ResumeLayout(false);
            this.skinPanel4.PerformLayout();
            this.skinPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton2;
        private Common.Components.BaseButton BaseButton1;
        private BindingSource memberBindingSource;
        private DataGridView dataGridView1;
        private SkinFlowLayoutPanel skinFlowLayoutPanel1;
        private SkinPanel skinPanel2;
        private SkinComboBox skinComboBoxMonth;
        private SkinLabel skinLabelGuide;
        private SkinLabel skinLabelMonth;
        private SkinPanel skinPanel4;
        private SkinLabel skinLabel1;
        private NumericTextBox numericTextBoxOne;
        private BaseButton baseButtonConfirm;
        private DataGridViewTextBoxColumn ReportMonth;
        private DataGridViewTextBoxColumn MonthExpense;
    }
}
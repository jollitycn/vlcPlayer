using CCWin.SkinControl;
using JGNet.Common;
using JGNet.Common.Components;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class DataGridViewColumnsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridViewColumnsForm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.dataGridViewSizeRange = new System.Windows.Forms.DataGridView();
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.skinCheckBoxSelectAll = new CCWin.SkinControl.SkinCheckBox();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.BaseButton2 = new JGNet.Common.Components.BaseButton();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizeRange)).BeginInit();
            this.skinPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.dataGridViewSizeRange);
            this.skinPanel1.Controls.Add(this.skinPanel3);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(292, 568);
            this.skinPanel1.TabIndex = 0;
            // 
            // dataGridViewSizeRange
            // 
            this.dataGridViewSizeRange.AllowUserToAddRows = false;
            this.dataGridViewSizeRange.AllowUserToDeleteRows = false;
            this.dataGridViewSizeRange.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSizeRange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.HeaderID});
            this.dataGridViewSizeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSizeRange.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSizeRange.Name = "dataGridViewSizeRange";
            this.dataGridViewSizeRange.RowTemplate.Height = 23;
            this.dataGridViewSizeRange.Size = new System.Drawing.Size(292, 530);
            this.dataGridViewSizeRange.TabIndex = 119;
            this.dataGridViewSizeRange.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSizeRange_CellValueChanged);
            this.dataGridViewSizeRange.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewSizeRange_CurrentCellDirtyStateChanged);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.skinCheckBoxSelectAll);
            this.skinPanel3.Controls.Add(this.BaseButton1);
            this.skinPanel3.Controls.Add(this.BaseButton2);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(0, 530);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(292, 38);
            this.skinPanel3.TabIndex = 2;
            // 
            // skinCheckBoxSelectAll
            // 
            this.skinCheckBoxSelectAll.AutoSize = true;
            this.skinCheckBoxSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBoxSelectAll.Checked = true;
            this.skinCheckBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBoxSelectAll.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBoxSelectAll.DownBack = null;
            this.skinCheckBoxSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBoxSelectAll.Location = new System.Drawing.Point(13, 10);
            this.skinCheckBoxSelectAll.MouseBack = null;
            this.skinCheckBoxSelectAll.Name = "skinCheckBoxSelectAll";
            this.skinCheckBoxSelectAll.NormlBack = null;
            this.skinCheckBoxSelectAll.SelectedDownBack = null;
            this.skinCheckBoxSelectAll.SelectedMouseBack = null;
            this.skinCheckBoxSelectAll.SelectedNormlBack = null;
            this.skinCheckBoxSelectAll.Size = new System.Drawing.Size(51, 21);
            this.skinCheckBoxSelectAll.TabIndex = 120;
            this.skinCheckBoxSelectAll.Text = "全选";
            this.skinCheckBoxSelectAll.UseVisualStyleBackColor = false;
            // 
            // BaseButton1
            // 
            this.BaseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.DownBack")));
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(214, 3);
            this.BaseButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.MouseBack")));
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton1.NormlBack")));
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 5;
            this.BaseButton1.Text = "关闭";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Quit_Click);
            // 
            // BaseButton2
            // 
            this.BaseButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton2.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton2.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton2.Location = new System.Drawing.Point(133, 3);
            this.BaseButton2.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton2.Name = "BaseButton2";
            this.BaseButton2.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton2.Size = new System.Drawing.Size(75, 32);
            this.BaseButton2.TabIndex = 3;
            this.BaseButton2.Text = "确定";
            this.BaseButton2.UseVisualStyleBackColor = false;
            this.BaseButton2.Click += new System.EventHandler(this.BaseButton_OK_Click);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "Visible";
            this.Column5.FalseValue = "false";
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.TrueValue = "true";
            this.Column5.Width = 19;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "HeaderText";
            this.Column1.HeaderText = "列名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 230;
            // 
            // HeaderID
            // 
            this.HeaderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HeaderID.DataPropertyName = "HeaderID";
            this.HeaderID.HeaderText = "HeaderID";
            this.HeaderID.Name = "HeaderID";
            this.HeaderID.Visible = false;
            // 
            // DataGridViewColumnsForm
            // 
            this.AcceptButton = this.BaseButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 600);
            this.Controls.Add(this.skinPanel1);
            this.Name = "DataGridViewColumnsForm";
            this.Text = "显示字段";
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSizeRange)).EndInit();
            this.skinPanel3.ResumeLayout(false);
            this.skinPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanel skinPanel1;
        private SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton2;
        private BaseButton BaseButton1;
        protected internal DataGridView dataGridViewSizeRange;
        protected internal SkinCheckBox skinCheckBoxSelectAll;
        private DataGridViewCheckBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn HeaderID;
    }
}
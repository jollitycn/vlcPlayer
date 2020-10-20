using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Manage;

namespace JGNet.Manage.Pages
{
    partial class PfSaleAnalysisCollectTypeForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PfSaleAnalysisCollectTypeForm1));
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.groupBoxQueryResult = new CCWin.SkinControl.SkinPanel();
            this.dataGridViewQueryResults = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new CCWin.SkinControl.SkinPanel();
            this.dataGridViewTarget = new System.Windows.Forms.DataGridView();
            this.skinPanelSelectBtn = new CCWin.SkinControl.SkinPanel();
            this.BaseButton7 = new JGNet.Common.Components.BaseButton();
            this.BaseButton6 = new JGNet.Common.Components.BaseButton();
            this.BaseButton5 = new JGNet.Common.Components.BaseButton();
            this.BaseButton2 = new JGNet.Common.Components.BaseButton();
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.BaseButton3 = new JGNet.Common.Components.BaseButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel2.SuspendLayout();
            this.groupBoxQueryResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResults)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).BeginInit();
            this.skinPanelSelectBtn.SuspendLayout();
            this.skinPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.groupBoxQueryResult);
            this.skinPanel2.Controls.Add(this.groupBox2);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(4, 28);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(586, 373);
            this.skinPanel2.TabIndex = 3;
            // 
            // groupBoxQueryResult
            // 
            this.groupBoxQueryResult.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxQueryResult.Controls.Add(this.dataGridViewQueryResults);
            this.groupBoxQueryResult.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.groupBoxQueryResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxQueryResult.DownBack = null;
            this.groupBoxQueryResult.Location = new System.Drawing.Point(0, 0);
            this.groupBoxQueryResult.MouseBack = null;
            this.groupBoxQueryResult.Name = "groupBoxQueryResult";
            this.groupBoxQueryResult.NormlBack = null;
            this.groupBoxQueryResult.Size = new System.Drawing.Size(240, 373);
            this.groupBoxQueryResult.TabIndex = 6;
            this.groupBoxQueryResult.Text = "可选商品";
            // 
            // dataGridViewQueryResults
            // 
            this.dataGridViewQueryResults.AllowUserToAddRows = false;
            this.dataGridViewQueryResults.AllowUserToDeleteRows = false;
            this.dataGridViewQueryResults.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewQueryResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQueryResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQueryResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewQueryResults.Name = "dataGridViewQueryResults";
            this.dataGridViewQueryResults.ReadOnly = true;
            this.dataGridViewQueryResults.RowTemplate.Height = 23;
            this.dataGridViewQueryResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewQueryResults.Size = new System.Drawing.Size(240, 373);
            this.dataGridViewQueryResults.TabIndex = 12;
            this.dataGridViewQueryResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQueryResults_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridViewTarget);
            this.groupBox2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.DownBack = null;
            this.groupBox2.Location = new System.Drawing.Point(346, 0);
            this.groupBox2.MouseBack = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.NormlBack = null;
            this.groupBox2.Size = new System.Drawing.Size(240, 373);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.Text = "目标商品";
            // 
            // dataGridViewTarget
            // 
            this.dataGridViewTarget.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridViewTarget.AllowUserToAddRows = false;
            this.dataGridViewTarget.AllowUserToDeleteRows = false;
            this.dataGridViewTarget.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dataGridViewTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTarget.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTarget.Name = "dataGridViewTarget";
            this.dataGridViewTarget.RowTemplate.Height = 23;
            this.dataGridViewTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTarget.Size = new System.Drawing.Size(240, 373);
            this.dataGridViewTarget.TabIndex = 17;
            this.dataGridViewTarget.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTarget_CellDoubleClick);
            // 
            // skinPanelSelectBtn
            // 
            this.skinPanelSelectBtn.BackColor = System.Drawing.Color.Transparent;
            this.skinPanelSelectBtn.Controls.Add(this.BaseButton7);
            this.skinPanelSelectBtn.Controls.Add(this.BaseButton6);
            this.skinPanelSelectBtn.Controls.Add(this.BaseButton5);
            this.skinPanelSelectBtn.Controls.Add(this.BaseButton2);
            this.skinPanelSelectBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanelSelectBtn.DownBack = null;
            this.skinPanelSelectBtn.Location = new System.Drawing.Point(249, 28);
            this.skinPanelSelectBtn.MouseBack = null;
            this.skinPanelSelectBtn.Name = "skinPanelSelectBtn";
            this.skinPanelSelectBtn.NormlBack = null;
            this.skinPanelSelectBtn.Size = new System.Drawing.Size(96, 366);
            this.skinPanelSelectBtn.TabIndex = 7;
            // 
            // BaseButton7
            // 
            this.BaseButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton7.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton7.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton7.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton7.DownBack")));
            this.BaseButton7.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton7.Location = new System.Drawing.Point(11, 222);
            this.BaseButton7.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton7.MouseBack")));
            this.BaseButton7.Name = "BaseButton7";
            this.BaseButton7.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton7.NormlBack")));
            this.BaseButton7.Size = new System.Drawing.Size(75, 32);
            this.BaseButton7.TabIndex = 14;
            this.BaseButton7.Text = "<";
            this.BaseButton7.UseVisualStyleBackColor = false;
            this.BaseButton7.Click += new System.EventHandler(this.BaseButtonRemoveSingle_Click);
            // 
            // BaseButton6
            // 
            this.BaseButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton6.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton6.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton6.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton6.DownBack")));
            this.BaseButton6.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton6.Location = new System.Drawing.Point(11, 184);
            this.BaseButton6.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton6.MouseBack")));
            this.BaseButton6.Name = "BaseButton6";
            this.BaseButton6.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton6.NormlBack")));
            this.BaseButton6.Size = new System.Drawing.Size(75, 32);
            this.BaseButton6.TabIndex = 13;
            this.BaseButton6.Text = "<<";
            this.BaseButton6.UseVisualStyleBackColor = false;
            this.BaseButton6.Click += new System.EventHandler(this.BaseButtonRemoveAll_Click);
            // 
            // BaseButton5
            // 
            this.BaseButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton5.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton5.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton5.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton5.DownBack")));
            this.BaseButton5.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton5.Location = new System.Drawing.Point(11, 146);
            this.BaseButton5.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton5.MouseBack")));
            this.BaseButton5.Name = "BaseButton5";
            this.BaseButton5.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton5.NormlBack")));
            this.BaseButton5.Size = new System.Drawing.Size(75, 32);
            this.BaseButton5.TabIndex = 12;
            this.BaseButton5.Text = ">>";
            this.BaseButton5.UseVisualStyleBackColor = false;
            this.BaseButton5.Click += new System.EventHandler(this.BaseButtonAddAll_Click);
            // 
            // BaseButton2
            // 
            this.BaseButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton2.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton2.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton2.DownBack")));
            this.BaseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton2.Location = new System.Drawing.Point(11, 108);
            this.BaseButton2.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton2.MouseBack")));
            this.BaseButton2.Name = "BaseButton2";
            this.BaseButton2.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton2.NormlBack")));
            this.BaseButton2.Size = new System.Drawing.Size(75, 32);
            this.BaseButton2.TabIndex = 11;
            this.BaseButton2.Text = ">";
            this.BaseButton2.UseVisualStyleBackColor = false;
            this.BaseButton2.Click += new System.EventHandler(this.BaseButtonAddSingle_Click);
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.Controls.Add(this.BaseButton3);
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(4, 400);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(586, 41);
            this.skinPanel3.TabIndex = 4;
            // 
            // BaseButton3
            // 
            this.BaseButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton3.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton3.DownBack = ((System.Drawing.Image)(resources.GetObject("BaseButton3.DownBack")));
            this.BaseButton3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton3.Location = new System.Drawing.Point(256, 6);
            this.BaseButton3.MouseBack = ((System.Drawing.Image)(resources.GetObject("BaseButton3.MouseBack")));
            this.BaseButton3.Name = "BaseButton3";
            this.BaseButton3.NormlBack = ((System.Drawing.Image)(resources.GetObject("BaseButton3.NormlBack")));
            this.BaseButton3.Size = new System.Drawing.Size(75, 32);
            this.BaseButton3.TabIndex = 18;
            this.BaseButton3.Text = "确定";
            this.BaseButton3.UseVisualStyleBackColor = false;
            this.BaseButton3.Click += new System.EventHandler(this.BaseButton1_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Key";
            this.Column1.HeaderText = "可选项目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 197;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "Key";
            this.Column2.HeaderText = "已选项目";
            this.Column2.Name = "Column2";
            this.Column2.Width = 197;
            // 
            // PfSaleAnalysisCollectTypeForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 445);
            this.Controls.Add(this.skinPanelSelectBtn);
            this.Controls.Add(this.skinPanel3);
            this.Controls.Add(this.skinPanel2);
            this.Name = "PfSaleAnalysisCollectTypeForm1";
            this.Text = "增加汇总方式";
            this.skinPanel2.ResumeLayout(false);
            this.groupBoxQueryResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueryResults)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarget)).EndInit();
            this.skinPanelSelectBtn.ResumeLayout(false);
            this.skinPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPanel groupBoxQueryResult;
        private CCWin.SkinControl.SkinPanel skinPanelSelectBtn;
        private Common.Components.BaseButton BaseButton7;
        private Common.Components.BaseButton BaseButton6;
        private Common.Components.BaseButton BaseButton5;
        private Common.Components.BaseButton BaseButton2;
        private CCWin.SkinControl.SkinPanel groupBox2;
        private CCWin.SkinControl.SkinPanel skinPanel3;
        private Common.Components.BaseButton BaseButton3;
        private System.Windows.Forms.DataGridView dataGridViewQueryResults;
        private System.Windows.Forms.DataGridView dataGridViewTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
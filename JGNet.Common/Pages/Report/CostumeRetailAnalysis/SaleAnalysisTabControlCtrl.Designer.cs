using JGNet.Common;
using JGNet.Manage;

namespace JGNet.Manage
{
    partial class SaleAnalysisTabControlCtrl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.refundCtrl1 = new  CostumeRetailAnalysisCtrl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refundDirectCtrl1 = new JGNet.Common.PfCostumeRetailAnalysisCtrl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160,650);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.refundCtrl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(952, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "零售";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // refundCtrl1
            // 
            this.refundCtrl1.Action = null;
            this.refundCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.refundCtrl1.CurrentTabPage = null;
            this.refundCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refundCtrl1.Location = new System.Drawing.Point(3, 3);
            this.refundCtrl1.Name = "refundCtrl1";
            this.refundCtrl1.RefreshPageDisable = false;
            this.refundCtrl1.Size = new System.Drawing.Size(946, 514);
            this.refundCtrl1.SourceCtrlType = null;
            this.refundCtrl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.refundDirectCtrl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(952, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "批发";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // refundDirectCtrl1
            // 
            this.refundDirectCtrl1.Action = null;
            this.refundDirectCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.refundDirectCtrl1.CurrentTabPage = null;
            this.refundDirectCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refundDirectCtrl1.Location = new System.Drawing.Point(3, 3);
            this.refundDirectCtrl1.Name = "refundDirectCtrl1";
            this.refundDirectCtrl1.RefreshPageDisable = false;
            this.refundDirectCtrl1.Size = new System.Drawing.Size(946, 518);
            this.refundDirectCtrl1.SourceCtrlType = null;
            this.refundDirectCtrl1.TabIndex = 0;
            // 
            // RefundTabControlCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl1);
            this.Name = "RefundTabControlCtrl";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CostumeRetailAnalysisCtrl refundCtrl1;
        private PfCostumeRetailAnalysisCtrl refundDirectCtrl1;
    }
}

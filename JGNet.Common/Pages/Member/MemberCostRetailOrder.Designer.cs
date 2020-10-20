using JGNet.Common;
using JGNet.Common.Components;

namespace JGNet.Common
{
    partial class MemberCostRetailOrder
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
            this.retailDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.retailOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.retailOrderListCtrl2 = new JGNet.Common.RetailOrderListCtrl();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.retailDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retailOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // retailDetailBindingSource
            // 
            this.retailDetailBindingSource.DataSource = typeof(JGNet.RetailDetail);
            // 
            // retailOrderBindingSource
            // 
            this.retailOrderBindingSource.DataSource = typeof(JGNet.RetailOrder);
            // 
            // retailOrderListCtrl2
            // 
            this.retailOrderListCtrl2.Action = null;
            this.retailOrderListCtrl2.CurrentTabPage = null;
            this.retailOrderListCtrl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.retailOrderListCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retailOrderListCtrl2.HasInvokeTabClose = false;
            this.retailOrderListCtrl2.IsShowOnePage = false;
            this.retailOrderListCtrl2.Location = new System.Drawing.Point(4, 38);
            this.retailOrderListCtrl2.Name = "retailOrderListCtrl2";
            this.retailOrderListCtrl2.RefreshPageDisable = false;
            this.retailOrderListCtrl2.Size = new System.Drawing.Size(973, 474);
            this.retailOrderListCtrl2.SourceCtrlType = null;
            this.retailOrderListCtrl2.SourceTabPage = null;
            this.retailOrderListCtrl2.TabIndex = 1;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(4, 28);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(973, 10);
            this.skinPanel1.TabIndex = 0;
            // 
            // MemberCostRetailOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 516);
            this.Controls.Add(this.retailOrderListCtrl2);
            this.Controls.Add(this.skinPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberCostRetailOrder";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "会员消费历史";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RetailOrderSearchCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.retailDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retailOrderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion



        private System.Windows.Forms.Panel skinPanel1;
        private System.Windows.Forms.BindingSource retailDetailBindingSource;
        private System.Windows.Forms.BindingSource retailOrderBindingSource;
        
        private RetailOrderListCtrl retailOrderListCtrl2;
    }
}

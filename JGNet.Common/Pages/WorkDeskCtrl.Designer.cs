using CCWin.SkinControl;
using System.Windows.Forms;

namespace JGNet.Common
{
    partial class WorkDeskCtrl
    {
        /// <> 
        /// 必需的设计器变量。
        /// </>
        private System.ComponentModel.IContainer components = null;

        /// <> 
        /// 清理所有正在使用的资源。
        /// </>
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

        /// <> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.skinLabel15 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel16 = new CCWin.SkinControl.SkinLabel();
            this.linkLabelOnlineOrder = new System.Windows.Forms.LinkLabel();
            this.linkLabelOnlineOrderRefund = new System.Windows.Forms.LinkLabel();
            this.skinLabel17 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel18 = new CCWin.SkinControl.SkinLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.DifferenceOrderConfirmedIsFalseCount = new System.Windows.Forms.LinkLabel();
            this.linkLabelNewMember = new System.Windows.Forms.LinkLabel();
            this.linkLabel_checkOrderCount = new System.Windows.Forms.LinkLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.linkLabel_UnconfirmedAllocateOrderCount = new System.Windows.Forms.LinkLabel();
            this.skinLabel14 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel11 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel9 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.skinSplitContainer1.IsSplitterFixed = true;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel15);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel16);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabelOnlineOrder);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabelOnlineOrderRefund);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel17);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel18);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabel1);
            this.skinSplitContainer1.Panel1.Controls.Add(this.panel1);
            this.skinSplitContainer1.Panel1.Controls.Add(this.BaseButton1);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel10);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel7);
            this.skinSplitContainer1.Panel1.Controls.Add(this.DifferenceOrderConfirmedIsFalseCount);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabelNewMember);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabel_checkOrderCount);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel1);
            this.skinSplitContainer1.Panel1.Controls.Add(this.linkLabel_UnconfirmedAllocateOrderCount);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel14);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel11);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel6);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel9);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel4);
            this.skinSplitContainer1.Panel1.Controls.Add(this.skinLabel3);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 650);
            this.skinSplitContainer1.SplitterDistance = 288;
            this.skinSplitContainer1.TabIndex = 1;
            // 
            // skinLabel15
            // 
            this.skinLabel15.AutoSize = true;
            this.skinLabel15.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel15.BorderColor = System.Drawing.Color.White;
            this.skinLabel15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel15.Location = new System.Drawing.Point(121, 120);
            this.skinLabel15.Name = "skinLabel15";
            this.skinLabel15.Size = new System.Drawing.Size(104, 17);
            this.skinLabel15.TabIndex = 139;
            this.skinLabel15.Text = "张线上订单待发货";
            // 
            // skinLabel16
            // 
            this.skinLabel16.AutoSize = true;
            this.skinLabel16.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel16.BorderColor = System.Drawing.Color.White;
            this.skinLabel16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel16.Location = new System.Drawing.Point(121, 141);
            this.skinLabel16.Name = "skinLabel16";
            this.skinLabel16.Size = new System.Drawing.Size(104, 17);
            this.skinLabel16.TabIndex = 140;
            this.skinLabel16.Text = "张线上退款待处理";
            // 
            // linkLabelOnlineOrder
            // 
            this.linkLabelOnlineOrder.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelOnlineOrder.LinkColor = System.Drawing.Color.Red;
            this.linkLabelOnlineOrder.Location = new System.Drawing.Point(88, 118);
            this.linkLabelOnlineOrder.Name = "linkLabelOnlineOrder";
            this.linkLabelOnlineOrder.Size = new System.Drawing.Size(33, 20);
            this.linkLabelOnlineOrder.TabIndex = 135;
            this.linkLabelOnlineOrder.TabStop = true;
            this.linkLabelOnlineOrder.Text = "000";
            this.linkLabelOnlineOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelOnlineOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOnlineOrder_LinkClicked);
            // 
            // linkLabelOnlineOrderRefund
            // 
            this.linkLabelOnlineOrderRefund.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelOnlineOrderRefund.LinkColor = System.Drawing.Color.Red;
            this.linkLabelOnlineOrderRefund.Location = new System.Drawing.Point(88, 139);
            this.linkLabelOnlineOrderRefund.Name = "linkLabelOnlineOrderRefund";
            this.linkLabelOnlineOrderRefund.Size = new System.Drawing.Size(33, 20);
            this.linkLabelOnlineOrderRefund.TabIndex = 136;
            this.linkLabelOnlineOrderRefund.TabStop = true;
            this.linkLabelOnlineOrderRefund.Text = "000";
            this.linkLabelOnlineOrderRefund.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelOnlineOrderRefund.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOnlineOrderRefund_LinkClicked);
            // 
            // skinLabel17
            // 
            this.skinLabel17.AutoSize = true;
            this.skinLabel17.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel17.BorderColor = System.Drawing.Color.White;
            this.skinLabel17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel17.Location = new System.Drawing.Point(48, 120);
            this.skinLabel17.Name = "skinLabel17";
            this.skinLabel17.Size = new System.Drawing.Size(44, 17);
            this.skinLabel17.TabIndex = 137;
            this.skinLabel17.Text = "您还有";
            // 
            // skinLabel18
            // 
            this.skinLabel18.AutoSize = true;
            this.skinLabel18.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel18.BorderColor = System.Drawing.Color.White;
            this.skinLabel18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel18.Location = new System.Drawing.Point(48, 141);
            this.skinLabel18.Name = "skinLabel18";
            this.skinLabel18.Size = new System.Drawing.Size(44, 17);
            this.skinLabel18.TabIndex = 138;
            this.skinLabel18.Text = "您还有";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(110, 234);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(20, 17);
            this.linkLabel1.TabIndex = 134;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "有";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 650);
            this.panel1.TabIndex = 133;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Image = global::JGNet.Common.Properties.Resources.refresh;
            this.BaseButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseButton1.Location = new System.Drawing.Point(195, 5);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 0;
            this.BaseButton1.Text = " 刷新";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Refresh_Click);
            // 
            // skinLabel10
            // 
            this.skinLabel10.AutoSize = true;
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel10.Location = new System.Drawing.Point(121, 73);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(116, 17);
            this.skinLabel10.TabIndex = 23;
            this.skinLabel10.Text = "张店铺差异单未确认";
            // 
            // skinLabel7
            // 
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(121, 97);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(116, 17);
            this.skinLabel7.TabIndex = 23;
            this.skinLabel7.Text = "张店铺盘点单待审核";
            // 
            // DifferenceOrderConfirmedIsFalseCount
            // 
            this.DifferenceOrderConfirmedIsFalseCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DifferenceOrderConfirmedIsFalseCount.LinkColor = System.Drawing.Color.Red;
            this.DifferenceOrderConfirmedIsFalseCount.Location = new System.Drawing.Point(88, 71);
            this.DifferenceOrderConfirmedIsFalseCount.Name = "DifferenceOrderConfirmedIsFalseCount";
            this.DifferenceOrderConfirmedIsFalseCount.Size = new System.Drawing.Size(33, 20);
            this.DifferenceOrderConfirmedIsFalseCount.TabIndex = 3;
            this.DifferenceOrderConfirmedIsFalseCount.TabStop = true;
            this.DifferenceOrderConfirmedIsFalseCount.Text = "000";
            this.DifferenceOrderConfirmedIsFalseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DifferenceOrderConfirmedIsFalseCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_UnconfirmedDifferenceOrderCount_LinkClicked);
            // 
            // linkLabelNewMember
            // 
            this.linkLabelNewMember.AutoSize = true;
            this.linkLabelNewMember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelNewMember.LinkColor = System.Drawing.Color.Red;
            this.linkLabelNewMember.Location = new System.Drawing.Point(110, 258);
            this.linkLabelNewMember.Name = "linkLabelNewMember";
            this.linkLabelNewMember.Size = new System.Drawing.Size(29, 17);
            this.linkLabelNewMember.TabIndex = 3;
            this.linkLabelNewMember.TabStop = true;
            this.linkLabelNewMember.Text = "000";
            this.linkLabelNewMember.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelNewMember.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewMember_LinkClicked);
            // 
            // linkLabel_checkOrderCount
            // 
            this.linkLabel_checkOrderCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_checkOrderCount.LinkColor = System.Drawing.Color.Red;
            this.linkLabel_checkOrderCount.Location = new System.Drawing.Point(88, 95);
            this.linkLabel_checkOrderCount.Name = "linkLabel_checkOrderCount";
            this.linkLabel_checkOrderCount.Size = new System.Drawing.Size(33, 20);
            this.linkLabel_checkOrderCount.TabIndex = 3;
            this.linkLabel_checkOrderCount.TabStop = true;
            this.linkLabel_checkOrderCount.Text = "000";
            this.linkLabel_checkOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel_checkOrderCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_checkOrderCount_LinkClicked);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(10, 9);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(58, 22);
            this.skinLabel1.TabIndex = 11;
            this.skinLabel1.Text = "提示：";
            // 
            // linkLabel_UnconfirmedAllocateOrderCount
            // 
            this.linkLabel_UnconfirmedAllocateOrderCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_UnconfirmedAllocateOrderCount.LinkColor = System.Drawing.Color.Red;
            this.linkLabel_UnconfirmedAllocateOrderCount.Location = new System.Drawing.Point(88, 49);
            this.linkLabel_UnconfirmedAllocateOrderCount.Name = "linkLabel_UnconfirmedAllocateOrderCount";
            this.linkLabel_UnconfirmedAllocateOrderCount.Size = new System.Drawing.Size(33, 20);
            this.linkLabel_UnconfirmedAllocateOrderCount.TabIndex = 2;
            this.linkLabel_UnconfirmedAllocateOrderCount.TabStop = true;
            this.linkLabel_UnconfirmedAllocateOrderCount.Text = "000";
            this.linkLabel_UnconfirmedAllocateOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel_UnconfirmedAllocateOrderCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_UnconfirmedAllocateOrderCount_LinkClicked);
            // 
            // skinLabel14
            // 
            this.skinLabel14.AutoSize = true;
            this.skinLabel14.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel14.BorderColor = System.Drawing.Color.White;
            this.skinLabel14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel14.Location = new System.Drawing.Point(24, 258);
            this.skinLabel14.Name = "skinLabel14";
            this.skinLabel14.Size = new System.Drawing.Size(80, 17);
            this.skinLabel14.TabIndex = 16;
            this.skinLabel14.Text = "今日新增会员";
            // 
            // skinLabel11
            // 
            this.skinLabel11.AutoSize = true;
            this.skinLabel11.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel11.BorderColor = System.Drawing.Color.White;
            this.skinLabel11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel11.Location = new System.Drawing.Point(48, 234);
            this.skinLabel11.Name = "skinLabel11";
            this.skinLabel11.Size = new System.Drawing.Size(56, 17);
            this.skinLabel11.TabIndex = 16;
            this.skinLabel11.Text = "负数库存";
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(121, 51);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(116, 17);
            this.skinLabel6.TabIndex = 17;
            this.skinLabel6.Text = "张店铺调拨单待处理";
            // 
            // skinLabel9
            // 
            this.skinLabel9.AutoSize = true;
            this.skinLabel9.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel9.BorderColor = System.Drawing.Color.White;
            this.skinLabel9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel9.Location = new System.Drawing.Point(48, 73);
            this.skinLabel9.Name = "skinLabel9";
            this.skinLabel9.Size = new System.Drawing.Size(44, 17);
            this.skinLabel9.TabIndex = 18;
            this.skinLabel9.Text = "您还有";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(48, 97);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(44, 17);
            this.skinLabel4.TabIndex = 18;
            this.skinLabel4.Text = "您还有";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(48, 51);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(44, 17);
            this.skinLabel3.TabIndex = 19;
            this.skinLabel3.Text = "您还有";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WorkDeskCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.skinSplitContainer1);
            this.DoubleBuffered = true;
            this.Name = "WorkDeskCtrl";
            this.Load += new System.EventHandler(this.WorkDeskCtrl_Load);
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel1.PerformLayout();
            this.skinSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion 
        private SplitContainer skinSplitContainer1;  
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private System.Windows.Forms.LinkLabel linkLabel_checkOrderCount;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.LinkLabel linkLabel_UnconfirmedAllocateOrderCount;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private Common.Components.BaseButton BaseButton1;
        private System.Windows.Forms.Panel panel1;
        private SkinLabel skinLabel10;
        private LinkLabel DifferenceOrderConfirmedIsFalseCount;
        private SkinLabel skinLabel9;
        private LinkLabel linkLabel1;
        private Timer timer1;
        private SkinLabel skinLabel11;
        private LinkLabel linkLabelNewMember;
        private SkinLabel skinLabel14;
        private SkinLabel skinLabel15;
        private SkinLabel skinLabel16;
        private LinkLabel linkLabelOnlineOrder;
        private LinkLabel linkLabelOnlineOrderRefund;
        private SkinLabel skinLabel17;
        private SkinLabel skinLabel18;
    }
}

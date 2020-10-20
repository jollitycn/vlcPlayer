using CCWin.SkinControl;

namespace JGNet.Common.Components
{
    partial class TitleImageControlWidth
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
            this.flowLayoutPanel1 = new CCWin.SkinControl.SkinFlowLayoutPanel();
            this.panel1 = new CCWin.SkinControl.SkinPanel();
            this.baseButton1 = new JGNet.Common.Components.BaseButton();
            this.BaseButton3 = new JGNet.Common.Components.BaseButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.flowLayoutPanel1.DownBack = null;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MouseBack = null;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.NormlBack = null;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 328);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.baseButton1);
            this.panel1.Controls.Add(this.BaseButton3);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(0, 308);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Size = new System.Drawing.Size(487, 34);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // baseButton1
            // 
            this.baseButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.baseButton1.AutoSize = true;
            this.baseButton1.BackColor = System.Drawing.Color.Transparent;
            this.baseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButton1.DownBack = global::JGNet.Common.Properties.Resources.rightArrowHover;
            this.baseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButton1.Location = new System.Drawing.Point(398, 2);
            this.baseButton1.MouseBack = global::JGNet.Common.Properties.Resources.rightArrowHover;
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.NormlBack = global::JGNet.Common.Properties.Resources.rightArrowNormal;
            this.baseButton1.Size = new System.Drawing.Size(32, 32);
            this.baseButton1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.baseButton1, "后移");
            this.baseButton1.UseVisualStyleBackColor = false;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // BaseButton3
            // 
            this.BaseButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BaseButton3.AutoSize = true;
            this.BaseButton3.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton3.DownBack = global::JGNet.Common.Properties.Resources.leftArrowHover;
            this.BaseButton3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton3.Location = new System.Drawing.Point(360, 2);
            this.BaseButton3.MouseBack = global::JGNet.Common.Properties.Resources.leftArrowHover;
            this.BaseButton3.Name = "BaseButton3";
            this.BaseButton3.NormlBack = global::JGNet.Common.Properties.Resources.leftArrowNormal;
            this.BaseButton3.Size = new System.Drawing.Size(32, 32);
            this.BaseButton3.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BaseButton3, "前移");
            this.BaseButton3.UseVisualStyleBackColor = false;
            this.BaseButton3.Click += new System.EventHandler(this.BaseButton3_Click);
            // 
            // TitleImageControlWidth
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(80, 64);
            this.Name = "TitleImageControlWidth";
            this.Size = new System.Drawing.Size(487, 342);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private  SkinFlowLayoutPanel flowLayoutPanel1;
        private SkinPanel panel1;
        private BaseButton BaseButton3;
        private BaseButton baseButton1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

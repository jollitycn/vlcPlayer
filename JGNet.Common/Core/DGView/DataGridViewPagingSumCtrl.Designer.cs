using CCWin.SkinControl;
using System.Windows.Forms;

namespace JGNet.Common.Components
{
    partial class DataGridViewPagingSumCtrl
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
            this.contextMenuStripDataGridViewH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.summaryControlContainer2 = new JGNet.Common.SummaryControlContainer();
            this.summaryControlContainer1 = new JGNet.Common.SummaryControlContainer();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBoxPageSize = new CCWin.SkinControl.SkinComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.skinLabelTotalCount = new CCWin.SkinControl.SkinLabel();
            this.pageControlPanel21 = new CJBasic.Widget.PageControlPanel2();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.字段显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewContextMenuStrip1 = new JGNet.Common.Components.DataGridViewContextMenuStrip();
            this.contextMenuStripDataGridViewH.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDataGridViewH
            // 
            this.contextMenuStripDataGridViewH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制CToolStripMenuItem,
            this.显示图片ToolStripMenuItem});
            this.contextMenuStripDataGridViewH.Name = "contextMenuStripDataGridView";
            this.contextMenuStripDataGridViewH.Size = new System.Drawing.Size(125, 48);
            // 
            // 复制CToolStripMenuItem
            // 
            this.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem";
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制CToolStripMenuItem.Text = "复制";
            this.复制CToolStripMenuItem.Click += new System.EventHandler(this.复制CToolStripMenuItem_Click);
            // 
            // 显示图片ToolStripMenuItem
            // 
            this.显示图片ToolStripMenuItem.Name = "显示图片ToolStripMenuItem";
            this.显示图片ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示图片ToolStripMenuItem.Text = "显示图片";
            this.显示图片ToolStripMenuItem.Click += new System.EventHandler(this.显示图片ToolStripMenuItem_Click);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.panel4);
            this.skinPanel1.Controls.Add(this.skinPanel2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.ForeColor = System.Drawing.Color.Black;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(1160,650);
            this.skinPanel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 516);
            this.panel4.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.summaryControlContainer2);
            this.panel5.Controls.Add(this.summaryControlContainer1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 470);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(960, 46);
            this.panel5.TabIndex = 0;
            // 
            // summaryControlContainer2
            // 
            this.summaryControlContainer2.DGV = null;
            this.summaryControlContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.summaryControlContainer2.FormatString = "F02";
            this.summaryControlContainer2.Location = new System.Drawing.Point(0, 23);
            this.summaryControlContainer2.Name = "summaryControlContainer2";
            this.summaryControlContainer2.OffsetTop = 0;
            this.summaryControlContainer2.ReportShowZero = false;
            this.summaryControlContainer2.Size = new System.Drawing.Size(960, 23);
            this.summaryControlContainer2.SummaryColumns = null;
            this.summaryControlContainer2.SumRowHeaderText = "总计";
            this.summaryControlContainer2.TabIndex = 2;
            this.summaryControlContainer2.TotalRow = null;
            // 
            // summaryControlContainer1
            // 
            this.summaryControlContainer1.DGV = null;
            this.summaryControlContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.summaryControlContainer1.FormatString = "F02";
            this.summaryControlContainer1.Location = new System.Drawing.Point(0, 0);
            this.summaryControlContainer1.Name = "summaryControlContainer1";
            this.summaryControlContainer1.OffsetTop = 0;
            this.summaryControlContainer1.ReportShowZero = false;
            this.summaryControlContainer1.Size = new System.Drawing.Size(960, 23);
            this.summaryControlContainer1.SummaryColumns = null;
            this.summaryControlContainer1.SumRowHeaderText = "总计";
            this.summaryControlContainer1.TabIndex = 0;
            this.summaryControlContainer1.TotalRow = null;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.panel1);
            this.skinPanel2.Controls.Add(this.pageControlPanel21);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 516);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(960, 34);
            this.skinPanel2.TabIndex = 9;
            this.skinPanel2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 34);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.skinLabel1);
            this.panel2.Controls.Add(this.skinComboBoxPageSize);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 28);
            this.panel2.TabIndex = 13;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(80, 3);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(37, 17);
            this.skinLabel1.TabIndex = 12;
            this.skinLabel1.Text = "行/页";
            this.skinLabel1.Visible = false;
            // 
            // skinComboBoxPageSize
            // 
            this.skinComboBoxPageSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxPageSize.FormattingEnabled = true;
            this.skinComboBoxPageSize.Location = new System.Drawing.Point(3, 3);
            this.skinComboBoxPageSize.Name = "skinComboBoxPageSize";
            this.skinComboBoxPageSize.Size = new System.Drawing.Size(71, 22);
            this.skinComboBoxPageSize.TabIndex = 11;
            this.skinComboBoxPageSize.Visible = false;
            this.skinComboBoxPageSize.WaterText = "";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.skinLabelTotalCount);
            this.panel3.Location = new System.Drawing.Point(129, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(45, 20);
            this.panel3.TabIndex = 14;
            // 
            // skinLabelTotalCount
            // 
            this.skinLabelTotalCount.AutoSize = true;
            this.skinLabelTotalCount.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelTotalCount.BorderColor = System.Drawing.Color.White;
            this.skinLabelTotalCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelTotalCount.Location = new System.Drawing.Point(3, 3);
            this.skinLabelTotalCount.Name = "skinLabelTotalCount";
            this.skinLabelTotalCount.Size = new System.Drawing.Size(39, 17);
            this.skinLabelTotalCount.TabIndex = 10;
            this.skinLabelTotalCount.Text = "共0行";
            this.skinLabelTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageControlPanel21
            // 
            this.pageControlPanel21.BackColor = System.Drawing.Color.White;
            this.pageControlPanel21.ContextMenuEnglish = false;
            this.pageControlPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageControlPanel21.Location = new System.Drawing.Point(0, 0);
            this.pageControlPanel21.Name = "pageControlPanel21";
            this.pageControlPanel21.Size = new System.Drawing.Size(960, 34);
            this.pageControlPanel21.TabIndex = 1;
            this.pageControlPanel21.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "复制";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "显示图片";
            // 
            // 字段显示ToolStripMenuItem
            // 
            this.字段显示ToolStripMenuItem.Name = "字段显示ToolStripMenuItem";
            this.字段显示ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.字段显示ToolStripMenuItem.Text = "列显示";
            this.字段显示ToolStripMenuItem.Click += new System.EventHandler(this.字段显示ToolStripMenuItem_Click);
            // 
            // dataGridViewContextMenuStrip1
            // 
            this.dataGridViewContextMenuStrip1.DataGridView = null;
            this.dataGridViewContextMenuStrip1.Debug = false;
            this.dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible = false;
            this.dataGridViewContextMenuStrip1.Name = "contextMenuStrip1";
            this.dataGridViewContextMenuStrip1.Size = new System.Drawing.Size(113, 4);
            // 
            // DataGridViewPagingSumCtrl
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinPanel1);
            this.Name = "DataGridViewPagingSumCtrl";
            this.Size = new System.Drawing.Size(1160,650);
            this.contextMenuStripDataGridViewH.ResumeLayout(false);
            this.skinPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGridViewH; 
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private SkinPanel skinPanel2;
        private FlowLayoutPanel panel1;
        private Panel panel2;
        private SkinLabel skinLabel1;
        private SkinComboBox skinComboBoxPageSize;
        private Panel panel3;
        private SkinLabel skinLabelTotalCount;
        private CJBasic.Widget.PageControlPanel2 pageControlPanel21;
        private SkinPanel skinPanel1;
        private ToolStripMenuItem 显示图片ToolStripMenuItem;
        private Panel panel4;
        private Panel panel5;
        private SummaryControlContainer summaryControlContainer2;
        private SummaryControlContainer summaryControlContainer1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private DataGridViewContextMenuStrip dataGridViewContextMenuStrip1;
        private ToolStripMenuItem 字段显示ToolStripMenuItem;
    }
}

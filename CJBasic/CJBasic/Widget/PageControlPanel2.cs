namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class PageControlPanel2 : UserControl
    {
        private IContainer components = null;
        private bool contextMenuEnglish = false;
        private int currentPageIndex = 0;
        private ToolStrip skinToolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripLabel toolStripLabel_title;
        private ToolStripLabel toolStripLabel_totalCount;
        private ToolStripTextBox toolStripTextBox_pageNumber;
        private int totalPageCount = 1;

        public event CbGeneric<int> CurrentPageIndexChanged;

        public PageControlPanel2()
        {
            this.InitializeComponent();
        }

        private void CheckPageText()
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new CbGeneric(this.CheckPageText));
            }
            else
            {
                this.toolStripLabel_totalCount.Text = string.Format("/ {0}", this.totalPageCount);
                this.toolStripTextBox_pageNumber.Text = (this.currentPageIndex + 1).ToString();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GotoPage(int pageIndex)
        {
            this.GotoPage(pageIndex, true);
        }

        public void GotoPage(int pageIndex, bool springEvent)
        {
            if (pageIndex != 0x7fffffff)
            {
                if ((pageIndex + 1) > this.totalPageCount)
                {
                    pageIndex = this.totalPageCount - 1;
                }
                if (pageIndex < 0)
                {
                    pageIndex = 0;
                }
                if (this.currentPageIndex == pageIndex)
                {
                    this.toolStripTextBox_pageNumber.Text = (pageIndex + 1).ToString();
                    return;
                }
            }
            this.Cursor = Cursors.WaitCursor;
            this.currentPageIndex = pageIndex;
            if (springEvent && (this.CurrentPageIndexChanged != null))
            {
                this.CurrentPageIndexChanged(this.currentPageIndex);
            }
            this.CheckPageText();
            this.Cursor = Cursors.Default;
        }

        public void Initialize(int pageCount)
        {
            this.totalPageCount = pageCount;
            this.currentPageIndex = 0;
            this.CheckPageText();
            this.ContextMenuEnglish = this.contextMenuEnglish;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PageControlPanel2));
            this.skinToolStrip1 = new ToolStrip();
            this.toolStripButton4 = new ToolStripButton();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripLabel_totalCount = new ToolStripLabel();
            this.toolStripTextBox_pageNumber = new ToolStripTextBox();
            this.toolStripLabel_title = new ToolStripLabel();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripButton1 = new ToolStripButton();
            this.skinToolStrip1.SuspendLayout();
            base.SuspendLayout();
            this.skinToolStrip1.BackColor = Color.Transparent;
            this.skinToolStrip1.Dock = DockStyle.Fill;
            this.skinToolStrip1.GripMargin = new Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.skinToolStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripButton4, this.toolStripButton3, this.toolStripLabel_totalCount, this.toolStripTextBox_pageNumber, this.toolStripLabel_title, this.toolStripButton2, this.toolStripButton1 });
            this.skinToolStrip1.Location = new Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.Size = new Size(0xdb, 0x19);
            this.skinToolStrip1.TabIndex = 0x90;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.toolStripButton4.Alignment = ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = (Image) manager.GetObject("toolStripButton4.Image");
            this.toolStripButton4.ImageTransparentColor = Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new Size(0x17, 0x16);
            this.toolStripButton4.Text = "末页";
            this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
            this.toolStripButton3.Alignment = ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = (Image) manager.GetObject("toolStripButton3.Image");
            this.toolStripButton3.ImageTransparentColor = Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(0x17, 0x16);
            this.toolStripButton3.Text = "下一页";
            this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
            this.toolStripLabel_totalCount.Alignment = ToolStripItemAlignment.Right;
            this.toolStripLabel_totalCount.Name = "toolStripLabel_totalCount";
            this.toolStripLabel_totalCount.Size = new Size(0x18, 0x16);
            this.toolStripLabel_totalCount.Text = "/ 1";
            this.toolStripTextBox_pageNumber.Alignment = ToolStripItemAlignment.Right;
            this.toolStripTextBox_pageNumber.Name = "toolStripTextBox_pageNumber";
            this.toolStripTextBox_pageNumber.Size = new Size(30, 0x19);
            this.toolStripTextBox_pageNumber.Text = "1";
            this.toolStripTextBox_pageNumber.KeyDown += new KeyEventHandler(this.toolStripTextBox_pageNumber_KeyDown);
            this.toolStripLabel_title.Alignment = ToolStripItemAlignment.Right;
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new Size(0x2c, 0x16);
            this.toolStripLabel_title.Text = "页码：";
            this.toolStripButton2.Alignment = ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = (Image) manager.GetObject("toolStripButton2.Image");
            this.toolStripButton2.ImageTransparentColor = Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(0x17, 0x16);
            this.toolStripButton2.Text = "上一页";
            this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
            this.toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = (Image) manager.GetObject("toolStripButton1.Image");
            this.toolStripButton1.ImageTransparentColor = Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(0x17, 0x16);
            this.toolStripButton1.Text = "首页";
            this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.skinToolStrip1);
            base.Name = "PageControlPanel2";
            base.Size = new Size(0xdb, 0x19);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void pageController_CurrentPageIndexChanged()
        {
            this.CheckPageText();
        }

        private void pageController_PageCountChanged()
        {
            this.CheckPageText();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.GotoPage(0);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.GotoPage(this.currentPageIndex - 1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.GotoPage(this.currentPageIndex + 1);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.GotoPage(this.totalPageCount - 1);
        }

        private void toolStripTextBox_pageNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int result = 1;
                    int.TryParse(this.toolStripTextBox_pageNumber.Text, out result);
                    this.GotoPage(result - 1);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        public bool ContextMenuEnglish
        {
            get
            {
                return this.contextMenuEnglish;
            }
            set
            {
                this.contextMenuEnglish = value;
                if (this.contextMenuEnglish)
                {
                    this.toolStripLabel_title.Text = "Page No：";
                    this.toolStripButton1.Text = "First Page";
                    this.toolStripButton2.Text = "Previous Page";
                    this.toolStripButton3.Text = "Next Page";
                    this.toolStripButton4.Text = "Last Page";
                }
                else
                {
                    this.toolStripLabel_title.Text = "页码：";
                    this.toolStripButton1.Text = "首页";
                    this.toolStripButton2.Text = "上一页";
                    this.toolStripButton3.Text = "下一页";
                    this.toolStripButton4.Text = "末页";
                }
            }
        }
    }
}


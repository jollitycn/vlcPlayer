namespace CJBasic.Widget
{
    using CJBasic.Helpers;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class TrayForm : Form
    {
        private IContainer components = null;
        private ContextMenuStrip contextMenuStrip1;
        private bool gotoClose = false;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private ToolStripMenuItem 退出ToolStripMenuItem;

        public TrayForm()
        {
            this.InitializeComponent();
            base.Load += new EventHandler(this.GuardForm_Load);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GuardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.gotoClose)
            {
                base.Visible = false;
                e.Cancel = true;
            }
            else
            {
                this.notifyIcon1.Visible = false;
            }
        }

        private void GuardForm_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Text = this.Text;
            this.notifyIcon1.Icon = base.Icon;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.退出ToolStripMenuItem = new ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.退出ToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x99, 0x30);
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new EventHandler(this.退出ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x144, 0x105);
            base.Name = "GuardForm";
            this.Text = "GuardForm";
            base.FormClosing += new FormClosingEventHandler(this.GuardForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.Visible = !base.Visible;
            if (base.Visible)
            {
                base.Focus();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowsHelper.ShowQuery(string.Format("您确定要退出{0}吗？", this.Text)))
            {
                this.gotoClose = true;
                base.Close();
            }
        }

        public System.Windows.Forms.NotifyIcon NotifyIcon
        {
            get
            {
                return this.notifyIcon1;
            }
        }

        public ContextMenuStrip NotifyMenuStrip
        {
            get
            {
                return this.contextMenuStrip1;
            }
        }
    }
}


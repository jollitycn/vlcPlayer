namespace CJBasic.Widget
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class ExListView : ListView
    {
        private ArrayList HeaderGroup = new ArrayList();
        private string m_GroupLabelText = "Group by :";
        private bool m_GroupsGUIs = false;
        private bool m_ShowGroupLabel = false;
        private Image m_ToolStripImage = null;
        private ToolStrip tsGroups;

        public ExListView()
        {
            this.InitializeComponent();
            this.Bind();
        }

        protected virtual void Bind()
        {
            if (this.m_GroupsGUIs)
            {
                if (!this.tsGroups.Visible)
                {
                    this.tsGroups.Visible = true;
                }
                this.tsGroups.Parent = base.Parent;
                this.tsGroups.Location = new Point(base.Location.X, base.Location.Y - 0x19);
                if (this.tsGroups.Width != base.Width)
                {
                    this.tsGroups.Width = base.Width;
                }
            }
            else if (this.tsGroups.Visible)
            {
                this.tsGroups.Visible = false;
            }
        }

        private void CreateButtons()
        {
            this.tsGroups.Items.Clear();
            if (this.m_ShowGroupLabel)
            {
                ToolStripLabel label = new ToolStripLabel(this.m_GroupLabelText);
                this.tsGroups.Items.Add(label);
            }
            foreach (ColumnHeader header in base.Columns)
            {
                ToolStripButton button = new ToolStripButton(header.Text, this.m_ToolStripImage);
                button.Click += new EventHandler(this.tsb_Click);
                button.Tag = header;
                this.tsGroups.Items.Add(button);
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.tsGroups.Dispose();
            base.Dispose(disposing);
        }

        public virtual void GroupBy()
        {
            this.GroupBy((ColumnHeader[]) this.HeaderGroup.ToArray(typeof(ColumnHeader)));
        }

        public void GroupBy(ColumnHeader[] Headers)
        {
            if (base.InvokeRequired)
            {
                dGroupBy method = new dGroupBy(this.GroupBy);
                base.Invoke(method, new object[] { Headers });
            }
            else
            {
                foreach (ListViewItem item in base.Items)
                {
                    string str = "";
                    foreach (ColumnHeader header in Headers)
                    {
                        str = str + " " + item.SubItems[header.Index].Text;
                    }
                    ListViewGroup group = new ListViewGroup(str);
                    ListViewGroup group2 = null;
                    foreach (ListViewGroup group3 in base.Groups)
                    {
                        if (group3.Header == group.Header)
                        {
                            group2 = group3;
                            break;
                        }
                    }
                    if (group2 == null)
                    {
                        base.Groups.Add(group);
                        group.Items.Add(item);
                    }
                    else
                    {
                        group2.Items.Add(item);
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.tsGroups = new ToolStrip();
            base.SuspendLayout();
            this.tsGroups.AutoSize = false;
            this.tsGroups.Dock = DockStyle.None;
            this.tsGroups.Location = new Point(0, 0);
            this.tsGroups.Name = "tsGroups";
            this.tsGroups.Size = new Size(100, 0x19);
            this.tsGroups.TabIndex = 0;
            this.tsGroups.Text = "toolStrip1";
            base.ResumeLayout(false);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Bind();
            this.CreateButtons();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            this.Bind();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Bind();
        }

        private void tsb_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton) sender;
            button.Checked = !button.Checked;
            if (button.Checked)
            {
                this.HeaderGroup.Add((ColumnHeader) button.Tag);
            }
            else
            {
                this.HeaderGroup.Remove((ColumnHeader) button.Tag);
            }
            Thread thread = new Thread(new ThreadStart(this.GroupBy));
            thread.IsBackground = true;
            thread.Start();
        }

        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
                if ((value == DockStyle.Fill) || (value == DockStyle.Top))
                {
                    this.tsGroups.Dock = DockStyle.Top;
                }
                else
                {
                    this.tsGroups.Dock = DockStyle.None;
                }
            }
        }

        [Description("The 'ShowGroup' label. (DEFAULT : 'Group by:'"), Category("Groups")]
        public string GroupLabelText
        {
            get
            {
                return this.m_GroupLabelText;
            }
            set
            {
                this.m_GroupLabelText = value;
            }
        }

        [Category("Groups"), Description("Show or not the ToolStrip to allow group items.")]
        public bool GroupsGUIs
        {
            get
            {
                return this.m_GroupsGUIs;
            }
            set
            {
                this.m_GroupsGUIs = value;
                this.Bind();
            }
        }

        [Description("Show or hide the 'ShowGroup' label."), Category("Groups")]
        public bool ShowGroupLabel
        {
            get
            {
                return this.m_ShowGroupLabel;
            }
            set
            {
                this.m_ShowGroupLabel = value;
                this.CreateButtons();
            }
        }

        [Category("Groups"), Description("The image to show on ToolStripButtons of the groups")]
        public Image ToolStripImage
        {
            get
            {
                return this.m_ToolStripImage;
            }
            set
            {
                this.m_ToolStripImage = value;
                this.CreateButtons();
            }
        }

        private delegate void dGroupBy(ColumnHeader[] Headers);
    }
}


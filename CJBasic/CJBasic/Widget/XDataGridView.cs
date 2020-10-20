namespace CJBasic.Widget
{
    using CJBasic;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class XDataGridView : DataGridView
    {
        private IContainer components = null;
        private int selectedRowIndex = -1;
        private ContextMenuStrip xcontextMenuStrip;
        private ContextMenuStrip xcontextMenuStrip4Blank;

        public event CbGeneric<object> BeforeShowContextMenu;

        public event CbGeneric<object> ItemDoubleClicked;

        public XDataGridView()
        {
            base.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            base.BackgroundColor = Color.White;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            base.MultiSelect = false;
            base.ReadOnly = true;
            base.AllowUserToAddRows = false;
            base.AllowUserToDeleteRows = false;
            base.RowHeadersVisible = false;
            base.RowTemplate.Height = 0x17;
            base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            base.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            base.MouseDown += new MouseEventHandler(this.dataGridView1_MouseDown);
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            base.ColumnHeadersHeight = 30;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IList dataSource = (IList) base.DataSource;
            if ((((dataSource != null) && (e.RowIndex >= 0)) && (e.RowIndex < dataSource.Count)) && (this.ItemDoubleClicked != null))
            {
                this.ItemDoubleClicked(dataSource[e.RowIndex]);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = base.HitTest(e.X, e.Y);
            this.selectedRowIndex = info.RowIndex;
            if (this.selectedRowIndex >= 0)
            {
                base.Rows[this.selectedRowIndex].Selected = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (this.BeforeShowContextMenu != null)
                {
                    if (info.RowIndex >= 0)
                    {
                        IList dataSource = (IList) base.DataSource;
                        this.BeforeShowContextMenu(dataSource[this.selectedRowIndex]);
                    }
                    else
                    {
                        this.BeforeShowContextMenu(null);
                    }
                }
                this.ContextMenuStrip = (info.RowIndex < 0) ? this.xcontextMenuStrip4Blank : this.xcontextMenuStrip;
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

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        public object SelectedItem
        {
            get
            {
                IList dataSource = (IList) base.DataSource;
                if ((dataSource == null) || (this.selectedRowIndex < 0))
                {
                    return null;
                }
                if (this.selectedRowIndex >= dataSource.Count)
                {
                    return null;
                }
                return dataSource[this.selectedRowIndex];
            }
        }

        public int SelectedRowIndex
        {
            get
            {
                return this.selectedRowIndex;
            }
            set
            {
                IList dataSource = (IList) base.DataSource;
                if (dataSource != null)
                {
                    if (value >= dataSource.Count)
                    {
                        value = dataSource.Count - 1;
                    }
                    this.selectedRowIndex = value;
                    if (this.selectedRowIndex >= 0)
                    {
                        base.Rows[this.selectedRowIndex].Selected = true;
                    }
                    else
                    {
                        for (int i = 0; i < dataSource.Count; i++)
                        {
                            base.Rows[i].Selected = false;
                        }
                    }
                }
            }
        }

        public ContextMenuStrip XContextMenuStrip
        {
            get
            {
                return this.xcontextMenuStrip;
            }
            set
            {
                this.xcontextMenuStrip = value;
            }
        }

        public ContextMenuStrip XcontextMenuStrip4Blank
        {
            get
            {
                return this.xcontextMenuStrip4Blank;
            }
            set
            {
                this.xcontextMenuStrip4Blank = value;
            }
        }
    }
}


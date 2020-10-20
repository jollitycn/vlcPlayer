namespace CJBasic.Widget
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class DataMergedView : DataGridView
    {
        private Color _mergecolumnheaderbackcolor = SystemColors.Control;
        private List<string> _mergecolumnname = new List<string>();
        private IContainer components = null;
        private Dictionary<int, SpanInfo> SpanRows = new Dictionary<int, SpanInfo>();
        private Timer timer1;

        public DataMergedView()
        {
            this.InitializeComponent();
        }

        public void AddSpanHeader(int ColIndex, int ColCount, string Text)
        {
            if (ColCount < 2)
            {
                throw new Exception("行宽应大于等于2，合并1列无意义。");
            }
            int right = (ColIndex + ColCount) - 1;
            this.SpanRows[ColIndex] = new SpanInfo(Text, 1, ColIndex, right);
            this.SpanRows[right] = new SpanInfo(Text, 3, ColIndex, right);
            for (int i = ColIndex + 1; i < right; i++)
            {
                this.SpanRows[i] = new SpanInfo(Text, 2, ColIndex, right);
            }
        }

        public void ClearSpanInfo()
        {
            this.SpanRows.Clear();
        }

        private void DataGridViewEx_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                this.timer1.Enabled = false;
                this.timer1.Enabled = true;
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

        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Brush brush = new SolidBrush(base.GridColor);
            SolidBrush brush2 = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush brush3 = new SolidBrush(e.CellStyle.ForeColor);
            int upRows = 0;
            int downRows = 0;
            int count = 0;
            if (this.MergeColumnNames.Contains(base.Columns[e.ColumnIndex].Name) && (e.RowIndex != -1))
            {
                int width = e.CellBounds.Width;
                Pen pen = new Pen(brush);
                string str = (e.Value == null) ? "" : e.Value.ToString().Trim();
                string str2 = (base.CurrentRow.Cells[e.ColumnIndex].Value == null) ? "" : base.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim();
                if (!string.IsNullOrEmpty(str))
                {
                    int num5;
                    for (num5 = e.RowIndex; num5 < base.Rows.Count; num5++)
                    {
                        if (!base.Rows[num5].Cells[e.ColumnIndex].Value.ToString().Equals(str))
                        {
                            break;
                        }
                        downRows++;
                        if (e.RowIndex != num5)
                        {
                            width = (width < base.Rows[num5].Cells[e.ColumnIndex].Size.Width) ? width : base.Rows[num5].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    for (num5 = e.RowIndex; num5 >= 0; num5--)
                    {
                        if (!base.Rows[num5].Cells[e.ColumnIndex].Value.ToString().Equals(str))
                        {
                            break;
                        }
                        upRows++;
                        if (e.RowIndex != num5)
                        {
                            width = (width < base.Rows[num5].Cells[e.ColumnIndex].Size.Width) ? width : base.Rows[num5].Cells[e.ColumnIndex].Size.Width;
                        }
                    }
                    count = (downRows + upRows) - 1;
                    if (count < 2)
                    {
                        return;
                    }
                }
                if (base.Rows[e.RowIndex].Selected)
                {
                    brush2.Color = e.CellStyle.SelectionBackColor;
                    brush3.Color = e.CellStyle.SelectionForeColor;
                }
                e.Graphics.FillRectangle(brush2, e.CellBounds);
                this.PaintingFont(e, width, upRows, downRows, count);
                if (downRows == 1)
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    count = 0;
                }
                e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize) this).BeginInit();
            base.SuspendLayout();
            this.timer1.Interval = 20;
            base.RowTemplate.Height = 0x17;
            ((ISupportInitialize) this).EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
                {
                    this.DrawCell(e);
                }
                else if ((e.RowIndex == -1) && this.SpanRows.ContainsKey(e.ColumnIndex))
                {
                    Graphics graphics = e.Graphics;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.Background);
                    int left = e.CellBounds.Left;
                    int y = e.CellBounds.Top + 2;
                    int right = e.CellBounds.Right;
                    int bottom = e.CellBounds.Bottom;
                    switch (this.SpanRows[e.ColumnIndex].Position)
                    {
                        case 1:
                            left += 2;
                            break;

                        case 3:
                            right -= 2;
                            break;
                    }
                    graphics.FillRectangle(new SolidBrush(this._mergecolumnheaderbackcolor), left, y, right - left, (bottom - y) / 2);
                    graphics.DrawLine(new Pen(base.GridColor), left, (y + bottom) / 2, right, (y + bottom) / 2);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                  //  graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Black, new Rectangle(left, (y + bottom) / 2, right - left, (bottom - y) / 2), format);
                    left = base.GetColumnDisplayRectangle(this.SpanRows[e.ColumnIndex].Left, true).Left - 2;
                    if (left < 0)
                    {
                        left = base.GetCellDisplayRectangle(-1, -1, true).Width;
                    }
                    right = base.GetColumnDisplayRectangle(this.SpanRows[e.ColumnIndex].Right, true).Right - 2;
                    if (right < 0)
                    {
                        right = base.Width;
                    }
                    graphics.DrawString(this.SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black, new Rectangle(left, y, right - left, (bottom - y) / 2), format);
                    e.Handled = true;
                }
                base.OnCellPainting(e);
            }
            catch
            {
            }
        }

        private void PaintingFont(DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
        {
            SolidBrush brush = new SolidBrush(e.CellStyle.ForeColor);
            int height = (int) e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            int width = (int) e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            int num3 = e.CellBounds.Height;
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) (e.CellBounds.X + ((cellwidth - width) / 2)), (float) ((e.CellBounds.Y + (num3 * DownRows)) - height));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) e.CellBounds.X, (float) ((e.CellBounds.Y + (num3 * DownRows)) - height));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) ((e.CellBounds.X + cellwidth) - width), (float) ((e.CellBounds.Y + (num3 * DownRows)) - height));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) (e.CellBounds.X + ((cellwidth - width) / 2)), (float) ((e.CellBounds.Y - (num3 * (UpRows - 1))) + (((num3 * count) - height) / 2)));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) e.CellBounds.X, (float) ((e.CellBounds.Y - (num3 * (UpRows - 1))) + (((num3 * count) - height) / 2)));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) ((e.CellBounds.X + cellwidth) - width), (float) ((e.CellBounds.Y - (num3 * (UpRows - 1))) + (((num3 * count) - height) / 2)));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) (e.CellBounds.X + ((cellwidth - width) / 2)), (float) (e.CellBounds.Y - (num3 * (UpRows - 1))));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) e.CellBounds.X, (float) (e.CellBounds.Y - (num3 * (UpRows - 1))));
            }
            else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) ((e.CellBounds.X + cellwidth) - width), (float) (e.CellBounds.Y - (num3 * (UpRows - 1))));
            }
            else
            {
                e.Graphics.DrawString((string) e.Value, e.CellStyle.Font, brush, (float) (e.CellBounds.X + ((cellwidth - width) / 2)), (float) ((e.CellBounds.Y - (num3 * (UpRows - 1))) + (((num3 * count) - height) / 2)));
            }
        }

        public void ReDrawHead()
        {
            foreach (int num in this.SpanRows.Keys)
            {
                base.Invalidate(base.GetCellDisplayRectangle(num, -1, true));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.ReDrawHead();
        }

        [Category("二维表头"), Description("二维表头的背景颜色"), Browsable(true)]
        public Color MergeColumnHeaderBackColor
        {
            get
            {
                return this._mergecolumnheaderbackcolor;
            }
            set
            {
                this._mergecolumnheaderbackcolor = value;
            }
        }

        [Localizable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), Description("设置或获取合并列的集合"), Category("单元格合并"), MergableProperty(false), Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public List<string> MergeColumnNames
        {
            get
            {
                return this._mergecolumnname;
            }
            set
            {
                this._mergecolumnname = value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SpanInfo
        {
            public string Text;
            public int Position;
            public int Left;
            public int Right;
            public SpanInfo(string Text, int Position, int Left, int Right)
            {
                this.Text = Text;
                this.Position = Position;
                this.Left = Left;
                this.Right = Right;
            }
        }
    }
}


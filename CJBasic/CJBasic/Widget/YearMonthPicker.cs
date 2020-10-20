namespace CJBasic.Widget
{
    using CJBasic.Helpers;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class YearMonthPicker : DateTimePicker
    {
        private IContainer components = null;

        public YearMonthPicker()
        {
            this.InitializeComponent();
            base.Format = DateTimePickerFormat.Custom;
            base.CustomFormat = "yyyy-MM";
            base.ShowUpDown = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Point GetPoint()
        {
            Point point = base.Parent.PointToScreen(base.Location);
            return new Point((point.X + base.Width) - 30, point.Y + 10);
        }

        public void Initialize()
        {
            Point mousePosition = Control.MousePosition;
            Point point2 = base.Parent.PointToScreen(base.Location);
            Point point3 = new Point((point2.X + base.Width) - 30, point2.Y + 10);
            WindowsHelper.SetCursorPos(point3.X, point3.Y);
            WindowsHelper.MouseEvent(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            WindowsHelper.MouseEvent(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            WindowsHelper.SetCursorPos(mousePosition.X, mousePosition.Y);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.Size = new Size(0xad, 0x15);
            base.ResumeLayout(false);
        }
    }
}


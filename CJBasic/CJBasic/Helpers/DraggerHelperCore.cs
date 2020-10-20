namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal sealed class DraggerHelperCore
    {
        private const int Band = 5;
        private Dictionary<Control, DragControlProperty> controlPropertyDic = new Dictionary<Control, DragControlProperty>();
        private EnumMousePointPosition m_MousePointPosition;
        private const int MinHeight = 10;
        private const int MinWidth = 10;

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            DragControlProperty controlProperty = this.GetControlProperty(sender as Control);
            controlProperty.PositionMovePoint = e.Location;
            controlProperty.SizeChangeMovePoint = e.Location;
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            this.m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            Cursor.Current = Cursors.Arrow;
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            DragControlProperty controlProperty = this.GetControlProperty(control);
            if (e.Button != MouseButtons.Left)
            {
                this.m_MousePointPosition = this.MousePointPosition(control.Size, e);
                switch (this.m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        Cursor.Current = Cursors.Arrow;
                        break;

                    case EnumMousePointPosition.MouseSizeRight:
                        Cursor.Current = Cursors.SizeWE;
                        break;

                    case EnumMousePointPosition.MouseSizeLeft:
                        Cursor.Current = Cursors.SizeWE;
                        break;

                    case EnumMousePointPosition.MouseSizeBottom:
                        Cursor.Current = Cursors.SizeNS;
                        break;

                    case EnumMousePointPosition.MouseSizeTop:
                        Cursor.Current = Cursors.SizeNS;
                        break;

                    case EnumMousePointPosition.MouseSizeTopLeft:
                        Cursor.Current = Cursors.SizeNWSE;
                        break;

                    case EnumMousePointPosition.MouseSizeTopRight:
                        Cursor.Current = Cursors.SizeNESW;
                        break;

                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        Cursor.Current = Cursors.SizeNESW;
                        break;

                    case EnumMousePointPosition.MouseSizeBottomRight:
                        Cursor.Current = Cursors.SizeNWSE;
                        break;

                    case EnumMousePointPosition.MouseDrag:
                        Cursor.Current = Cursors.SizeAll;
                        break;
                }
            }
            else
            {
                switch (this.m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseSizeRight:
                        control.Width = (control.Width + e.X) - controlProperty.SizeChangeMovePoint.X;
                        controlProperty.SizeChangeMovePoint = e.Location;
                        break;

                    case EnumMousePointPosition.MouseSizeLeft:
                        control.Left = (control.Left + e.X) - controlProperty.PositionMovePoint.X;
                        control.Width -= e.X - controlProperty.PositionMovePoint.X;
                        break;

                    case EnumMousePointPosition.MouseSizeBottom:
                        control.Height = (control.Height + e.Y) - controlProperty.SizeChangeMovePoint.Y;
                        controlProperty.SizeChangeMovePoint = e.Location;
                        break;

                    case EnumMousePointPosition.MouseSizeTop:
                        control.Top += e.Y - controlProperty.PositionMovePoint.Y;
                        control.Height -= e.Y - controlProperty.PositionMovePoint.Y;
                        break;

                    case EnumMousePointPosition.MouseSizeTopLeft:
                        control.Left = (control.Left + e.X) - controlProperty.PositionMovePoint.X;
                        control.Top += e.Y - controlProperty.PositionMovePoint.Y;
                        control.Width -= e.X - controlProperty.PositionMovePoint.X;
                        control.Height -= e.Y - controlProperty.PositionMovePoint.Y;
                        break;

                    case EnumMousePointPosition.MouseSizeTopRight:
                        control.Top += e.Y - controlProperty.PositionMovePoint.Y;
                        control.Width += e.X - controlProperty.SizeChangeMovePoint.X;
                        control.Height -= e.Y - controlProperty.PositionMovePoint.Y;
                        controlProperty.SizeChangeMovePoint = e.Location;
                        break;

                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        control.Left = (control.Left + e.X) - controlProperty.PositionMovePoint.X;
                        control.Width -= e.X - controlProperty.PositionMovePoint.X;
                        control.Height = (control.Height + e.Y) - controlProperty.SizeChangeMovePoint.Y;
                        controlProperty.SizeChangeMovePoint = e.Location;
                        break;

                    case EnumMousePointPosition.MouseSizeBottomRight:
                        control.Width = (control.Width + e.X) - controlProperty.SizeChangeMovePoint.X;
                        control.Height = (control.Height + e.Y) - controlProperty.SizeChangeMovePoint.Y;
                        controlProperty.SizeChangeMovePoint = e.Location;
                        break;

                    case EnumMousePointPosition.MouseDrag:
                        control.Left = (control.Left + e.X) - controlProperty.PositionMovePoint.X;
                        control.Top = (control.Top + e.Y) - controlProperty.PositionMovePoint.Y;
                        break;
                }
                if (control.Width < 10)
                {
                    control.Width = 10;
                }
                if (control.Height < 10)
                {
                    control.Height = 10;
                }
            }
        }

        public void DisableDrag(Control control)
        {
            if (this.controlPropertyDic.ContainsKey(control))
            {
                control.MouseDown -= new MouseEventHandler(this.control_MouseDown);
                control.MouseMove -= new MouseEventHandler(this.control_MouseMove);
                control.MouseLeave -= new EventHandler(this.control_MouseLeave);
                this.controlPropertyDic.Remove(control);
            }
        }

        public void EnableDrag(Control control)
        {
            if (!this.controlPropertyDic.ContainsKey(control))
            {
                this.controlPropertyDic.Add(control, new DragControlProperty());
                this.RegisterControlEvents(control);
            }
        }

        private DragControlProperty GetControlProperty(Control control)
        {
            return this.controlPropertyDic[control];
        }

        public bool IsControlCanDrag(Control control)
        {
            return this.controlPropertyDic.ContainsKey(control);
        }

        private EnumMousePointPosition MousePointPosition(Size size, MouseEventArgs e)
        {
            if ((((e.X >= -5) | (e.X <= size.Width)) | (e.Y >= -5)) | (e.Y <= size.Height))
            {
                if (e.X < 5)
                {
                    if (e.Y < 5)
                    {
                        return EnumMousePointPosition.MouseSizeTopLeft;
                    }
                    if (e.Y > (-5 + size.Height))
                    {
                        return EnumMousePointPosition.MouseSizeBottomLeft;
                    }
                    return EnumMousePointPosition.MouseSizeLeft;
                }
                if (e.X > (-5 + size.Width))
                {
                    if (e.Y < 5)
                    {
                        return EnumMousePointPosition.MouseSizeTopRight;
                    }
                    if (e.Y > (-5 + size.Height))
                    {
                        return EnumMousePointPosition.MouseSizeBottomRight;
                    }
                    return EnumMousePointPosition.MouseSizeRight;
                }
                if (e.Y < 5)
                {
                    return EnumMousePointPosition.MouseSizeTop;
                }
                if (e.Y > (-5 + size.Height))
                {
                    return EnumMousePointPosition.MouseSizeBottom;
                }
                return EnumMousePointPosition.MouseDrag;
            }
            return EnumMousePointPosition.MouseSizeNone;
        }

        private void RegisterControlEvents(Control control)
        {
            control.MouseDown += new MouseEventHandler(this.control_MouseDown);
            control.MouseMove += new MouseEventHandler(this.control_MouseMove);
            control.MouseLeave += new EventHandler(this.control_MouseLeave);
        }

        internal class DragControlProperty
        {

            public Point PositionMovePoint
            {
                get;set;
            }

            public Point SizeChangeMovePoint
            {
                get;set;
            }
        }

        private enum EnumMousePointPosition
        {
            MouseSizeNone,
            MouseSizeRight,
            MouseSizeLeft,
            MouseSizeBottom,
            MouseSizeTop,
            MouseSizeTopLeft,
            MouseSizeTopRight,
            MouseSizeBottomLeft,
            MouseSizeBottomRight,
            MouseDrag
        }
    }
}


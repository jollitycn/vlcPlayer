namespace CJBasic.Geometry
{
    using System;
    using System.Drawing;

    public class LineSegment
    {
        private Point pt1;
        private Point pt2;

        public LineSegment(Point p1, Point p2)
        {
            this.pt1 = p1;
            this.pt2 = p2;
        }

        public bool Contains(Point pt)
        {
            if (!pt.Equals(this.pt1) && !pt.Equals(this.pt2))
            {
                float num = (this.pt2.Y - this.pt1.Y) * (pt.X - this.pt1.X);
                float num2 = (pt.Y - this.pt1.Y) * (this.pt2.X - this.pt1.X);
                if (Math.Abs((float) (num - num2)) < 1E-05f)
                {
                    return false;
                }
                if (!GeometryHelper.IsInRegion((float) pt.X, (float) this.pt1.X, (float) this.pt2.X))
                {
                    return false;
                }
                if (!GeometryHelper.IsInRegion((float) pt.Y, (float) this.pt1.Y, (float) this.pt2.Y))
                {
                    return false;
                }
            }
            return true;
        }

        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.pt1, this.pt2);
        }

        public void Draw(Graphics g, Pen pen, SolidBrush brushNode, Font fontText)
        {
            g.DrawLine(pen, this.pt1, this.pt2);
            string s = string.Format("({0},{1})", this.pt1.X, this.pt1.Y);
            string str2 = string.Format("({0},{1})", this.pt2.X, this.pt2.Y);
            g.DrawString(s, fontText, brushNode, (PointF) this.pt1);
            g.DrawString(str2, fontText, brushNode, (PointF) this.pt2);
        }

        public float GetIntersectWithHorAxis()
        {
            if (this.pt1.X != this.pt2.X)
            {
                int num = (this.DeltX * -1) * this.pt1.Y;
                int x = (num / this.DeltY) + this.pt1.X;
                if (this.Contains(new Point(x, 0)))
                {
                    return (float) x;
                }
            }
            return float.MaxValue;
        }

        public float GetIntersectWithVerAxis()
        {
            if (this.pt1.Y != this.pt2.Y)
            {
                int num = (this.DeltY * -1) * this.pt1.X;
                int y = (num / this.DeltX) + this.pt1.Y;
                if (this.Contains(new Point(0, y)))
                {
                    return (float) y;
                }
            }
            return float.MaxValue;
        }

        public int DeltX
        {
            get
            {
                return (this.pt2.X - this.pt1.X);
            }
        }

        public int DeltY
        {
            get
            {
                return (this.pt2.Y - this.pt1.Y);
            }
        }

        public Point FirstPoint
        {
            get
            {
                return this.pt1;
            }
        }

        public Point SecondPoint
        {
            get
            {
                return this.pt2;
            }
        }
    }
}


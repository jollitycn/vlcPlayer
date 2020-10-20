namespace CJBasic.Geometry
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class GeometryHelper
    {
        public const float ToleranceForFloat = 1E-05f;

        public static Rectangle ComputeBounds(Point[] points)
        {
            int x = points[0].X;
            int y = points[0].Y;
            int num3 = points[0].X;
            int num4 = points[0].Y;
            foreach (Point point in points)
            {
                if (point.X < x)
                {
                    x = point.X;
                }
                if (point.X > num3)
                {
                    num3 = point.X;
                }
                if (point.Y < y)
                {
                    y = point.Y;
                }
                if (point.Y > num4)
                {
                    num4 = point.Y;
                }
            }
            return new Rectangle(x, y, num3 - x, num4 - y);
        }

        public static float ComputeLineLength(Point pt1, Point pt2)
        {
            return (float) Math.Sqrt((double) (((pt2.X - pt1.X) * (pt2.X - pt1.X)) + ((pt2.Y - pt1.Y) * (pt2.Y - pt1.Y))));
        }

        public static Rectangle CreateRectangle(Point pt1, Point pt2)
        {
            int x = pt1.X;
            int num2 = pt1.X;
            if (pt2.X < x)
            {
                x = pt2.X;
            }
            else
            {
                num2 = pt2.X;
            }
            int y = pt1.Y;
            int num4 = pt1.Y;
            if (pt2.Y < y)
            {
                y = pt2.Y;
            }
            else
            {
                num4 = pt2.Y;
            }
            Point location = new Point(x, y);
            Size size = new Size(num2 - x, num4 - y);
            Rectangle rectangle = new Rectangle(location, size);
            int num5 = rectangle.Height * rectangle.Width;
            return rectangle;
        }

        public static Rectangle CreateSquare(Point fixedPt, Point pt2)
        {
            int x = fixedPt.X;
            int num2 = fixedPt.X;
            if (pt2.X < x)
            {
                x = pt2.X;
            }
            else
            {
                num2 = pt2.X;
            }
            int y = fixedPt.Y;
            int num4 = fixedPt.Y;
            if (pt2.Y < y)
            {
                y = pt2.Y;
            }
            else
            {
                num4 = pt2.Y;
            }
            Size size = new Size(num2 - x, num4 - y);
            int num5 = (size.Width > size.Height) ? size.Height : size.Width;
            int num6 = (pt2.X > fixedPt.X) ? 1 : -1;
            int num7 = (pt2.Y > fixedPt.Y) ? 1 : -1;
            return CreateRectangle(fixedPt, new Point(fixedPt.X + (num6 * num5), fixedPt.Y + (num7 * num5)));
        }

        public static Point GetAdjacentPoint(Point current, CompassDirections direction)
        {
            switch (direction)
            {
                case CompassDirections.North:
                    return new Point(current.X, current.Y - 1);

                case CompassDirections.NorthEast:
                    return new Point(current.X + 1, current.Y - 1);

                case CompassDirections.East:
                    return new Point(current.X + 1, current.Y);

                case CompassDirections.SouthEast:
                    return new Point(current.X + 1, current.Y + 1);

                case CompassDirections.South:
                    return new Point(current.X, current.Y + 1);

                case CompassDirections.SouthWest:
                    return new Point(current.X - 1, current.Y + 1);

                case CompassDirections.West:
                    return new Point(current.X - 1, current.Y);

                case CompassDirections.NorthWest:
                    return new Point(current.X - 1, current.Y - 1);
            }
            return current;
        }

        public static CompassDirections GetDirectionBetween(Point origin, Point dest, int torrence)
        {
            int num = dest.X - origin.X;
            int num2 = dest.Y - origin.Y;
            if ((num > torrence) && (num2 < -torrence))
            {
                return CompassDirections.NorthEast;
            }
            if ((num > torrence) && (num2 > torrence))
            {
                return CompassDirections.SouthEast;
            }
            if ((num < -torrence) && (num2 < -torrence))
            {
                return CompassDirections.NorthWest;
            }
            if ((num < -torrence) && (num2 > torrence))
            {
                return CompassDirections.SouthWest;
            }
            if ((Math.Abs(num) < torrence) && (num2 < -torrence))
            {
                return CompassDirections.North;
            }
            if ((Math.Abs(num) < torrence) && (num2 > torrence))
            {
                return CompassDirections.South;
            }
            if ((num > torrence) && (Math.Abs(num2) < torrence))
            {
                return CompassDirections.East;
            }
            if ((num < -torrence) && (Math.Abs(num2) < torrence))
            {
                return CompassDirections.West;
            }
            return CompassDirections.NotSet;
        }

        public static int GetDistanceSquare(Point pt1, Point pt2)
        {
            int num = pt1.X - pt2.X;
            int num2 = pt1.Y - pt2.Y;
            return ((num * num) + (num2 * num2));
        }

        public static bool IsInRegion(float target, float f1, float f2)
        {
            if ((target > f1) && (target > f2))
            {
                return false;
            }
            if ((target < f1) && (target < f2))
            {
                return false;
            }
            return true;
        }

        public static bool IsTriangle(IList<Point> ptList)
        {
            Point point = ptList[0];
            Point point2 = ptList[1];
            Point point3 = ptList[2];
            if ((point.Equals(point2) || point.Equals(point3)) || point2.Equals(point3))
            {
                return false;
            }
            float num = (float) Math.Sqrt((double) (((point.X - point2.X) * (point.X - point2.X)) + ((point.Y - point2.Y) * (point.Y - point2.Y))));
            float num2 = (float) Math.Sqrt((double) (((point.X - point3.X) * (point.X - point3.X)) + ((point.Y - point3.Y) * (point.Y - point3.Y))));
            float num3 = (float) Math.Sqrt((double) (((point3.X - point2.X) * (point3.X - point2.X)) + ((point3.Y - point2.Y) * (point3.Y - point2.Y))));
            bool flag = (num + num2) <= num3;
            bool flag2 = (num + num3) <= num2;
            bool flag3 = (num2 + num3) <= num;
            if ((flag || flag2) || flag3)
            {
                return false;
            }
            return true;
        }

        public static Point MultiplePoint(Point origin, float coef)
        {
            return new Point((int) (origin.X * coef), (int) (origin.Y * coef));
        }

        public static Rectangle MultipleRectangle(Rectangle origin, float coef)
        {
            return new Rectangle(MultiplePoint(origin.Location, coef), MultipleSize(origin.Size, coef));
        }

        public static Size MultipleSize(Size origin, float coef)
        {
            return new Size((int) (origin.Width * coef), (int) (origin.Height * coef));
        }
    }
}


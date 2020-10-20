namespace CJBasic.Geometry
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Triangle
    {
        private List<float> lengthList;
        private float myArea;
        private IList<Point> vertextList;

        public Triangle(IList<Point> ptList)
        {
            this.vertextList = null;
            this.lengthList = null;
            this.myArea = 0f;
            this.vertextList = ptList;
            this.FillLengthList();
        }

        public Triangle(Point pt0, Point pt1, Point pt2)
        {
            this.vertextList = null;
            this.lengthList = null;
            this.myArea = 0f;
            List<Point> list = new List<Point>();
            list.Add(pt0);
            list.Add(pt1);
            list.Add(pt2);
            this.vertextList = list;
            this.FillLengthList();
        }

        public bool Contains(Point pt)
        {
            Triangle triangle = new Triangle(pt, this.vertextList[0], this.vertextList[1]);
            Triangle triangle2 = new Triangle(pt, this.vertextList[0], this.vertextList[2]);
            Triangle triangle3 = new Triangle(pt, this.vertextList[1], this.vertextList[2]);
            return (this.Area > (((triangle.Area + triangle2.Area) + triangle3.Area) - 1f));
        }

        private void FillLengthList()
        {
            Point point = this.vertextList[0];
            Point point2 = this.vertextList[1];
            Point point3 = this.vertextList[2];
            float item = (float) Math.Sqrt((double) (((point.X - point2.X) * (point.X - point2.X)) + ((point.Y - point2.Y) * (point.Y - point2.Y))));
            float num2 = (float) Math.Sqrt((double) (((point.X - point3.X) * (point.X - point3.X)) + ((point.Y - point3.Y) * (point.Y - point3.Y))));
            float num3 = (float) Math.Sqrt((double) (((point3.X - point2.X) * (point3.X - point2.X)) + ((point3.Y - point2.Y) * (point3.Y - point2.Y))));
            this.lengthList = new List<float>();
            this.lengthList.Add(num3);
            this.lengthList.Add(num2);
            this.lengthList.Add(item);
        }

        private float GetArea()
        {
            float num = this.lengthList[0];
            float num2 = this.lengthList[1];
            float num3 = this.lengthList[2];
            float num4 = ((num + num2) + num3) * 0.5f;
            return (float) Math.Sqrt((double) (((num4 * (num4 - num)) * (num4 - num2)) * (num4 - num3)));
        }

        public float GetEdgeLength(int index)
        {
            if ((index < 0) || (index > 2))
            {
                return 0f;
            }
            return this.lengthList[index];
        }

        public float Area
        {
            get
            {
                if (this.myArea == 0f)
                {
                    this.myArea = this.GetArea();
                }
                return this.myArea;
            }
        }
    }
}


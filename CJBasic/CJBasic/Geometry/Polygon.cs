namespace CJBasic.Geometry
{
    using System;
    using System.Collections;
    using System.Drawing;

    public class Polygon
    {
        private Point[] theVertex;

        public Polygon(Point[] vertex)
        {
            this.theVertex = vertex;
            if ((this.theVertex == null) || (this.theVertex.Length < 3))
            {
                throw new ArgumentException("The vertex count is not right !");
            }
        }

        public Polygon(ArrayList ptList)
        {
            if ((ptList == null) || (ptList.Count < 3))
            {
                throw new ArgumentException("The vertex count is not right !");
            }
            this.theVertex = new Point[ptList.Count];
            ptList.CopyTo(this.theVertex);
        }

        public bool Contains(Point target)
        {
            if (!this.IsOnEdge(target))
            {
                Polygon polygon = this.Offset(target.X, target.Y);
                ArrayList list = new ArrayList();
                ArrayList list2 = new ArrayList();
                ArrayList list3 = new ArrayList();
                ArrayList list4 = new ArrayList();
                for (int i = 0; i < this.theVertex.Length; i++)
                {
                    LineSegment edge = polygon.GetEdge(i);
                    float intersectWithHorAxis = edge.GetIntersectWithHorAxis();
                    float intersectWithVerAxis = edge.GetIntersectWithVerAxis();
                    if (intersectWithHorAxis != float.MaxValue)
                    {
                        if (intersectWithHorAxis > 0f)
                        {
                            list.Add(intersectWithHorAxis);
                        }
                        else
                        {
                            list3.Add(intersectWithHorAxis);
                        }
                    }
                    if (intersectWithVerAxis != float.MaxValue)
                    {
                        if (intersectWithVerAxis > 0f)
                        {
                            list2.Add(intersectWithVerAxis);
                        }
                        else
                        {
                            list4.Add(intersectWithVerAxis);
                        }
                    }
                }
                if (((((list.Count % 2) == 0) || ((list2.Count % 2) == 0)) || ((list3.Count % 2) == 0)) || ((list4.Count % 2) == 0))
                {
                    return false;
                }
            }
            return true;
        }

        public void Draw(Graphics g, Pen pen)
        {
            for (int i = 0; i < this.theVertex.Length; i++)
            {
                this.GetEdge(i).Draw(g, pen);
            }
        }

        public void Draw(Graphics g, Pen pen, SolidBrush brushNode, Font fontText)
        {
            for (int i = 0; i < this.theVertex.Length; i++)
            {
                this.GetEdge(i).Draw(g, pen, brushNode, fontText);
            }
        }

        public LineSegment GetEdge(int index)
        {
            if ((index >= this.theVertex.Length) || (index < 0))
            {
                throw new IndexOutOfRangeException("The index is out of range !");
            }
            if (index == (this.theVertex.Length - 1))
            {
                return new LineSegment(this.theVertex[index], this.theVertex[0]);
            }
            return new LineSegment(this.theVertex[index], this.theVertex[index + 1]);
        }

        public Point GetVertex(int index)
        {
            if ((index >= this.theVertex.Length) || (index < 0))
            {
                throw new IndexOutOfRangeException("The index is out of range !");
            }
            return this.theVertex[index];
        }

        public bool IsOnEdge(Point target)
        {
            for (int i = 0; i < this.theVertex.Length; i++)
            {
                if (this.GetEdge(i).Contains(target))
                {
                    return true;
                }
            }
            return false;
        }

        public Polygon Offset(int offsetX, int offsetY)
        {
            Point[] vertex = new Point[this.theVertex.Length];
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i] = new Point(this.theVertex[i].X - offsetX, this.theVertex[i].Y - offsetY);
            }
            return new Polygon(vertex);
        }
    }
}


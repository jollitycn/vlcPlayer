namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;
    using System.Drawing;

    public class BinaryTreeDrawer<TVal> : IBinaryTreeDrawer<TVal> where TVal: IComparable
    {
        private IBinaryTree<TVal> curTree;
        private DrawerParas drawParas;
        private int offsetX;
        private int offsetY;

        public BinaryTreeDrawer()
        {
            this.drawParas = null;
            this.curTree = null;
            this.offsetX = 0;
            this.offsetY = 0;
        }

        public void DrawBinaryTree(IBinaryTree<TVal> tree, int offsetLeft, int offsetHigh)
        {
            if (((this.drawParas != null) && (tree != null)) && (tree.Count != 0))
            {
                this.curTree = tree;
                this.offsetX = offsetLeft;
                this.offsetY = offsetHigh;
                try
                {
                    this.drawParas.Graphic.Clear(this.drawParas.GraphicBackColor);
                    Point[][] nodePosition = this.GetNodePosition(tree.Depth);
                    Node<TVal> root = tree.Root;
                    this.DrawTree(root, 0, 0, this.drawParas.Graphic, nodePosition, offsetLeft, offsetHigh);
                }
                catch (Exception exception)
                {
                    exception = exception;
                }
            }
        }

        private void DrawTree(Node<TVal> root, int rowIndex, int colIndex, Graphics g, Point[][] position, int offsetLeft, int offsetHigh)
        {
            if (root != null)
            {
                int num6;
                int radius = this.drawParas.Radius;
                int x = ((position[rowIndex][colIndex].X * radius) - offsetLeft) + radius;
                int y = ((position[rowIndex][colIndex].Y * radius) - offsetHigh) + radius;
                g.FillEllipse(this.drawParas.BrushNode, x, y, radius * 2, radius * 2);
                g.DrawEllipse(this.drawParas.PenNode, x, y, radius * 2, radius * 2);
                g.DrawString(root.TheValue.ToString(), this.drawParas.FontText, this.drawParas.BrushText, (float) (x + (radius / 4)), (float) (y + (radius / 4)));
                int num4 = 0;
                int num5 = 0;
                if (root.LeftChild != null)
                {
                    num6 = 2 * colIndex;
                    num4 = ((position[rowIndex + 1][num6].X * radius) - offsetLeft) + radius;
                    num5 = ((position[rowIndex + 1][num6].Y * radius) - offsetHigh) + radius;
                    g.DrawLine(this.drawParas.PenNode, (int) (x + (radius / 2)), (int) (y + (radius / 2)), (int) (num4 + (radius / 2)), (int) (num5 + (radius / 2)));
                    this.DrawTree(root.LeftChild, rowIndex + 1, num6, g, position, offsetLeft, offsetHigh);
                }
                if (root.RightChild != null)
                {
                    num6 = (2 * colIndex) + 1;
                    num4 = ((position[rowIndex + 1][num6].X * radius) - offsetLeft) + radius;
                    num5 = ((position[rowIndex + 1][num6].Y * radius) - offsetHigh) + radius;
                    g.DrawLine(this.drawParas.PenNode, (int) (x + (radius / 2)), (int) (y + (radius / 2)), (int) (num4 + (radius / 2)), (int) (num5 + (radius / 2)));
                    this.DrawTree(root.RightChild, rowIndex + 1, num6, g, position, offsetLeft, offsetHigh);
                }
            }
        }

        public Size GetCanvasSize(int binaryTreeDepth, int radius)
        {
            int width = radius * ((int) Math.Pow(2.0, (double) (binaryTreeDepth - 1)));
            return new Size(width, radius * binaryTreeDepth);
        }

        private Point[][] GetNodePosition(int depth)
        {
            int num;
            Point[][] pointArray = new Point[depth][];
            for (num = 0; num < depth; num++)
            {
                pointArray[num] = new Point[(int) Math.Pow(2.0, (double) num)];
            }
            int index = 0;
            while (index < Math.Pow(2.0, (double) (depth - 1)))
            {
                pointArray[depth - 1][index].X = 2 * index;
                pointArray[depth - 1][index].Y = 2 * depth;
                index++;
            }
            if (depth >= 2)
            {
                for (num = depth - 2; num >= 0; num--)
                {
                    for (index = 0; index < Math.Pow(2.0, (double) num); index++)
                    {
                        pointArray[num][index].X = (pointArray[num + 1][2 * index].X + pointArray[num + 1][(2 * index) + 1].X) / 2;
                        pointArray[num][index].Y = 2 * (num + 1);
                    }
                }
            }
            return pointArray;
        }

        public void Initialize(DrawerParas paras)
        {
            this.drawParas = paras;
        }

        public void ResetGraphic(Graphics g)
        {
            if (this.drawParas != null)
            {
                this.drawParas.Graphic = g;
            }
        }

        public void Zoom(double coeff)
        {
            this.drawParas.Radius = (int) (this.drawParas.Radius * coeff);
            if (this.curTree != null)
            {
                this.DrawBinaryTree(this.curTree, this.offsetX, this.offsetY);
            }
        }

        public int Radius
        {
            get
            {
                if (this.drawParas == null)
                {
                    return 0;
                }
                return this.drawParas.Radius;
            }
        }
    }
}


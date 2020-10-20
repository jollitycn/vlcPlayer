namespace CJBasic.Arithmetic.AStar
{
    using System;
    using System.Drawing;

    public class AStarNode
    {
        private int costG = 0;
        private int costH = 0;
        private Point location = new Point(0, 0);
        private AStarNode previousNode = null;

        public AStarNode(Point loc, AStarNode previous, int _costG, int _costH)
        {
            this.location = loc;
            this.previousNode = previous;
            this.costG = _costG;
            this.costH = _costH;
        }

        public void ResetPreviousNode(AStarNode previous, int _costG)
        {
            this.previousNode = previous;
            this.costG = _costG;
        }

        public override string ToString()
        {
            return this.location.ToString();
        }

        public int CostF
        {
            get
            {
                return (this.costG + this.costH);
            }
        }

        public int CostG
        {
            get
            {
                return this.costG;
            }
        }

        public int CostH
        {
            get
            {
                return this.costH;
            }
        }

        public Point Location
        {
            get
            {
                return this.location;
            }
        }

        public AStarNode PreviousNode
        {
            get
            {
                return this.previousNode;
            }
        }
    }
}


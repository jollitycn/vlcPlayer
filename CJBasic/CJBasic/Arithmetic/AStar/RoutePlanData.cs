namespace CJBasic.Arithmetic.AStar
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class RoutePlanData
    {
        private Rectangle cellMap;
        private IList<AStarNode> closedList = new List<AStarNode>();
        private Point destination;
        private IList<AStarNode> openedList = new List<AStarNode>();

        public RoutePlanData(Rectangle map, Point _destination)
        {
            this.cellMap = map;
            this.destination = _destination;
        }

        public Rectangle CellMap
        {
            get
            {
                return this.cellMap;
            }
        }

        public IList<AStarNode> ClosedList
        {
            get
            {
                return this.closedList;
            }
        }

        public Point Destination
        {
            get
            {
                return this.destination;
            }
        }

        public IList<AStarNode> OpenedList
        {
            get
            {
                return this.openedList;
            }
        }
    }
}


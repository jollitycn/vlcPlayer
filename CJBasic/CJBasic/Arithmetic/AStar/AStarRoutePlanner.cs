namespace CJBasic.Arithmetic.AStar
{
    using CJBasic.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class AStarRoutePlanner
    {
        private int columnCount;
        private ICostGetter costGetter;
        private int lineCount;
        private bool[][] obstacles;

        public AStarRoutePlanner() : this(10, 10, new SimpleCostGetter())
        {
        }

        public AStarRoutePlanner(int _lineCount, int _columnCount, ICostGetter _costGetter)
        {
            this.lineCount = 10;
            this.columnCount = 10;
            this.costGetter = new SimpleCostGetter();
            this.obstacles = null;
            this.lineCount = _lineCount;
            this.columnCount = _columnCount;
            this.costGetter = _costGetter;
            this.InitializeObstacles();
        }

        private IList<Point> DoPlan(RoutePlanData routePlanData, AStarNode currenNode)
        {
            IList<CompassDirections> allCompassDirections = CompassDirectionsHelper.GetAllCompassDirections();
            foreach (CompassDirections directions in allCompassDirections)
            {
                Point adjacentPoint = GeometryHelper.GetAdjacentPoint(currenNode.Location, directions);
                if (routePlanData.CellMap.Contains(adjacentPoint) && !this.obstacles[adjacentPoint.X][adjacentPoint.Y])
                {
                    int cost = this.costGetter.GetCost(currenNode.Location, directions);
                    int introduced15 = Math.Abs((int) (adjacentPoint.X - routePlanData.Destination.X));
                    int num2 = introduced15 + Math.Abs((int) (adjacentPoint.Y - routePlanData.Destination.Y));
                    if (num2 == 0)
                    {
                        IList<Point> list2 = new List<Point>();
                        list2.Add(routePlanData.Destination);
                        list2.Insert(0, currenNode.Location);
                        for (AStarNode node = currenNode; node.PreviousNode != null; node = node.PreviousNode)
                        {
                            list2.Insert(0, node.PreviousNode.Location);
                        }
                        return list2;
                    }
                    AStarNode nodeOnLocation = this.GetNodeOnLocation(adjacentPoint, routePlanData);
                    if (nodeOnLocation != null)
                    {
                        if (nodeOnLocation.CostG > cost)
                        {
                            nodeOnLocation.ResetPreviousNode(currenNode, cost);
                        }
                    }
                    else
                    {
                        AStarNode item = new AStarNode(adjacentPoint, currenNode, cost, num2);
                        routePlanData.OpenedList.Add(item);
                    }
                }
            }
            routePlanData.OpenedList.Remove(currenNode);
            routePlanData.ClosedList.Add(currenNode);
            AStarNode minCostNode = this.GetMinCostNode(routePlanData.OpenedList);
            if (minCostNode == null)
            {
                return null;
            }
            return this.DoPlan(routePlanData, minCostNode);
        }

        private AStarNode GetMinCostNode(IList<AStarNode> openedList)
        {
            if (openedList.Count == 0)
            {
                return null;
            }
            AStarNode node = openedList[0];
            foreach (AStarNode node2 in openedList)
            {
                if (node2.CostF < node.CostF)
                {
                    node = node2;
                }
            }
            return node;
        }

        private AStarNode GetNodeOnLocation(Point location, RoutePlanData routePlanData)
        {
            foreach (AStarNode node in routePlanData.OpenedList)
            {
                if (node.Location == location)
                {
                    return node;
                }
            }
            foreach (AStarNode node in routePlanData.ClosedList)
            {
                if (node.Location == location)
                {
                    return node;
                }
            }
            return null;
        }

        public void Initialize(IList<Point> obstaclePoints)
        {
            if (this.obstacles != null)
            {
                foreach (Point point in obstaclePoints)
                {
                    this.obstacles[point.X][point.Y] = true;
                }
            }
        }

        private void InitializeObstacles()
        {
            int num;
            this.obstacles = new bool[this.columnCount][];
            for (num = 0; num < this.columnCount; num++)
            {
                this.obstacles[num] = new bool[this.lineCount];
            }
            for (num = 0; num < this.columnCount; num++)
            {
                for (int i = 0; i < this.lineCount; i++)
                {
                    this.obstacles[num][i] = false;
                }
            }
        }

        public IList<Point> Plan(Point start, Point destination)
        {
            Rectangle map = new Rectangle(0, 0, this.columnCount, this.lineCount);
            if (!(map.Contains(start) && map.Contains(destination)))
            {
                throw new Exception("StartPoint or Destination not in the current map!");
            }
            RoutePlanData routePlanData = new RoutePlanData(map, destination);
            AStarNode item = new AStarNode(start, null, 0, 0);
            routePlanData.OpenedList.Add(item);
            AStarNode currenNode = item;
            return this.DoPlan(routePlanData, currenNode);
        }
    }
}


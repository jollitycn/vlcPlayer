namespace CJBasic.Arithmetic.AStar
{
    using CJBasic.Geometry;
    using System;
    using System.Drawing;

    public class SimpleCostGetter : ICostGetter
    {
        public int GetCost(Point currentNodeLoaction, CompassDirections moveDirection)
        {
            if (moveDirection == CompassDirections.NotSet)
            {
                return 0;
            }
            if ((((moveDirection == CompassDirections.East) || (moveDirection == CompassDirections.West)) || (moveDirection == CompassDirections.South)) || (moveDirection == CompassDirections.North))
            {
                return 10;
            }
            return 14;
        }
    }
}


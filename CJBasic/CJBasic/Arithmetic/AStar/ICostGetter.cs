namespace CJBasic.Arithmetic.AStar
{
    using CJBasic.Geometry;
    using System;
    using System.Drawing;

    public interface ICostGetter
    {
        int GetCost(Point currentNodeLoaction, CompassDirections moveDirection);
    }
}


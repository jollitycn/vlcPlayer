namespace CJBasic.Geometry
{
    using System;
    using System.Collections.Generic;

    public static class CompassDirectionsHelper
    {
        private static IList<CompassDirections> AllCompassDirections = new List<CompassDirections>();

        static CompassDirectionsHelper()
        {
            AllCompassDirections.Add(CompassDirections.East);
            AllCompassDirections.Add(CompassDirections.West);
            AllCompassDirections.Add(CompassDirections.South);
            AllCompassDirections.Add(CompassDirections.North);
            AllCompassDirections.Add(CompassDirections.SouthEast);
            AllCompassDirections.Add(CompassDirections.SouthWest);
            AllCompassDirections.Add(CompassDirections.NorthEast);
            AllCompassDirections.Add(CompassDirections.NorthWest);
        }

        public static IList<CompassDirections> GetAllCompassDirections()
        {
            return AllCompassDirections;
        }

        public static CompassDirections GetAntiCompassDirections(CompassDirections direction)
        {
            if (direction != CompassDirections.NotSet)
            {
                if (direction == CompassDirections.North)
                {
                    return CompassDirections.South;
                }
                if (direction == CompassDirections.South)
                {
                    return CompassDirections.North;
                }
                if (direction == CompassDirections.East)
                {
                    return CompassDirections.West;
                }
                if (direction == CompassDirections.West)
                {
                    return CompassDirections.East;
                }
                if (direction == CompassDirections.NorthEast)
                {
                    return CompassDirections.SouthWest;
                }
                if (direction == CompassDirections.NorthWest)
                {
                    return CompassDirections.SouthEast;
                }
                if (direction == CompassDirections.SouthWest)
                {
                    return CompassDirections.NorthEast;
                }
                if (direction == CompassDirections.SouthEast)
                {
                    return CompassDirections.NorthWest;
                }
            }
            return CompassDirections.NotSet;
        }
    }
}


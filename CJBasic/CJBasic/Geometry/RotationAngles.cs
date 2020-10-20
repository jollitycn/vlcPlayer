namespace CJBasic.Geometry
{
    using System;

    public static class RotationAngles
    {
        public const float A0 = 0f;
        public const float A135 = 2.356194f;
        public const float A180 = 3.141593f;
        public const float A225 = 3.926991f;
        public const float A270 = -1.570796f;
        public const float A315 = -0.7853982f;
        public const float A45 = 0.7853982f;
        public const float A90 = 1.570796f;

        public static float GetAngleOfDirection(CompassDirections direction)
        {
            if (direction != CompassDirections.North)
            {
                if (direction == CompassDirections.NorthEast)
                {
                    return 0.7853982f;
                }
                if (direction == CompassDirections.NorthWest)
                {
                    return -0.7853982f;
                }
                if (direction == CompassDirections.South)
                {
                    return 3.141593f;
                }
                if (direction == CompassDirections.SouthEast)
                {
                    return 2.356194f;
                }
                if (direction == CompassDirections.SouthWest)
                {
                    return 3.926991f;
                }
                if (direction == CompassDirections.East)
                {
                    return 1.570796f;
                }
                if (direction == CompassDirections.West)
                {
                    return -1.570796f;
                }
            }
            return 0f;
        }
    }
}


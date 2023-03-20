using System;

namespace CalculateArea
{
    public class Geometry
    {
        public static double AreaOfCircle(decimal radius)
        {
            var pi = Math.PI;
            return pi * (double)radius * 2;
        }

        public static double AreaOfRectangle(decimal length, decimal width)
        {
            return (double)length * (double)width;
        }

        public static double AreaOfTriangle(decimal ground, decimal h)
        {
            return (double)ground * (double)h * 0.5d;
        }
    }
}

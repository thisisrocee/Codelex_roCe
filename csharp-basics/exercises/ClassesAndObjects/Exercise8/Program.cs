using System;

namespace Exercise8
{
    class Point
    {
        public int _x;
        public int _y;
        public Point(int x, int y)
        {
            _x = x; 
            _y = y;
        }

        public void SwapPoints(Point other)
        {
            var x1 = _x;
            var y1 = _y;

            _x = other._x;
            _y = other._y;

            other._x  = x1;
            other._y = y1;
        }
    }
}
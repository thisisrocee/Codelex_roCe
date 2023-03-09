using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    internal class PointTest
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(5, 2);
            Point p2 = new Point(-3, 6);

            p1.SwapPoints(p2);

            Console.WriteLine($"({p1._x}, {p1._y})");
            Console.WriteLine($"({p2._x}, {p2._y})");
        }
    }
}

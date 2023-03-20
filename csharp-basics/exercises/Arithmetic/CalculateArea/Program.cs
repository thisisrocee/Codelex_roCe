using System;

namespace CalculateArea
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GetMenu();
        }

        public static int GetMenu()
        {
            Console.WriteLine("Geometry Calculator\n");
            Console.WriteLine("1. Calculate the Area of a Circle");
            Console.WriteLine("2. Calculate the Area of a Rectangle");
            Console.WriteLine("3. Calculate the Area of a Triangle");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Enter your choice (1-4) : ");
            var keyboard = Console.ReadKey();
            var userChoice = int.Parse(keyboard.KeyChar.ToString());

            while (true)
            {
                if (userChoice == 1)
                    CalculateCircleArea();
                else if (userChoice == 2)
                    CalculateRectangleArea();
                else if (userChoice == 3) CalculateTriangleArea();
                else if (userChoice == 4) break;
            }
            return userChoice;
        }

        public static void CalculateCircleArea()
        {
            Console.WriteLine("\nWhat is the circle's radius? ");
            var radius = int.Parse(Console.ReadLine());

            Console.WriteLine("The circle's area is "
                              + Geometry.AreaOfCircle(radius));
        }

        public static void CalculateRectangleArea()
        {
            decimal length;
            decimal width;

            Console.WriteLine("\nEnter length? ");
            length = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter width? ");
            width = decimal.Parse(Console.ReadLine());

            Console.WriteLine("The rectangle's area is "
                              + Geometry.AreaOfTriangle(length, width));
        }

        public static void CalculateTriangleArea()
        {
            decimal ground;
            decimal height;

            Console.WriteLine("\nEnter length of the triangle's base? ");
            ground = decimal.Parse(Console.ReadLine());
            Console.ReadKey();

            Console.WriteLine("Enter triangle's height? ");
            height = decimal.Parse(Console.ReadLine());
            Console.ReadKey();

            Console.WriteLine("The triangle's area is "
                              + Geometry.AreaOfRectangle(ground, height));
        }
    }
}
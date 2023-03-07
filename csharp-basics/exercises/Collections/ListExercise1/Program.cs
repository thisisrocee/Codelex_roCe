using System;
using System.Collections.Generic;

namespace ListExercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var colorList = new List<string>();

            colorList.Add("Blue");
            colorList.Add("Green");
            colorList.Add("Red");
            colorList.Add("Yellow");
            colorList.Add("Silver");

            Console.WriteLine(string.Join(", ", colorList));
        }
    }
}

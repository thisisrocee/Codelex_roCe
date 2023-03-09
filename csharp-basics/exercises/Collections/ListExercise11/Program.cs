using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            var strList = new List<string>
            {
                "add",
                "10",
                "values",
                "to",
                "list",
                "add",
                "new",
                "Foobar",
                "value",
                "position",
            };

            strList.Insert(4, "New value!");
            strList[strList.Count - 1] = "Changed value!";
            strList.Sort();

            Console.WriteLine($"Contains Foobar? {strList.Contains("Foobar")}");

            Console.WriteLine("Printed List: ");

            foreach (var word in strList)
            {
                Console.Write(word + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class DogTest
    {
        static void Main(string[] args)
        {
            var max = new Dog("Max", "male");
            var rocky = new Dog("Rocky", "male");
            var sparky = new Dog("Sparky", "male");
            var buster = new Dog("Buster", "male");
            var sam = new Dog("Sam", "male");
            var lady = new Dog("Lady", "female");
            var molly = new Dog("Molly", "female");
            var coco = new Dog("Coco", "female");

            max.SetFather("Rocky");
            max.SetMother("Lady");
            rocky.SetFather("Sam");
            rocky.SetMother("Molly");
            buster.SetFather("Sparky");
            buster.SetMother("Lady");
            coco.SetFather("Buster");
            coco.SetMother("Molly");

            Console.WriteLine(coco.FathersName());
            Console.WriteLine(sparky.FathersName());
            Console.WriteLine(coco.HasSameMotherAs(rocky));
        }
    }
}

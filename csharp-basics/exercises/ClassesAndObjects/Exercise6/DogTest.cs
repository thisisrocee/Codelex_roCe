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
            Dog max = new Dog("Max", "male");
            Dog rocky = new Dog("Rocky", "male");
            Dog sparky = new Dog("Sparky", "male");
            Dog buster = new Dog("Buster", "male");
            Dog sam = new Dog("Sam", "male");
            Dog lady = new Dog("Lady", "female");
            Dog molly = new Dog("Molly", "female");
            Dog coco = new Dog("Coco", "female");

            max.setFather("Rocky");
            max.setMother("Lady");
            rocky.setFather("Sam");
            rocky.setMother("Molly");
            buster.setFather("Sparky");
            buster.setMother("Lady");
            coco.setFather("Buster");
            coco.setMother("Molly");

            Console.WriteLine(coco.FathersName());
            Console.WriteLine(sparky.FathersName());
            Console.WriteLine(coco.HasSameMotherAs(rocky));
        }
    }
}

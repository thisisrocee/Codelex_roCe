using System;

namespace MoreVariablesAndPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, eyes, teeth, hair;
            int age, heightInInches, weightInPounds;
            double heightInCm, weightInKgs;

            name = "Zed A. Shaw";
            age = 35;
            heightInInches = 74;  // inches
            heightInCm = heightInInches * 2.54;  // centimeters
            weightInPounds = 180; // lbs
            weightInKgs = Math.Round(weightInPounds * 0.453592); // kgs
            eyes = "Blue";
            teeth = "White";
            hair = "Brown";

            Console.WriteLine("Let's talk about " + name + ".");
            Console.WriteLine("He's " + heightInInches + " inches tall (That's " + heightInCm + "cm tall).");
            Console.WriteLine("He's " + weightInPounds + " pounds heavy (That's " + weightInKgs + "kg heavy).");
            Console.WriteLine("Actually, that's not too heavy.");
            Console.WriteLine("He's got " + eyes + " eyes and " + hair + " hair.");
            Console.WriteLine("His teeth are usually " + teeth + " depending on the coffee.");

            Console.WriteLine("If I add " + age + ", " + heightInCm + "cm + and " + weightInKgs
                              + "kg = I get " + (age + heightInCm + weightInKgs) + ".");

            Console.ReadKey();
        }
    }
}
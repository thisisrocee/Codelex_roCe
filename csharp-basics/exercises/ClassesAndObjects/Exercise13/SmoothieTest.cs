namespace Exercise13
{
    public class SmoothieTest
    {
        static void Main(string[] args)
        {
            var s1 = new Smoothie(new string[] { "Banana" });
            Console.WriteLine(string.Join(", ", s1.Ingredients));
            s1.GetCost();
            s1.GetPrice();
            s1.GetName();

            Console.WriteLine();

            var s2 = new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" });
            Console.WriteLine(string.Join(", ", s2.Ingredients));
            s2.GetCost();
            s2.GetPrice();
            s2.GetName();
        }
    }
}

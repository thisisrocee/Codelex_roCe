using System;

namespace Exercise13;
class Smoothie
{
    public string[] Ingredients;
    private double cost;
    private Dictionary<string, double> fruits = new Dictionary<string, double>()
    {
        { "Strawberries", 1.50 },
        { "Banana", 0.50 },
        { "Mango", 2.50 },
        { "Blueberries", 1.00 },
        { "Raspberries", 1.00 },
        { "Apple", 1.75 },
        { "Pineapple", 3.50 },
    };

    public Smoothie(string[] ingredients)
    {
        Ingredients = ingredients;
    }

    public void GetCost()
    {
        cost = 0.0;
        foreach (var product in Ingredients)
        {
            if (fruits.ContainsKey(product))
            {
                cost += fruits[product];
            }
            else
            {
                Console.WriteLine($"{product} not found");
            }
        }

        Console.WriteLine($"£{cost:F2}");
    }

    public void GetPrice()
    {
        var price = cost + (cost * 1.5);
        Console.WriteLine($"£{price:F2}");
    }

    public void GetName()
    {
        Array.Sort(Ingredients);
        var updatedArr = new string[Ingredients.Length + 1];
        Array.Copy(Ingredients, updatedArr, Ingredients.Length);
        Ingredients = updatedArr;

        if (Ingredients.Length > 2)
        {
            updatedArr[updatedArr.Length - 1] = "Fusion";
        }
        else
        {
            updatedArr[updatedArr.Length - 1] = "Smoothie";
        }

        updatedArr = Ingredients.Select(s => s.Replace("berries", "berry")).ToArray();

        Console.WriteLine(string.Join(" ", updatedArr));
    }
}

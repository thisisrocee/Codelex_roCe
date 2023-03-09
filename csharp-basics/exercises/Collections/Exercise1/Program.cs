using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "Volkswagen", "Mercedes", "Tesla" };

            Console.WriteLine("List:");
            Console.WriteLine();

            var carsList = new List<string>();
            carsList.AddRange(array);

            foreach (var car in carsList)
            {
                Console.Write($"{car} -> ");

                switch (car)
                {
                    case "Audi":
                    case "BMW":
                    case "Mercedes":
                    case "Volkswagen":
                        Console.Write("Germany");
                        break;
                    case "Honda":
                        Console.Write("Japan");
                        break;
                    case "Tesla":
                        Console.Write("USA");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("HashSet:");
            Console.WriteLine();

            var carsHashSet = new HashSet<string>();
            carsHashSet.UnionWith(array);

            foreach (var car in carsHashSet)
            {
                Console.Write($"{car} -> ");

                switch (car)
                {
                    case "Audi":
                    case "BMW":
                    case "Mercedes":
                    case "Volkswagen":
                        Console.Write("Germany");
                        break;
                    case "Honda":
                        Console.Write("Japan");
                        break;
                    case "Tesla":
                        Console.Write("USA");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Dictionary:");
            Console.WriteLine();

            var carsDictionary = new Dictionary<string, string>();

            foreach (var car in array)
            {
                switch (car)
                {
                    case "Audi":
                    case "BMW":
                    case "Mercedes":
                    case "Volkswagen":
                        if (!carsDictionary.ContainsKey(car))
                        {
                            carsDictionary.Add(car, "Germany");
                        }
                        break;
                    case "Honda":
                        if (!carsDictionary.ContainsKey(car))
                        {
                            carsDictionary.Add(car, "Japan");
                        }
                        break;
                    case "Tesla":
                        if (!carsDictionary.ContainsKey(car))
                        {
                            carsDictionary.Add(car, "USA");
                        }
                        break;
                }
            }

            foreach (var car in carsDictionary)
            {
                Console.WriteLine($"{car.Key} -> {car.Value}");
            }
        }
    }
}

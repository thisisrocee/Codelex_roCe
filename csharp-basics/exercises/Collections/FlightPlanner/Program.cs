using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightPlanner
{
    class Program
    {
        private const string Path = "../../flights.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);
            var userInput = "";

            do
            {
                Console.WriteLine("What would you like to do: \n" +
                                  "To display list of the cities press 1\n" +
                                  "To exit program press #");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("To select a city from which you would like to start press 1");
                    var userInputCity = Console.ReadLine();

                    if (userInputCity == "1")
                    {
                        var fromCityList = new List<string>();

                        foreach (var line in readText)
                        {
                            var allCities = line.Split('-', '>');
                            fromCityList.Add(allCities[0].Trim());
                        }

                        Console.Write(string.Join(", ", fromCityList.Distinct()) + "\n");

                        Console.Write("Enter starting city: ");
                        var start = Console.ReadLine();

                        ToCity(readText, start);

                        var resultCityList = new List<string> { start };

                        var equalToStart = false;

                        while (!equalToStart)
                        {
                            Console.Write("Select a city to fly to next: ");
                            var nextFlight = Console.ReadLine();

                            resultCityList.Add(nextFlight);

                            if (start == resultCityList.Last() && resultCityList.Count() > 1)
                            {
                                equalToStart = true;
                                break;
                            }

                            ToCity(readText, nextFlight);
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Your round-trip route: {string.Join(" -> ", resultCityList)}");
                        break;
                    }

                    Console.WriteLine("Invalid input");
                }
            } while (userInput != "#");

            Console.ReadKey();
        }

        public static void ToCity(string[] text, string city)
        {
            foreach (var line in text)
            {
                var way = line.Split('-', '>');
                var fromCity = way[0].Trim();
                var toCity = way[way.Length - 1].Trim();

                if (fromCity == city)
                {
                    Console.WriteLine(toCity);
                }
            }
        }
    }
}

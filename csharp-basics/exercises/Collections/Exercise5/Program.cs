Console.Write("Write a number:");
var num = Console.ReadLine();

var res = num.Select(c => Math.Pow(char.GetNumericValue(c), 2)).ToList().Sum();

Console.WriteLine(res == 1 ? "happy" : res);
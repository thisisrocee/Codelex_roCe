Console.WriteLine("Insert a number");
var num = int.Parse(Console.ReadLine());

Console.WriteLine(CheckOddEven(num));
Console.WriteLine("bye!");
Console.ReadKey();
static string CheckOddEven(int number)
{
    return number % 2 == 0 ? "Even Number" : "Odd Number";
}
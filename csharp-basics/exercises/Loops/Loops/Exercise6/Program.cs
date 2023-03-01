Console.WriteLine("Max value?");
var max = int.Parse(Console.ReadLine());
var min = 1;
var columns = 20;

for (var i = min; i <= max; i += columns)
{
    for (var j = i; j < i + columns; j++)
    {
        var fizz = j % 3 == 0;
        var buzz = j % 5 == 0;

        switch ((fizz ? 1 : 0) | (buzz ? 2 : 0))
        {
            case 1:
                Console.Write("Fizz ");
                break;
            case 2:
                Console.Write("Buzz ");
                break;
            case 3:
                Console.Write("FizzBuzz ");
                break;
            default:
                Console.Write(j + " ");
                break;
        }
    }
    Console.WriteLine();
}
Console.ReadKey();
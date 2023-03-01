using System.Text;

Console.WriteLine("Min?");
var min = int.Parse(Console.ReadLine());

Console.WriteLine("Max?");
var max = int.Parse(Console.ReadLine());

Console.WriteLine(NumberSquare(min, max));

static string NumberSquare(int min, int max)
{
    var sb = new StringBuilder();

    for (var i = min; i <= max; i++)
    {
        for (var j = i; j <= max; j++)
        {
            sb.Append(j);
        }

        for (var k = min; k < i; k++)
        {
            sb.Append(k);
        }

        sb.Append('\n');
    }

    return sb.ToString();
}
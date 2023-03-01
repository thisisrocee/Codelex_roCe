using System.Text;

Console.WriteLine(AsciiFigure(3));
Console.WriteLine(string.Empty);

Console.WriteLine(AsciiFigure(5));
Console.WriteLine(string.Empty);

Console.WriteLine(AsciiFigure(7));
Console.WriteLine(string.Empty);

static string AsciiFigure(int size)
{
    var sb = new StringBuilder();

    for (int i = 0; i < size; i++)
    {
        for (int j = 1; j < size - i; j++)
        {
            sb.Append("////");
        }

        for (int j = 1; j <= 8 * i; j++)
        {
            sb.Append("*");
        }

        for (int j = size - i; j > 1; j--)
        {
            sb.Append(@"\\\\");
        }

        sb.Append("\n");
    }

    return sb.ToString();
}
var min = 1;
var max = 110;
var columns = 11;

for (var i = min; i <= max; i += columns)
{
    for (var j = i; j < i + columns; j++)
    {
        var isCoza = j % 3 == 0;
        var isLoza = j % 5 == 0;
        var isWoza = j % 7 == 0;

        switch ((isCoza ? 1 : 0) | (isLoza ? 2 : 0) | (isWoza ? 4 : 0))
        {
            case 1:
                Console.Write("Coza ");
                break;
            case 2:
                Console.Write("Loza ");
                break;
            case 3:
                Console.Write("CozaLoza ");
                break;
            case 4:
                Console.Write("Woza ");
                break;
            case 5:
                Console.Write("CozaWoza ");
                break;
            case 6:
                Console.Write("LozaWoza ");
                break;
            case 7:
                Console.Write("CozaLozaWoza ");
                break;
            default:
                Console.Write(j + " ");
                break;
        }
    }
    Console.WriteLine();
}
Console.ReadKey();
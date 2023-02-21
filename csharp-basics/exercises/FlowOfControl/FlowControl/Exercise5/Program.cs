Console.WriteLine("Write your value!");
var phoneKey = Console.ReadLine();

Console.WriteLine(PhoneKeyPad(phoneKey));
Console.ReadKey();

static string PhoneKeyPad(string phoneKey)
{
    var inChar = phoneKey.ToLower();
    var num = 0;
    var numResult = num;

    for (var i = 0; i < phoneKey.Length; i++)
    {
        var iterator = inChar[i];
        if (iterator == 'a' || iterator == 'b' || iterator == 'c')
            num = 2;
        else if (iterator == 'd' || iterator == 'e' || iterator == 'f')
            num = 3;
        else if (iterator == 'g' || iterator == 'h' || iterator == 'i')
            num = 4;
        else if (iterator == 'j' || iterator == 'k' || iterator == 'l')
            num = 5;
        else if (iterator == 'm' || iterator == 'n' || iterator == 'o')
            num = 6;
        else if (iterator == 'p' || iterator == 'q' || iterator == 'r' || iterator == 's')
            num = 7;
        else if (iterator == 't' || iterator == 'u' || iterator == 'v')
            num = 8;
        else if (iterator == 'w' || iterator == 'x' || iterator == 'y' || iterator == 'z')
            num = 9;
        else
            return "Must be a string!";

        //switch (iterator)
        //{
        //    case 'a':
        //    case 'b':
        //    case 'c':
        //        num = 2; break;
        //    case 'd':
        //    case 'e':
        //    case 'f':
        //        num = 3; break;
        //    case 'g':
        //    case 'h':
        //    case 'i':
        //        num = 4; break;
        //    case 'j':
        //    case 'k':
        //    case 'l':
        //        num = 5; break;
        //    case 'm':
        //    case 'n':
        //    case 'o':
        //        num = 6; break;
        //    case 'p':
        //    case 'q':
        //    case 'r':
        //    case 's':
        //        num = 7; break;
        //    case 't':
        //    case 'u':
        //    case 'v':
        //        num = 8; break;
        //    case 'w':
        //    case 'x':
        //    case 'y':
        //    case 'z':
        //        num = 9; break;
        //    default:
        //        return "Must be one digit long!";
        //}
        numResult += num;
    }
    return numResult.ToString();
}
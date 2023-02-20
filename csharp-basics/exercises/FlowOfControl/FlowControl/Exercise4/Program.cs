Console.WriteLine("Write a number which represents a day you want to see printed out! " +
                  "\nFor example, 1 - Monday, 2 - Tuesday, and so on");
var dayNumber = int.Parse(Console.ReadLine());

Console.WriteLine(PrintDayInWord(dayNumber));

static string PrintDayInWord(int dayNumber)
{
    var str = "";
    if (dayNumber == 1)
        str = "Monday";
    else if (dayNumber == 2)
        str = "Tuesday";
    else if (dayNumber == 3)
        str = "Wednesday";
    else if (dayNumber == 4)
        str = "Thursday";
    else if (dayNumber == 5)
        str = "Friday";
    else if (dayNumber == 6)
        str = "Saturday";
    else if (dayNumber == 7)
        str = "Sunday";
    else
        str = "Not a valid day";
    //switch (dayNumber)
    //{
    //    case 1:
    //        str = "Monday";
    //        break;
    //    case 2:
    //        str = "Tuesday";
    //        break;
    //    case 3:
    //        str = "Wednesday";
    //        break;
    //    case 4:
    //        str = "Thursday";
    //        break;
    //    case 5:
    //        str = "Friday";
    //        break;
    //    case 6:
    //        str = "Saturday";
    //        break;
    //    case 7:
    //        str = "Sunday";
    //        break;
    //    default:
    //        str = "Not a valid day";
    //        break;
    //}
    return str;
}
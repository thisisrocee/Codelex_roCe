using System.Linq;

var str = "Happy Birthday";
var str1 = "MANY THANKS";
var str2 = "sPoNtAnEoUs";

Console.WriteLine("Longer code version:");
Console.WriteLine(ReverseTheCase(str));
Console.WriteLine(ReverseTheCase(str1));
Console.WriteLine(ReverseTheCase(str2));

Console.WriteLine(string.Empty);

Console.WriteLine("Shorter code version:");
Console.WriteLine(ReverseTheCaseShorterCode(str));
Console.WriteLine(ReverseTheCaseShorterCode(str1));
Console.WriteLine(ReverseTheCaseShorterCode(str2));

static string ReverseTheCase(string str)
{
    var strSwappedCase = new char[str.Length];

    for (var i = 0; i < strSwappedCase.Length; i++)
    {
        if (char.IsLetter(str[i]))
        {
            strSwappedCase[i] = char.IsUpper(str[i]) ? char.ToLower(str[i]) : char.ToUpper(str[i]);
        }
        else
        {
            strSwappedCase[i] = str[i];
        }
    }

    return new string(strSwappedCase);
}

static string ReverseTheCaseShorterCode(string str)
{
    return new string(str.Select(letter =>
            char.IsLetter(letter) ? (char.IsUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter)) : letter)
        .ToArray());
}
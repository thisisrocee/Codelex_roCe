var str = "I am finding Nemo !";
var str1 = "Nemo is me";
var str2 = "I Nemo am Nemo";
var str3 = "I don't have any";

Console.WriteLine(FindNemo(str));
Console.WriteLine(FindNemo(str1));
Console.WriteLine(FindNemo(str2));
Console.WriteLine(FindNemo(str3));
Console.ReadKey();

static string FindNemo(string str)
{
    var strArr = str.Split(' ');
    var newStr = "";

    for (var i = 0; i < strArr.Length; i++)
    {
        if (strArr[i] == "Nemo")
        {
            newStr = $"I found Nemo at {i}";
            break;
        } else
        {
            newStr = "I can't find Nemo :(";
        }
    }
    return newStr;
}
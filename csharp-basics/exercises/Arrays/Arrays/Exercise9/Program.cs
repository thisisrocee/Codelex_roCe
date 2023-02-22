string[] arr1 = { "mavis", "senaida", "letty" };
string[] arr2 = { "samuel", "MABELLE", "letitia", "meridith" };
string[] arr3 = { "Slyvia", "Kristal", "Sharilyn", "Calista" };



Console.WriteLine(CapMe(arr1));
Console.WriteLine(CapMe(arr2));
Console.WriteLine(CapMe(arr3));

static string CapMe(string[] arr)
{
    var strArr = new string[arr.Length];
    for (var i = 0; i< arr.Length; i++)
    {
        var newWord = arr[i].ToLower();
        var firstChar = newWord[0];
        var result = firstChar.ToString().ToUpper();

        strArr[i] = result + newWord.Substring(1);
    }
    return string.Join(", ", strArr);
}
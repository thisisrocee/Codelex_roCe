Console.WriteLine("Enter first word:");
var firstWord = Console.ReadLine();
Console.WriteLine("Enter second word: ");
var secondWord = Console.ReadLine();

var firstWordLen = firstWord.Length;
var secondWordLen = secondWord.Length;
var dotLen = 30 - (firstWordLen + secondWordLen);

Console.WriteLine(String.Empty);
Console.Write(firstWord);

for (int i = 0; i < dotLen; i++)
{
    Console.Write(".");
}

Console.Write(secondWord);
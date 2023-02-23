var numArr = new int[10];
var otherNumArr = new int[numArr.Length];
Random rand = new Random();

for (var i = 0; i < numArr.Length; i++)
{
    var nums = rand.Next(1, 100);
    numArr[i] = nums;
    for (int j = 0; j <= i; j++)
    {
        otherNumArr[j] = numArr[j];
    }
}
numArr[numArr.Length - 1] = -7;

Console.WriteLine("Array 1: " + string.Join(", ", numArr));
Console.WriteLine("Array 2: " + string.Join(", ", otherNumArr));
Console.ReadKey();
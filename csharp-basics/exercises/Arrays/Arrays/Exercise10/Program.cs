int[] numArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 };
int[] numArr1 = { 92, 6, 73, -77, 81, -90, 99, 8, -85, 34 };
int[] numArr2 = { 91, -4, 80, -73, -28 };
int[] numArr3 = { };

Console.WriteLine(CountPosSumNeg(numArr));
Console.WriteLine(CountPosSumNeg(numArr1));
Console.WriteLine(CountPosSumNeg(numArr2));
Console.WriteLine(CountPosSumNeg(numArr3));
Console.ReadKey();

static string CountPosSumNeg(int[] numArr)
{
    if (numArr.Length == 0)
    {
        return string.Empty;
    }

    var sumPos = 0;
    var sumNeg = 0;

    for (int i = 0; i < numArr.Length; i++)
    {
        if (numArr[i] > 0)
        {
            sumPos++;
        }
        else if (numArr[i] < 0)
        {
            sumNeg += numArr[i];
        }
    }
    return string.Join(",", new int[] { sumPos, sumNeg });
}
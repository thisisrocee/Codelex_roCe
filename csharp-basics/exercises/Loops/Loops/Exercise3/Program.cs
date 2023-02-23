List<int> nums = new List<int> { };
Random rand = new Random();
int randomNum;

for (int i = 0;i < 20; i++)
{
    do
    {
         randomNum = rand.Next(0, 20);
    } while (nums.Contains(randomNum));
    nums.Add(randomNum);
}

Console.WriteLine("Numbers: " + string.Join(" ", nums));
Console.WriteLine("Enter which of these numbers position you want to know?");
var numberToFind = int.Parse(Console.ReadLine());
var result = 0;

for (int i = 0; i < nums.Count; i++)
{
    if (nums[i] == numberToFind)
    {
        result = i;
    }
}

Console.WriteLine($"Number is at position: {result}");
Console.ReadKey();
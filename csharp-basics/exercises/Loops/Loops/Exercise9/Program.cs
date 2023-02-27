Console.WriteLine("Desired sum:");
var userInput = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(RollTwoDice(userInput));

static string RollTwoDice(int userInput)
{
    var rand = new Random();
    string str;

    while (true)
    {
        if (userInput <= 1 || userInput > 12)
        {
            str = "Invalid input!";
            break;
        }

        var firstInt = rand.Next(1, 7);
        var secondInt = rand.Next(1, 7);
        var sumUp = firstInt + secondInt;

        if (sumUp == userInput)
        {
            str = $"{firstInt} and {secondInt} = {userInput}";
            break;
        }

        Console.WriteLine($"{firstInt} and {secondInt} = {sumUp}");
    }

    return str;
}
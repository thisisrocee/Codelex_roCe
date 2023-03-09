Console.WriteLine("I'm thinking of a number between 1-100.  Try to guess it.");
int num;

while (true)
{
    var number = Console.ReadLine();
    if (int.TryParse(number, out num) && num > 0 && num <= 100) break;
    Console.WriteLine("You can type number only in range!");
}

var r = new Random();
var rand = r.Next(1, 100);

if (num == rand)
    Console.WriteLine("You guessed it!  What are the odds?!?");
else if (num > rand)
    Console.WriteLine($"Sorry, you are too high.  I was thinking of {rand}.");
else
    Console.WriteLine($"Sorry, you are too low.  I was thinking of {rand}.");

Console.ReadLine();
using System.Text.RegularExpressions;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PlayGame();

                Console.WriteLine("Play \"again\" or \"quit\"?");

                var againOrQuit = Console.ReadLine().ToLower();

                if (againOrQuit == "again")
                {
                    PlayGame();
                }
                break;
            }
        }
        static void PlayGame()
        {
            List<string> wordsList = new List<string>()
                { "audi", "bmw", "volkswagen", "toyota", "mazda", "mercedes", "dodge", "ford", "seat", "alfaromeo" };

            var choosenWord = wordsList[new Random().Next(0, wordsList.Count - 1)];

            var validCharacter = new Regex("^[a-z]$");

            List<string> letters = new List<string>();

            List<string> misses = new List<string>();
            var lives = 5;

            while (lives != 0)
            {
                Console.Write("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine(String.Empty);
                Console.WriteLine(String.Empty);

                var charactersLeft = 0;
                Console.Write($"Word: ");
                foreach (var character in choosenWord)
                {
                    var letter = character.ToString();
                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                }

                Console.WriteLine(String.Empty);
                Console.WriteLine(String.Empty);

                if (charactersLeft == 0)
                {
                    break;
                }

                Console.WriteLine("Misses: " + string.Join("", misses));
                Console.WriteLine(String.Empty);
                Console.Write("Guess: ");
                var key = Console.ReadKey().Key.ToString().ToLower();
                Console.WriteLine(String.Empty);
                Console.WriteLine(String.Empty);

                if (!validCharacter.IsMatch(key))
                {
                    Console.WriteLine($"The letter {key} is invalid. Try again.");
                    continue;
                }

                Console.WriteLine(String.Empty);

                if (letters.Contains(key))
                {
                    Console.WriteLine("You've already entered this letter!");
                    continue;
                }

                letters.Add(key);

                if (!choosenWord.Contains(key))
                {
                    lives--;
                    misses.Add(key);
                    if (lives > 0)
                    {
                        Console.WriteLine(
                            $"The letter {key} is not in the word. You have {lives}{(lives == 1 ? "try" : "tries")} left!");
                    }
                }
            }
        }
    }
}



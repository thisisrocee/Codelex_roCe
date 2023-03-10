using System.Collections.Generic;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            var soundsList = new List<ISound>()
            {
                new Firework(),
                new Parrot(),
                new Radio()
            };

            foreach (var sounds in soundsList)
            {
                sounds.PlaySound();
            }
        }
    }
}
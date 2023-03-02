using System;

namespace Exercise4
{
    internal class TestMovie
    {
        static void Main(string[] args)
        {
            Movie casionRoyale = new Movie("Casino Royale", "Eon Productions", "PG13");
            Movie glass = new Movie("Glass", "Buena Vista International", "PG13");
            Movie spiderMan = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures", "PG");

            Movie[] movies = { casionRoyale, glass, spiderMan };
            Movie[] pgMovie = Movie.GetPG(movies);

            Console.WriteLine("Movies with PG rating:");

            foreach (Movie movie in pgMovie)
            {
                Console.WriteLine(movie._title);
            }
        }
    }
}
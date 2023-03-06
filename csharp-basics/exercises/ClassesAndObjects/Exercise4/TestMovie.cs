using System;

namespace Exercise4
{
    internal class TestMovie
    {
        static void Main(string[] args)
        {
            var casionRoyale = new Movie("Casino Royale", "Eon Productions", "PG13");
            var glass = new Movie("Glass", "Buena Vista International", "PG13");
            var spiderMan = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures", "PG");

            Movie[] movies = { casionRoyale, glass, spiderMan };
            var pgMovie = Movie.GetPG(movies);

            Console.WriteLine("Movies with PG rating:");

            foreach (var movie in pgMovie)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
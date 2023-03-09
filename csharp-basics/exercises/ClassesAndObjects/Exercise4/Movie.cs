using System.Reflection;

namespace Exercise4
{
    class Movie
    {
        public string Title;
        private string _studio;
        private string _rating;

        public Movie(string title, string studio, string rating)
        {
            Title = title;
            _studio = studio;
            _rating = rating;
        }

        public Movie(string title, string studio)
        {
            Title = title;
            _studio = studio;
            _rating = "PG";
        }

        public static Movie[] GetPG(Movie[] movies)
        {
            var newMoviesArr = new List<Movie>();

            foreach (var movie in movies)
            {
                if (movie._rating == "PG")
                {
                    newMoviesArr.Add(movie);
                }
            }

            return newMoviesArr.ToArray();
        }
    }
}


using System.Reflection;

namespace Exercise4
{
    class Movie
    {
        public string _title;
        private string _studio;
        private string _rating;

        public Movie(string title, string studio, string rating)
        {
            _title = title;
            _studio = studio;
            _rating = rating;
        }

        public Movie(string title, string studio)
        {
            _title = title;
            _studio = studio;
            _rating = "PG";
        }

        public static Movie[] GetPG(Movie[] movies)
        {
            List<Movie> newMoviesArr = new List<Movie>();

            foreach (Movie movie in movies)
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


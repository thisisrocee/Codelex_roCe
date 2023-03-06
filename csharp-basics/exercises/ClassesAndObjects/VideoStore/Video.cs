using System.Collections.Generic;

namespace VideoStore
{
    class Video
    {
        public string Title { get; }
        public bool Availability { get; set; }
        public double AverageRating { get; private set; }
        public int AllRatings { get; private set; }

        public Video(string title)
        {
            Title = title;
            Availability = true;
            AverageRating = 0.0;
            AllRatings = 0;
        }

        public void ReceivingRating(double rating)
        {
            AverageRating = (AverageRating * AllRatings + rating) / (AllRatings + 1);
            AllRatings++;
        }

        public override string ToString()
        {
            return $"{Title} {AverageRating:F1} {(Availability ? "" : "Checked out!")}";
        }
    }
}

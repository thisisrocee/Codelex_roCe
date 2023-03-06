using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        private List<Video> _videos = new List<Video>();

        public void AddVideo(string title)
        {
            _videos.Add(new Video(title));
        }

        public void Checkout(string title)
        {
            var video = _videos.Find(v => v.Title == title);

            if (video == null)
            {
                Console.WriteLine("Video not found.");
                return;
            }

            if (!video.Availability)
            {
                Console.WriteLine("Video is already checked out.");
                return;
            }

            video.Availability = false;
            Console.WriteLine("Video checked out successfully.");
        }

        public void ReturnVideo(string title)
        {
            var video = _videos.Find(v => v.Title == title);

            if (video == null)
            {
                Console.WriteLine("Video not found.");
                return;
            }

            if (video.Availability)
            {
                Console.WriteLine("Video is not checked out.");
                return;
            }

            video.Availability = true;
            Console.WriteLine("Video returned successfully.");
        }

        public void TakeUsersRating(double rating, string title)
        {
            var video = _videos.Find(v => v.Title == title);

            if (video == null)
            {
                Console.WriteLine("Video not found.");
                return;
            }

            video.ReceivingRating(rating);
            Console.WriteLine($"Rating of {rating} added to {title}");
        }

        public void ListInventory()
        {
            foreach (var video in _videos)
            {
                Console.WriteLine(video);
            }
        }
    }
}

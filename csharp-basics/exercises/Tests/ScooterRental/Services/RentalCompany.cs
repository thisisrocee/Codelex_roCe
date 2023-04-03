using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using ScooterRental.Models;

namespace ScooterRental.Services
{
    public class RentalCompany : IRentalCompany
    {
        private readonly IScooterService _scooterService;
        public string Name { get; }
        private readonly List<Scooter> _scooters;
        private decimal _result;

        public RentalCompany(string name, IScooterService scooterService, List<Scooter> scooter)
        {
            Name = name;
            _scooterService = scooterService;
            _scooters = scooter;
        }

        public void StartRent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            var scooter = _scooterService.GetScooterById(id) ?? throw new ScooterNotFoundException();

            if (scooter.StartDate.Date == scooter.EndDate.Date)
            {
                throw new LimitExceededException();
            }

            scooter.IsRented = true;
        }

        public decimal EndRent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            var scooter = _scooterService.GetScooterById(id) ?? throw new ScooterNotFoundException();
            scooter.IsRented = false;

            var result = 0m;

            var daySplittedList = SplitDateTime(scooter.StartDate, scooter.EndDate);

            foreach (var day in daySplittedList)
            {
                var total = (decimal)day.TotalMinutes;

                if (total > 20)
                {
                    result += 20;
                    continue;
                }

                result += total * scooter.PricePerMinute;
            }

            return result;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            if (_scooters.Count == 0)
            {
                throw new ScooterNotFoundException();
            }

            if (year < 0)
            {
                throw new InvalidYearException();
            }

            if (year.HasValue && includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => x.StartDate.Year == year).ToList();

                if (scoot.Count == 0)
                {
                    return 0m;
                }

                CalculateDifference(scoot);
            }
            else if (year.HasValue && !includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => x.StartDate.Year == year && !x.IsRented).ToList();

                if (scoot.Count == 0)
                {
                    return 0m;
                }

                CalculateDifference(scoot);
            }
            else if (!year.HasValue && !includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => !x.IsRented).ToList();

                CalculateDifference(scoot);
            }
            else
            {
                CalculateDifference(_scooters);
            }

            return _result;
        }

        private void CalculateDifference(List<Scooter> scoot)
        {
            foreach (var s in scoot)
            {
                s.EndDate = s.StartDate.AddMinutes(15);

                var difference = s.EndDate - s.StartDate;
                _result += (decimal)difference.TotalMinutes * s.PricePerMinute;
            }
        }

        private static List<TimeSpan> SplitDateTime(DateTime start, DateTime end)
        {
            var timeSpans = new List<TimeSpan>();

            if (end.Date == start.Date)
            {
                timeSpans.Add(end - start);
                return timeSpans;
            }

            timeSpans.Add(start.Date.AddDays(1) - start);
            timeSpans.Add(end - end.Date);

            var currentDay = start.Date.AddDays(1);

            if (end.Date == currentDay || end.Date < currentDay)
            {
                return timeSpans;
            }

            while (currentDay < end.Date)
            {
                timeSpans.Add(currentDay.Date.AddDays(1) - currentDay);

                currentDay = currentDay.AddDays(1);
            }

            return timeSpans;
        }
    }
}
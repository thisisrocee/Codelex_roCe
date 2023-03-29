using System.ComponentModel;

namespace ScooterRental
{
    public class RentalCompany : IRentalCompany
    {
        private readonly IScooterService _scooterService;
        public string Name { get; }
        private List<Scooter> _scooters;

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

            var scooter = _scooterService.GetScooterById(id);

            if (scooter == null)
            {
                throw new ScooterNotFoundException();
            }

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

            var scooter = _scooterService.GetScooterById(id);

            if (scooter == null)
            {
                throw new ScooterNotFoundException();
            }

            scooter.IsRented = false;

            var difference = scooter.EndDate - scooter.StartDate;
            var result = (decimal)difference.TotalMinutes * scooter.PricePerMinute;

            if (result > 20)
            {
                result = 20;
                scooter.StartDate = scooter.StartDate.AddDays(1);
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

            var res = 0m;

            if (year.HasValue && includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => x.StartDate.Year == year).ToList();

                if (scoot.Count == 0)
                {
                    throw new ScootersNotFoundByGivenYearException();
                }

                foreach (var s in scoot)
                {
                    s.EndDate = s.StartDate.AddMinutes(15);

                    var difference = s.EndDate - s.StartDate;
                    res += (decimal)difference.TotalMinutes * s.PricePerMinute;
                }
            }
            else if (year.HasValue && !includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => x.StartDate.Year == year && !x.IsRented).ToList();

                if (scoot.Count == 0)
                {
                    throw new ScootersNotFoundByGivenYearException();
                }

                foreach (var s in scoot)
                {
                    s.EndDate = s.StartDate.AddMinutes(15);

                    var difference = s.EndDate - s.StartDate;
                    res += (decimal)difference.TotalMinutes * s.PricePerMinute;
                }
            }
            else if (!year.HasValue && !includeNotCompletedRentals)
            {
                var scoot = _scooters.Where(x => !x.IsRented).ToList();

                foreach (var s in scoot)
                {
                    s.EndDate = s.StartDate.AddMinutes(15);

                    var difference = s.EndDate - s.StartDate;
                    res += (decimal)difference.TotalMinutes * s.PricePerMinute;
                }
            }
            else
            {
                foreach (var s in _scooters)
                {
                    s.EndDate = s.StartDate.AddMinutes(15);

                    var difference = s.EndDate - s.StartDate;
                    res += (decimal)difference.TotalMinutes * s.PricePerMinute;
                }
            }

            return res;
        }
    }
}
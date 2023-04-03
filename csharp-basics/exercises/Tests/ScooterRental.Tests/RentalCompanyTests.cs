using FluentAssertions;
using Moq.AutoMock;
using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using ScooterRental.Models;
using ScooterRental.Services;

namespace ScooterRental.Tests
{
    public class RentalCompanyTests
    {
        private IRentalCompany _rentalCompany;
        private AutoMocker _mocker;
        private List<Scooter> _scooter;
        private Scooter _testScooter1;
        private Scooter _testScooter2;
        private Scooter _testScooter3;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _scooter = new List<Scooter>();
            _rentalCompany = new RentalCompany("Bolt", _mocker.GetMock<IScooterService>().Object, _scooter);
            _testScooter1 = new Scooter("1", 1m);
            _testScooter2 = new Scooter("2", 1m);
            _testScooter3 = new Scooter("3", 1m);
        }

        private void GetScooter(Scooter scooter)
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);
        }

        [Test]
        public void Name_CompanyNameReturned()
        {
            _rentalCompany.Name.Should().Be("Bolt");
        }

        [Test]
        public void StartRent_ValidIdProvided_ScooterIsRented()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);

            _testScooter1.IsRented.Should().BeTrue();
        }

        [Test]
        public void StartRent_EmptyIdProvided_ThrowsInvalidIdException()
        {
            Action act = () => _rentalCompany.StartRent("");

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void StartRent_NullIdProvided_ThrowsInvalidIdException()
        {
            Action act = () => _rentalCompany.StartRent(null);

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void StartRent_NonExistingIdProvided_ThrowsScooterNotFoundException()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.AddScooter("1", 1m));

            Action act = () => _rentalCompany.StartRent("2");

            act.Should().Throw<ScooterNotFoundException>();
        }

        [Test]
        public void StartRent_ValidIdProvidedButLimitExceededAndTriedSameDay_ThrowsSameDayRentingException()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);

            _testScooter1.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(_testScooter1.Id).Should().Be(20m);
            _testScooter1.IsRented.Should().BeFalse();

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 11,0, 0);

            Action act = () => _rentalCompany.StartRent(_testScooter1.Id);

            act.Should().Throw<LimitExceededException>();
        }

        [Test]
        public void StartRent_ValidIdProvidedButLimitExceededAndTriedOtherDay_ThrowsSameDayRentingException()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter1.IsRented.Should().BeTrue();

            _testScooter1.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(_testScooter1.Id).Should().Be(20m);
            _testScooter1.IsRented.Should().BeFalse();

            _testScooter1.StartDate = new DateTime(2023, 2, 21, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);

            _testScooter1.IsRented.Should().BeTrue();
        }

        [Test]
        public void EndRent_ValidIdAndMinutesRentedProvided_ScooterRentEnded()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 23, 30, 0);
            _rentalCompany.StartRent(_testScooter1.Id);

            _testScooter1.EndDate = new DateTime(2023, 2, 22, 0, 20, 0);
            _rentalCompany.EndRent(_testScooter1.Id).Should().Be(60m);

            _testScooter1.IsRented.Should().BeFalse();
        }

        [Test]
        public void EndRent_ValidIdProvidedAndLimitExceeded_ScooterRentEndedButStoppedAtLimit()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(_testScooter1.Id)).Returns(_testScooter1);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);

            _testScooter1.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(_testScooter1.Id).Should().Be(20m);

            _testScooter1.IsRented.Should().BeFalse();
        }

        [Test]
        public void EndRent_EmptyIdProvided_ThrowsInvalidIdException()
        {
            Action act = () => _rentalCompany.EndRent("");

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void EndRent_NullIdProvided_ThrowsInvalidIdException()
        {
            Action act = () => _rentalCompany.EndRent(null);

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void EndRent_NonExistingIdProvided_ThrowsScooterNotFoundException()
        {
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.AddScooter("1", 1m));

            Action act = () => _rentalCompany.EndRent("2");

            act.Should().Throw<ScooterNotFoundException>();
        }

        [Test]
        public void CalculateIncome_NegativeYearProvidedAndNonCompletedRentalsNotIncluded_ThrowsInvalidYearException()
        {
            _scooter.Add(_testScooter1);
            Action act = () => _rentalCompany.CalculateIncome(-1, false);

            act.Should().Throw<InvalidYearException>();
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsNotIncluded_ReturnsTotalIncome()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2023, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2023, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);

            _rentalCompany.EndRent(_testScooter1.Id);
            _rentalCompany.EndRent(_testScooter2.Id);
            _rentalCompany.EndRent(_testScooter3.Id);

            _rentalCompany.CalculateIncome(2023, false).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsIncluded_ReturnsTotalIncome()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);

            _rentalCompany.CalculateIncome(2023, true).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndCompletedRentalsNotIncluded_ReturnsTotalIncome()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2021, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);

            _rentalCompany.EndRent(_testScooter1.Id);
            _rentalCompany.EndRent(_testScooter2.Id);
            _rentalCompany.EndRent(_testScooter3.Id);

            _rentalCompany.CalculateIncome(null, false).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndNonCompletedRentalsIncluded_ReturnsTotalIncome()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2021, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);

            _rentalCompany.CalculateIncome(null, true).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsIncludedButNoExactYearRecord_ThrowsNoScooterByGivenYearException()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2022, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2022, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);

            _rentalCompany.CalculateIncome(2023, true).Should().Be(0m);
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsNotIncludedButNoExactYearRecord_ThrowsNoScooterByGivenYearException()
        {
            _scooter.Add(_testScooter1);
            _scooter.Add(_testScooter2);
            _scooter.Add(_testScooter3);

            GetScooter(_testScooter1);
            GetScooter(_testScooter2);
            GetScooter(_testScooter3);

            _testScooter1.StartDate = new DateTime(2022, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(_testScooter1.Id);
            _testScooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(_testScooter2.Id);
            _testScooter3.StartDate = new DateTime(2022, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(_testScooter3.Id);
            
            _rentalCompany.CalculateIncome(2023, false).Should().Be(0m);
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndNonCompletedRentalsNotIncludedAndNoRentalsProvided_ThrowsScootersNotFoundException()
        {
            Action act = () => _rentalCompany.CalculateIncome(null, false);

            act.Should().Throw<ScooterNotFoundException>();
        }
    }
}
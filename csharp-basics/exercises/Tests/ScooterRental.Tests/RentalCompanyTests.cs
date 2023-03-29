using FluentAssertions;
using Moq.AutoMock;

namespace ScooterRental.Tests
{
    public class RentalCompanyTests
    {
        private IRentalCompany _rentalCompany;
        private AutoMocker _mocker;
        private List<Scooter> _scooter;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _scooter = new List<Scooter>();
            _rentalCompany = new RentalCompany("Bolt", _mocker.GetMock<IScooterService>().Object, _scooter);
        }

        [Test]
        public void Name_CompanyNameReturned()
        {
            _rentalCompany.Name.Should().Be("Bolt");
        }

        [Test]
        public void StartRent_ValidIdProvided_ScooterIsRented()
        {
            var scooter = new Scooter("1", 1m);
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById("1")).Returns(scooter);

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent("1");

            scooter.IsRented.Should().BeTrue();
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
        public void StartRent_ValidIdProvidedAndLimitExceededAndTriedSameDay_ThrowsSameDayRentingException()
        {
            var scooter = new Scooter("1", 1m);
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById("1")).Returns(scooter);

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent("1");

            scooter.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(scooter.Id).Should().Be(20m);
            scooter.IsRented.Should().BeFalse();

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            Action act = () => _rentalCompany.StartRent("1");

            act.Should().Throw<LimitExceededException>();
        }

        [Test]
        public void StartRent_ValidIdProvidedAndLimitExceededAndTriedOtherDay_ThrowsSameDayRentingException()
        {
            var scooter = new Scooter("1", 1m);
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById("1")).Returns(scooter);

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent("1");
            scooter.IsRented.Should().BeTrue();

            scooter.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(scooter.Id).Should().Be(20m);
            scooter.IsRented.Should().BeFalse();

            scooter.StartDate = new DateTime(2023, 2, 21, 10, 0, 0);
            _rentalCompany.StartRent("1");

            scooter.IsRented.Should().BeTrue();
        }

        [Test]
        public void EndRent_ValidIdAndMinutesRentedProvided_ScooterRentEnded()
        {
            var scooter = new Scooter("1", 1m);
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById("1")).Returns(scooter);

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent("1");

            scooter.EndDate = new DateTime(2023, 2, 20, 10, 15, 0);
            _rentalCompany.EndRent("1").Should().Be(15m);

            scooter.IsRented.Should().BeFalse();
        }

        [Test]
        public void EndRent_ValidIdProvidedAndLimitExceeded_ScooterRentEndedButStoppedAtLimit()
        {
            var scooter = new Scooter("1", 1m);
            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById("1")).Returns(scooter);

            scooter.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent("1");

            scooter.EndDate = new DateTime(2023, 2, 20, 10, 30, 0);
            _rentalCompany.EndRent(scooter.Id).Should().Be(20m);

            scooter.IsRented.Should().BeFalse();
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
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            Action act = () => _rentalCompany.CalculateIncome(-1, false);

            act.Should().Throw<InvalidYearException>();
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsNotIncluded_ReturnsTotalIncome()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2023, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2023, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            _rentalCompany.EndRent(scooter1.Id);
            _rentalCompany.EndRent(scooter2.Id);
            _rentalCompany.EndRent(scooter3.Id);

            _rentalCompany.CalculateIncome(2023, false).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsIncluded_ReturnsTotalIncome()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            _rentalCompany.CalculateIncome(2023, true).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndCompletedRentalsNotIncluded_ReturnsTotalIncome()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2021, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            _rentalCompany.EndRent(scooter1.Id);
            _rentalCompany.EndRent(scooter2.Id);
            _rentalCompany.EndRent(scooter3.Id);

            _rentalCompany.CalculateIncome(null, false).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndNonCompletedRentalsIncluded_ReturnsTotalIncome()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2023, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2021, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            _rentalCompany.CalculateIncome(null, true).Should().Be(45m);
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsIncludedButNoExactYearRecord_ThrowsNoScooterByGivenYearException()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2022, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2022, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            Action act = () => _rentalCompany.CalculateIncome(2023, true);

            act.Should().Throw<ScootersNotFoundByGivenYearException>();
        }

        [Test]
        public void CalculateIncome_YearProvidedAndNonCompletedRentalsNotIncludedButNoExactYearRecord_ThrowsNoScooterByGivenYearException()
        {
            var scooter1 = new Scooter("1", 1m);
            _scooter.Add(scooter1);
            var scooter2 = new Scooter("2", 1m);
            _scooter.Add(scooter2);
            var scooter3 = new Scooter("3", 1m);
            _scooter.Add(scooter3);

            var mock = _mocker.GetMock<IScooterService>();
            mock.Setup(x => x.GetScooterById(scooter1.Id)).Returns(scooter1);
            mock.Setup(x => x.GetScooterById(scooter2.Id)).Returns(scooter2);
            mock.Setup(x => x.GetScooterById(scooter3.Id)).Returns(scooter3);

            scooter1.StartDate = new DateTime(2022, 2, 20, 10, 0, 0);
            _rentalCompany.StartRent(scooter1.Id);
            scooter2.StartDate = new DateTime(2022, 2, 20, 11, 0, 0);
            _rentalCompany.StartRent(scooter2.Id);
            scooter3.StartDate = new DateTime(2022, 2, 20, 12, 0, 0);
            _rentalCompany.StartRent(scooter3.Id);

            Action act = () => _rentalCompany.CalculateIncome(2023, false);

            act.Should().Throw<ScootersNotFoundByGivenYearException>();
        }

        [Test]
        public void CalculateIncome_YearNotProvidedAndNonCompletedRentalsNotIncludedAndNoRentalsProvided_ThrowsScootersNotFoundException()
        {
            Action act = () => _rentalCompany.CalculateIncome(null, false);

            act.Should().Throw<ScooterNotFoundException>();
        }
    }
}
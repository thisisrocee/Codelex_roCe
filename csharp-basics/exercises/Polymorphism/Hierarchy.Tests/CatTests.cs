using FluentAssertions;

namespace Hierarchy.Tests;

public class CatTests
{
    private Cat _cat;
    private const string _testType = "testType";
    private const string _testName = "testName";
    private const double _testWeight = 1.0;
    private const string _livingRegion = "livingRegion";
    private const string _foodType = "Vegetable";

    [SetUp]
    public void Setup()
    {
        _cat = new Cat(_testType, _testName, _testWeight, _livingRegion, "Syam");
    }

    [Test]
    public void Eat_CorrectFoodProvided_SetsQuantity()
    {
        _cat.Eat(new Vegetable(1));

        _cat.FoodEaten.Should().Be(1);
    }
    
    [Test]
    public void ToString_ReturnsString()
    {
        _cat.ToString().Should().Be($"{_cat.AnimalType}[{_cat.AnimalName}, {_cat._breed}, " +
                                    $"{_cat.AnimalWeight}, {_cat.LivingRegion}, {_cat.FoodEaten}]");
    }
    
    [Test]
    public void CanEat_CorrectFoodTypeProvided_ReturnsTrue()
    {
        _cat.CanEat(_foodType).Should().BeTrue();
    }

    [Test]
    public void CanEat_EmptyFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _cat.CanEat("");

        act.Should().Throw<InvalidFoodNameException>();
    }
    
    [Test]
    public void CanEat_NullFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _cat.CanEat(null);

        act.Should().Throw<InvalidFoodNameException>();
    }
}
using FluentAssertions;

namespace Hierarchy.Tests;

public class ZebraTests
{
    private Zebra _zebra;
    private const string _testType = "testType";
    private const string _testName = "testName";
    private const double _testWeight = 1.0;
    private const string _livingRegion = "livingRegion";
    private const string _foodType = "Vegetable";
    private const string _incorrectFoodType = "Meat";

    [SetUp]
    public void Setup()
    {
        _zebra = new Zebra(_testType, _testName, _testWeight, _livingRegion);
    }

    [Test]
    public void Eat_CorrectFoodProvided_SetsQuantity()
    {
        _zebra.Eat(new Vegetable(1));

        _zebra.FoodEaten.Should().Be(1);
    }
    
    [Test]
    public void ToString_ReturnsString()
    {
        _zebra.ToString().Should().Be($"{_zebra.AnimalType}[{_zebra.AnimalName}, " +
                                      $"{_zebra.AnimalWeight}, {_zebra.LivingRegion}, " +
                                      $"{_zebra.FoodEaten}]");
    }
    
    [Test]
    public void CanEat_CorrectFoodTypeProvided_ReturnsTrue()
    {
        _zebra.CanEat(_foodType).Should().BeTrue();
    }
    
    [Test]
    public void CanEat_IncorrectFoodTypeProvided_ThrowsIncorrectFoodException()
    {
        Action act = () => _zebra.CanEat(_incorrectFoodType);

        act.Should().Throw<IncorrectFoodException>();
    }
    
    [Test]
    public void CanEat_EmptyFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _zebra.CanEat("");

        act.Should().Throw<InvalidFoodNameException>();
    }
    
    [Test]
    public void CanEat_NullFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _zebra.CanEat(null);

        act.Should().Throw<InvalidFoodNameException>();
    }
}
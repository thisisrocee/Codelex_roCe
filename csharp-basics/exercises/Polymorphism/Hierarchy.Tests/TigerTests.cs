using FluentAssertions;

namespace Hierarchy.Tests;

public class TigerTests
{
    private Tiger _tiger;
    private const string _testType = "testType";
    private const string _testName = "testName";
    private const double _testWeight = 1.0;
    private const string _livingRegion = "livingRegion";
    private const string _foodType = "Meat";
    private const string _incorrectFoodType = "Vegetable";

    [SetUp]
    public void Setup()
    {
        _tiger = new Tiger(_testType, _testName, _testWeight, _livingRegion);
    }

    [Test]
    public void Eat_CorrectFoodProvided_SetsQuantity()
    {
        _tiger.Eat(new Vegetable(1));

        _tiger.FoodEaten.Should().Be(1);
    }
    
    [Test]
    public void ToString_ReturnsString()
    {
        _tiger.ToString().Should().Be($"{_tiger.AnimalType}[{_tiger.AnimalName}, " +
                                      $"{_tiger.AnimalWeight}, {_tiger.LivingRegion}, " +
                                      $"{_tiger.FoodEaten}]");
    }
    
    [Test]
    public void CanEat_CorrectFoodTypeProvided_ReturnsTrue()
    {
        _tiger.CanEat(_foodType).Should().BeTrue();
    }
    
    [Test]
    public void CanEat_IncorrectFoodTypeProvided_ThrowsIncorrectFoodException()
    {
        Action act = () => _tiger.CanEat(_incorrectFoodType);

        act.Should().Throw<IncorrectFoodException>();
    }
    
    [Test]
    public void CanEat_EmptyFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _tiger.CanEat("");

        act.Should().Throw<InvalidFoodNameException>();
    }
    
    [Test]
    public void CanEat_NullFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _tiger.CanEat(null);

        act.Should().Throw<InvalidFoodNameException>();
    }
}
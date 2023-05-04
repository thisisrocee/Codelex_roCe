using FluentAssertions;

namespace Hierarchy.Tests;

public class MouseTests
{
    private Mouse _mouse;
    private const string _testType = "testType";
    private const string _testName = "testName";
    private const double _testWeight = 1.0;
    private const string _livingRegion = "livingRegion";
    private const string _foodType = "Vegetable";
    private const string _incorrectFoodType = "Meat";

    [SetUp]
    public void Setup()
    {
        _mouse = new Mouse(_testType, _testName, _testWeight, _livingRegion);
    }

    [Test]
    public void Eat_CorrectFoodProvided_SetsQuantity()
    {
        _mouse.Eat(new Vegetable(1));

        _mouse.FoodEaten.Should().Be(1);
    }
    
    [Test]
    public void ToString_ReturnsString()
    {
        _mouse.ToString().Should().Be($"{_mouse.AnimalType}[{_mouse.AnimalName}, " +
                                      $"{_mouse.AnimalWeight}, {_mouse.LivingRegion}, " +
                                      $"{_mouse.FoodEaten}]");
    }
    
    [Test]
    public void CanEat_CorrectFoodTypeProvided_ReturnsTrue()
    {
        _mouse.CanEat(_foodType).Should().BeTrue();
    }
    
    [Test]
    public void CanEat_IncorrectFoodTypeProvided_ThrowsIncorrectFoodException()
    {
        Action act = () => _mouse.CanEat(_incorrectFoodType);

        act.Should().Throw<IncorrectFoodException>();
    }
    
    [Test]
    public void CanEat_EmptyFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _mouse.CanEat("");

        act.Should().Throw<InvalidFoodNameException>();
    }
    
    [Test]
    public void CanEat_NullFoodTypeProvided_ThrowsInvalidFoodNameException()
    {
        Action act = () => _mouse.CanEat(null);

        act.Should().Throw<InvalidFoodNameException>();
    }
}
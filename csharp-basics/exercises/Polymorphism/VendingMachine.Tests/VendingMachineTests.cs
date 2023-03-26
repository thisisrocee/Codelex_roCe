using FluentAssertions;

namespace VendingMachine.Tests;

public class VendingMachineTests
{
    private IVendingMachine _vendingMachine;
    private const string companyName = "yoyo";

    [SetUp]
    public void Setup()
    {
        _vendingMachine = new VendingMachine(companyName);
    }

    [Test]
    public void Manufacturer_ValidNameProvided_ReturnsCompanyNameString()
    {
        _vendingMachine.Manufacturer.Should().Be(companyName);
    }

    [Test]
    public void HasProducts_ProvidedProductsAvailable_ReturnsTrue()
    {
        _vendingMachine.AddProduct("Soda", new Money { Euros = 1, Cents = 50 }, 0);
        _vendingMachine.AddProduct("Chips", new Money { Euros = 1, Cents = 0 }, 3);

        var hasProducts = _vendingMachine.HasProducts;

        hasProducts.Should().BeTrue();
    }

    [Test]
    public void HasProducts_ProvidedProductsEmpty_ReturnsFalse()
    {
        _vendingMachine.AddProduct("Soda", new Money { Euros = 1, Cents = 50 }, 0);
        _vendingMachine.AddProduct("Chips", new Money { Euros = 1, Cents = 0 }, 0);

        var hasProducts = _vendingMachine.HasProducts;

        hasProducts.Should().BeFalse();
    }

    [Test]
    public void Amount_ReturnsAmount()
    {
        _vendingMachine.Amount.Should().Be(new Money { Euros = 0, Cents = 0 });
    }

    [Test]
    public void Products_ReturnsEmptyArray()
    {
        _vendingMachine.Products.Length.Should().Be(0);
    }

    [Test]
    public void Constructor_ShouldInitializeProperties()
    {
        _vendingMachine.Manufacturer.Should().Be(companyName);
        _vendingMachine.HasProducts.Should().BeFalse();
        _vendingMachine.Amount.Should().Be(new Money { Euros = 0, Cents = 0 });
        _vendingMachine.Products.Should().BeEmpty();
    }

    [Test]
    public void InsertCoin_ValidCoinProvided_ReturnedAmount()
    {
        var coin = new Money { Euros = 1, Cents = 50 };

        var result = _vendingMachine.InsertCoin(coin);

        result.Should().Be(new Money { Euros = 1, Cents = 50 });
        _vendingMachine.Amount.Should().Be(new Money { Euros = 1, Cents = 50 });
    }

    [Test]
    public void InsertCoin_InvalidCoinProvided_ThrowsInvalidCoinException()
    {
        var coin = new Money { Euros = 5, Cents = 60 };

        Action act = () => _vendingMachine.InsertCoin(coin);

        act.Should().Throw<InvalidCoinException>();
    }

    [Test]
    public void InsertCoin_InvalidCoinWithNegativeProvided_ThrowsInvalidCoinException()
    {
        var coin = new Money { Euros = -5, Cents = -60 };

        Action act = () => _vendingMachine.InsertCoin(coin);

        act.Should().Throw<InvalidCoinException>();
    }

    [Test]
    public void ReturnMoney_ReturnsAmount()
    {
        var result = _vendingMachine.ReturnMoney();

        result.Should().Be(new Money { Euros = 0, Cents = 0 });
        _vendingMachine.Amount.Should().Be(new Money { Euros = 0, Cents = 0 });
    }

    [Test]
    public void AddProduct_ValidProductProvided_ProductAddedToList()
    {
        var result = _vendingMachine.AddProduct("Test", new Money { Euros = 1, Cents = 0 }, 2);

        result.Should().BeTrue();
        _vendingMachine.Products.Should().HaveCount(1);
        _vendingMachine.Products[0].Name.Should().Be("Test");
        _vendingMachine.Products[0].Price.Should().Be(new Money { Euros = 1, Cents = 0 });
        _vendingMachine.Products[0].Available.Should().Be(2);
    }

    [Test]
    public void AddProduct_DuplicateProductNameProvided_ThrowsDuplicateProductExecption()
    {
        _vendingMachine.AddProduct("Test", new Money { Euros = 1, Cents = 0 }, 2);

        Action act = () => _vendingMachine.AddProduct("Test", new Money { Euros = 2, Cents = 20 }, 3);

        act.Should().Throw<DuplicateProductExecption>();
    }

    [Test]
    public void AddProduct_NullProductNameProvided_ThrowsInvalidNameExecption()
    {
        Action act = () => _vendingMachine.AddProduct(null, new Money { Euros = 2, Cents = 20 }, 3);

        act.Should().Throw<InvalidNameExecption>();
    }

    [Test]
    public void AddProduct_EmptyProductNameProvided_ThrowsInvalidNameExecption()
    {
        Action act = () => _vendingMachine.AddProduct("", new Money { Euros = 2, Cents = 20 }, 3);

        act.Should().Throw<InvalidNameExecption>();
    }

    [Test]
    public void AddProduct_InvalidProductPriceProvided_ThrowsInvalidCoinException()
    {
        Action act = () => _vendingMachine.AddProduct("Test", new Money { Euros = -2, Cents = 60 }, 3);

        act.Should().Throw<InvalidCoinException>();
    }

    [Test]
    public void AddProduct_NegativeProductAmountProvided_ThrowsAmountException()
    {
        Action act = () => _vendingMachine.AddProduct("Test", new Money { Euros = 1, Cents = 50 }, -3);

        act.Should().Throw<InvalidAmountException>();
    }

    [Test]
    public void UpdateProduct_ValidProductNumberAndProductProvided_ProductUpdated()
    {
        var price = new Money { Euros = 1, Cents = 50 };

        _vendingMachine.AddProduct("Test", price, 3);
        _vendingMachine.InsertCoin(price);

        var result = _vendingMachine.UpdateProduct(1, "Test", null, 1);

        result.Should().BeTrue();
        _vendingMachine.Products[0].Available.Should().Be(2);
        _vendingMachine.Amount.Should().Be(new Money { Euros = 0, Cents = 0 });
    }

    [Test]
    public void UpdateProduct_InvalidProductNumberProvided_ThrowsProductNumberException()
    {
        Action act = () => _vendingMachine.UpdateProduct(0, "Test", null, 1);

        act.Should().Throw<InvalidProductNumberException>();
    }

    [Test]
    public void UpdateProduct_InvalidProductNumberProvided_ThrowsProductSoldOutException()
    {
        _vendingMachine.AddProduct("Test", new Money { Euros = 1, Cents = 50 }, 0);

        Action act = () => _vendingMachine.UpdateProduct(1, "Test", null, 1);

        act.Should().Throw<ProductSoldOutException>();
    }

    [Test]
    public void UpdateProduct_InsufficientFundsProvided_ThrowsInsufficientFundsException()
    {
        _vendingMachine.AddProduct("Test", new Money { Euros = 1, Cents = 50 }, 1);
        _vendingMachine.InsertCoin(new Money { Euros = 1, Cents = 0 });

        Action act = () => _vendingMachine.UpdateProduct(1, "Test", null, 1);

        act.Should().Throw<InsufficientFundsException>();
    }

    [Test]
    public void UpdateProduct_EmptyProductNameProvided_ThrowsInvalidNameException()
    {
        Action act = () => _vendingMachine.UpdateProduct(1, "", null, 1);

        act.Should().Throw<InvalidNameExecption>();
    }

    [Test]
    public void UpdateProduct_NullProductNameProvided_ThrowsInvalidNameException()
    {
        Action act = () => _vendingMachine.UpdateProduct(1, null, null, 1);

        act.Should().Throw<InvalidNameExecption>();
    }

    [Test]
    public void UpdateProduct_NegativeAmountProvided_ThrowsInvalidAmountException()
    {
        Action act = () => _vendingMachine.UpdateProduct(1, "Test", null, -1);

        act.Should().Throw<InvalidAmountException>();
    }
}
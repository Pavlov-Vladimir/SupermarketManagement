namespace SupermarketManagement.Tests.ProductsUseCases;
public class SellProductUseCaseTests : TestProductUseCaseBase
{
	private readonly SellProductUseCase _sut;

	public SellProductUseCaseTests()
	{
		_sut = new SellProductUseCase(productRepository);

	}

	[Theory]
	[InlineData(0)]
	[InlineData(1)]
    [InlineData(11)]
	[InlineData(22)]
    public void SellProductUseCase_SuccessIfQtyIsPositive(int qtyToSell)
	{
		//Arrange
		int quantityToSell = qtyToSell;
		int productId = MarketContextFactory.PRODUCT_ID_FOR_UPDATE;
        var expected = dbContext.Products.Find(productId)!.Quantity;

		//Act
		_sut.Execute(productId, quantityToSell);
		var actual = dbContext.Products.Find(productId)!.Quantity;

        //Assert
		actual.Should().Be(expected - quantityToSell);
    }

	[Fact]
    public void SellProductUseCase_FailIfQtyIsNegative()
    {
        //Arrange
        const int quantityToSell = -1;
        int productId = MarketContextFactory.PRODUCT_ID_FOR_UPDATE;

        //Act        

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Execute(productId, quantityToSell));
    }

    [Fact]
    public void SellProductUseCase_DoNothingOnWrongProductId()
    {
        //Arrange
        const int quantityToSell = 1;
        int productId = MarketContextFactory.NOT_RELEVANT_ID;
        var expected = dbContext.Products.AsEnumerable();

        //Act
        _sut.Execute(productId, quantityToSell);
        var actual = dbContext.Products.AsEnumerable();

        //Assert
        actual.Should().BeSameAs(expected);
    }
}
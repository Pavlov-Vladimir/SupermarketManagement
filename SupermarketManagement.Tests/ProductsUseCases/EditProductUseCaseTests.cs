namespace SupermarketManagement.Tests.ProductsUseCases;
public class EditProductUseCaseTests : TestProductUseCaseBase
{
	private readonly EditProductUseCase _sut;

	public EditProductUseCaseTests()
	{
		_sut = new EditProductUseCase(productRepository);

    }

	[Fact]
	public void EditProductUseCase_Success()
	{
		//Arrange
		const int productId = MarketContextFactory.PRODUCT_ID_FOR_UPDATE;
		const string productName = "New Product Name";
        var category = dbContext.Products.First(p => p.Id == productId).Category;
		var expected = fixture.Build<Product>()
			.With(p => p.Id, productId)
			.With(p => p.Name, productName)
			.With(p => p.Category, category)
			.With(p => p.CategoryId, category.Id)
			.Create();

        //Act
		_sut.Execute(expected);
		var actual = dbContext.Products.FirstOrDefault(p => p.Id == productId && p.Name == productName);

        //Assert
		actual.Should().NotBeNull().And.BeEquivalentTo(expected);
		dbContext.Products.Should().HaveCount(4);
    }

    [Fact]
    public void EditProductUseCase_DoNothingIfProductIsNull()
    {
		//Arrange
		var expected = dbContext.Products.AsEnumerable();

        //Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        _sut.Execute(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        var actual = dbContext.Products.AsEnumerable();

        //Assert
        actual.Should().NotBeNull().And.BeEquivalentTo(expected).And.HaveCount(4);
    }

    [Fact]
    public void EditProductUseCase_DoNothingOnWrongProductId()
    {
        //Arrange
        const int productId = MarketContextFactory.NOT_RELEVANT_ID;
        const string productName = "New Product Name";
        var category = dbContext.Categories.First();
        var product = fixture.Build<Product>()
            .With(p => p.Id, productId)
            .With(p => p.Name, productName)
            .With(p => p.Category, category)
            .With(p => p.CategoryId, category.Id)
            .Create();
        var expected = dbContext.Products.AsEnumerable();

        //Act
        _sut.Execute(product);
        var actual = dbContext.Products.AsEnumerable();

        //Assert
        actual.Should().BeEquivalentTo(expected).And.HaveCount(4);
    }
}
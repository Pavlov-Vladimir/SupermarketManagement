namespace SupermarketManagement.Tests.ProductsUseCases;
public class AddProductUseCaseTests : TestProductUseCaseBase
{
    private readonly AddProductUseCase _sut;

    public AddProductUseCaseTests()
    {
        _sut = new AddProductUseCase(productRepository);
    }

    [Fact]
    public void AddProductUseCase_Success()
    {
        //Arrange
        const int productId = 5;
        var category = dbContext.Categories.Find(MarketContextFactory.CATEGORY_ID_FOR_UPDATE);
        var product = fixture.Build<Product>()
            .With(p => p.Id, productId)
            .With(p => p.CategoryId, category!.Id)
            .With(p => p.Category, category)
            .Create();

        //Act
        _sut.Execute(product);

        //Assert
        dbContext.Products.Should().Contain(product).And.HaveCount(5);
        dbContext.Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Products
            .Should().Contain(product);
    }

    [Fact]
    public void AddProductUseCase_DoNothingIfProductIsNull()
    {
        //Arrange

        //Act
        _sut.Execute(null);

        //Assert
        dbContext.Products.Should().NotContainNulls().And.HaveCount(4);        
    }
}

namespace SupermarketManagement.Tests.ProductsUseCases;
public class DeleteProductUseCaseTests : TestProductUseCaseBase
{
    private readonly DeleteProductUseCase _sut;

    public DeleteProductUseCaseTests()
    {
        _sut = new DeleteProductUseCase(productRepository);
    }

    [Fact]
    public void DeleteProductUseCase_Success()
    {
        //Arrange
        var product = dbContext.Products.First(p => p.Id == MarketContextFactory.PRODUCT_ID_FOR_DELETE);
        var category = product.Category;

        //Act
        _sut.Execute(MarketContextFactory.PRODUCT_ID_FOR_DELETE);

        //Assert
        dbContext.Products.Should().HaveCount(3).And.NotContain(product);
        category.Products.Should().NotContainEquivalentOf(product);
    }

    [Fact]
    public void DeleteProductUseCase_DoNothongOnWrongId()
    {
        //Arrange
        var expected = dbContext.Products;

        //Act
        _sut.Execute(MarketContextFactory.NOT_RELEVANT_ID);
        var actual = dbContext.Products;

        //Assert
        actual.Should().BeEquivalentTo(expected).And.HaveCount(4);
    }
}

namespace SupermarketManagement.Tests.ProductsUseCases;
public class ViewProductsUseCaseTests : TestProductUseCaseBase
{
    [Fact]
    public void ViewProductsUseCase_Success()
    {
        //Arrange
        var expected = dbContext.Products.AsEnumerable();
        var sut = new ViewProductsUseCase(productRepository);

        //Act
        var actual = sut.Execute();

        //Assert
        actual.Should().BeEquivalentTo(expected)
            .And.NotBeNull();
    }
}

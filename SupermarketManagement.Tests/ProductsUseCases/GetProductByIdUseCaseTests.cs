namespace SupermarketManagement.Tests.ProductsUseCases;
public class GetProductByIdUseCaseTests : TestProductUseCaseBase
{
    private readonly GetProductByIdUseCase _sut;

    public GetProductByIdUseCaseTests()
    {
        _sut = new GetProductByIdUseCase(productRepository);
    }

    [Fact]
    public void GetProductByIdUseCase_Success()
    {
        //Arrange
        var expected = dbContext.Products.First();
        var productId = expected.Id;

        //Act
        var actual = _sut.Execute(productId);

        //Assert
        actual.Should().NotBeNull().And.BeEquivalentTo(expected);
    }

    [Fact]
    public void GetProductByIdUseCase_ReturNullOnWrongId()
    {
        //Arrange        
        const int NOT_RELEVANT_ID = 100;

        //Act
        var actual = _sut.Execute(NOT_RELEVANT_ID);

        //Assert
        actual.Should().BeNull();
    }
}

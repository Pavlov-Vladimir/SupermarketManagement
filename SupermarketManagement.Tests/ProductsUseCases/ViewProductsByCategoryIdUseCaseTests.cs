namespace SupermarketManagement.Tests.ProductsUseCases;
public class ViewProductsByCategoryIdUseCaseTests : TestProductUseCaseBase
{
    private readonly ViewProductsByCategoryIdUseCase _sut;

    public ViewProductsByCategoryIdUseCaseTests()
    {
        _sut = new ViewProductsByCategoryIdUseCase(productRepository);
    }

    [Fact]
    public void ViewProductsByCategoryIdUseCase_Success()
    {
        //Arrange
        var category = dbContext.Categories.First();
        var categoryId = category.Id;
        var expected = category.Products?.AsEnumerable();

        //Act
        var actual = _sut.Execute(categoryId);

        //Assert
        actual.Should().BeEquivalentTo(expected)
            .And.NotBeNull();
    }

    [Fact]
    public void ViewProductsByCategoryIdUseCase_ShouldReturnEmptyOnWrongId()
    {
        //Arrange
        const int NOT_RELEVANT_ID = 100;

        //Act
        var actual = _sut.Execute(NOT_RELEVANT_ID);

        //Assert
        actual.Should().BeEmpty();
    }
}

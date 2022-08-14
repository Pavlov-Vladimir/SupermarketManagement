namespace SupermarketManagement.Tests.CategoriesUseCases;
public class ViewCategoriesUseCaseTests : TestCategoryUseCaseBase
{
    [Fact]
    public void ViewCategoriesUseCase_Success()
    {
        //Arrange
        var expected = dbContext.Categories.AsEnumerable();
        var sut = new ViewCategoriesUseCase(categoryRepository);

        //Act
        var actual = sut.Execute();

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }
}

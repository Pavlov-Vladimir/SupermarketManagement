namespace SupermarketManagement.Tests.CategoriesUseCases;
public class GetCategoryByIdUseCaseTests : TestCategoryUseCaseBase
{
    [Fact]
    public void GetCategoryByIdUseCase_Success_if_categoryId_is_relevant()
    {
        //Arrange
        var expected = dbContext.Categories.First();
        var categoryId = expected.Id;
        var sut = new GetCategoryByIdUseCase(categoryRepository);

        //Act
        var actual = sut.Execute(categoryId);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GetCategoryByIdUseCase_Return_Null_if_categoryId_is_not_relevant()
    {
        //Arrange        
        var sut = new GetCategoryByIdUseCase(categoryRepository);

        //Act
        var actual = sut.Execute(100);

        //Assert
        actual.Should().BeNull();
    }
}

namespace SupermarketManagement.Tests.CategoriesUseCases;
public class DeleteCategoryUseCaseTests : TestCategoryUseCaseBase
{
    [Fact]
    public void DeleteCategoryUseCase_Succsess()
    {
        //Arrange
        DeleteCategoryUseCase sut = new(categoryRepository);
        int expected = dbContext.Categories.Count() - 1;
        int categoryId = MarketContextFactory.CATEGORY_ID_FOR_DELETE;
        var category = dbContext.Categories.Find(categoryId);

        //Act
        sut.Execute(categoryId);
        int actual = dbContext.Categories.Count();

        //Assert
        Assert.Equal(expected, actual);
        Assert.Null(dbContext.Categories.SingleOrDefault(category => 
            category.Id == categoryId));
    }

    [Fact]
    public void DeleteCategoryUseCase_Fail_if_category_has_products()
    {
        //Arrange
        DeleteCategoryUseCase sut = new(categoryRepository);
        int expected = dbContext.Categories.Count();
        var category = dbContext.Categories.First();
        int categoryId = category.Id;

        //Act
        sut.Execute(categoryId);
        int actual = dbContext.Categories.Count();

        //Assert
        actual.Should().Be(expected);
        category.Should().Be(dbContext.Categories.First());
    }

    [Fact]
    public void DeleteCategoryUseCase_Fail_if_category_not_exists()
    {
        //Arrange
        DeleteCategoryUseCase sut = new(categoryRepository);
        int expected = dbContext.Categories.Count();
        int categoryId = 100;

        //Act
        sut.Execute(categoryId);
        int actual = dbContext.Categories.Count();

        //Assert
        actual.Should().Be(expected);
    }
}

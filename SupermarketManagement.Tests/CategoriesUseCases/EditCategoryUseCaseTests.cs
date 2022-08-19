namespace SupermarketManagement.Tests.CategoriesUseCases;
public class EditCategoryUseCaseTests : TestCategoryUseCaseBase
{
    [Fact]
    public void EditCategoryUseCase_Success()
    {
        //Arrange
        EditCategoryUseCase sut = new(categoryRepository);
        const string categoryName = "New Category Name";
        const string categoryDescription = "New Category Description";
        var fixture = new Fixture();
        var category = fixture.Build<Category>()
            .With(c => c.Id, MarketContextFactory.CATEGORY_ID_FOR_UPDATE)
            .With(c => c.Name, categoryName)
            .With(c => c.Description, categoryDescription)
            .Without(c => c.Products)
            .Create();

        //Act
        sut.Execute(category);

        //Assert
        dbContext.Categories.Should().ContainEquivalentOf(category).And.HaveCount(3);
    }

    [Fact]
    public void EditCategoryUseCase_Fail_if_categoryId_is_not_exists()
    {
        //Arrange
        EditCategoryUseCase sut = new(categoryRepository);
        var fixture = new Fixture();
        var category = fixture.Build<Category>().With(c => c.Id, 100).Without(c => c.Products).Create();

        //Act
        sut.Execute(category);

        //Assert
        dbContext.Categories.Should().NotContainEquivalentOf(category);
    }

    [Fact]
    public void EditCategoryUseCase_Fail_if_category_is_null()
    {
        //Arrange
        EditCategoryUseCase sut = new(categoryRepository);

        //Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        sut.Execute(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        //Assert
        Assert.DoesNotContain(null, dbContext.Categories);
    }
}

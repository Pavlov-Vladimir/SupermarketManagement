namespace SupermarketManagement.Tests.CategoriesUseCases;
public class AddCategoryUseCaseTests : TestCategoryUseCaseBase
{
    [Fact]
    public void AddCategoryUseCase_Success()
    {
        //Arrange        
        string categoryName = "category name";
        string categoryDescription = "category description";
        const int categoryId = 4;
        var category = new Category { Id = categoryId, Name = categoryName, Description = categoryDescription };
        var sut = new AddCategoryUseCase(categoryRepository);

        //Act
        sut.Execute(category);

        //Assert
        Assert.NotNull(dbContext.Categories.SingleOrDefault(c => 
            c.Id == categoryId && c.Name == categoryName && c.Description == categoryDescription));
        Assert.Equal(4, dbContext.Categories.Count());
        Assert.Equal(category, dbContext.Categories.Find(categoryId));
    }
}

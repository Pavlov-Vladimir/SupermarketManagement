namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>?> GetCategories();
    Task AddCategory(Category category);
    Task UpdateCategory(Category category);
    Task<Category?> GetCategoryById(int categoryId);
}

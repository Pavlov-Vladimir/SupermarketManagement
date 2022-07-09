namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>?> GetCategories();
}

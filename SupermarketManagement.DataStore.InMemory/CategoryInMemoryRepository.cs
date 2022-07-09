namespace SupermarketManagement.DataStore.InMemory;
public class CategoryInMemoryRepository : ICategoryRepository
{
    private List<Category>? _categories;

    public CategoryInMemoryRepository()
    {
        _categories = new List<Category>
        {
            new Category{ Id = 1, Name = "Beverage", Description = "Beverage" },
            new Category{ Id = 2, Name = "Bakery", Description = "Bakery" },
            new Category{ Id = 3, Name = "Meat", Description = "Meat" },
        };
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        return await Task.FromResult(_categories);
    }
}

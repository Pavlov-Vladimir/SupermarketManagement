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

    public async Task AddCategory(Category category)
    {
        if (_categories is not null)
        {
            if (_categories.Any(c => c.Name.Equals(category.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            var maxId = _categories.Max(c => c.Id);
            category.Id = maxId;

            await Task.Run(() => _categories?.Add(category)); 
        }
        else
        {
            throw new Exception("Data Store does not exist.");
        }
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        return await Task.FromResult(_categories);
    }


}

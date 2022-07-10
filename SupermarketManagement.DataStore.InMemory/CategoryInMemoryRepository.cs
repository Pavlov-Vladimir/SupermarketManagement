using SupermarketManagement.Entities;

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
        try
        {
            if (_categories is not null)
            {
                if (_categories.Any(c => c.Name.Equals(category.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return;
                }

                if (_categories.Any())
                {
                    var maxId = _categories.Max(c => c.Id);
                    category.Id = maxId + 1;
                }
                else
                {
                    category.Id = 1;
                }

                await Task.Run(() => _categories.Add(category));
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(CategoryInMemoryRepository));
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task UpdateCategory(Category category)
    {
        try
        {
            if (_categories is not null)
            {
                var categoryToUpdate = _categories.SingleOrDefault(c => c.Id == category.Id);

                if (categoryToUpdate is null)
                {
                    throw new EntityNotFoundException(category.Name);
                }

                categoryToUpdate = category;
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(CategoryInMemoryRepository));
            }

            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        try
        {
            return await Task.FromResult(_categories);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        try
        {
            if (_categories is not null)
            {
                var category = _categories.SingleOrDefault(c => c.Id == categoryId);

                if (category is null)
                {
                    throw new EntityNotFoundException($"Id = {categoryId}");
                }

                return await Task.FromResult(category);
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(CategoryInMemoryRepository));
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

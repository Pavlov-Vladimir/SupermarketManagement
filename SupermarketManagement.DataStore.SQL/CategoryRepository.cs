using SupermarketManagement.Entities;

namespace SupermarketManagement.DataStore.SQL;
public class CategoryRepository : ICategoryRepository
{
    private readonly MarketDbContext _dbContext;

    public CategoryRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCategory(Category category)
    {
        try
        {
            category.Id = await CreateCategoryId();
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> CreateCategoryId()
    {
        return await _dbContext.Categories.AnyAsync() ? await _dbContext.Categories.MaxAsync(c => c.Id) : 1;
    }

    public async Task DeleteCategory(int id)
    {
        try
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return;
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
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
            return await _dbContext.Categories.ToListAsync();
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
            return await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateCategory(Category category)
    {
        try
        {
            var categoryToUpdate = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            if (categoryToUpdate == null)
            {
                return;
            }
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
            categoryToUpdate.Products = category.Products;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

namespace SupermarketManagement.DataStore.SQL.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly MarketDbContext _dbContext;

    public CategoryRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _dbContext.Categories.SingleOrDefault(c => c.Id == id);
        if (category == null)
        {
            return;
        }
        if (category.Products == null || category.Products.Any() == false)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges(); 
        }
    }

    public IEnumerable<Category>? GetCategories()
    {
        return _dbContext.Categories.AsEnumerable();
    }

    public Category? GetCategoryById(int categoryId)
    {
        return _dbContext.Categories.SingleOrDefault(c => c.Id == categoryId);
    }

    public void UpdateCategory(Category category)
    {
        if(category == null) return;

        var categoryToUpdate = _dbContext.Categories.SingleOrDefault(c => c.Id == category.Id);
        if (categoryToUpdate == null) return;

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
        categoryToUpdate.Products = category.Products;

        _dbContext.SaveChanges();
    }
}

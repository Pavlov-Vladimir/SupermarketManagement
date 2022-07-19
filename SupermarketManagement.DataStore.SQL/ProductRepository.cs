using SupermarketManagement.Entities;

namespace SupermarketManagement.DataStore.SQL;
public class ProductRepository : IProductRepository
{
    private readonly MarketDbContext _dbContext;

    public ProductRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProduct(Product product)
    {
        try
        {
            product.Id = await CreateProductId();
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<int> CreateProductId()
    {
        return await _dbContext.Products.AnyAsync() ? await _dbContext.Products.MaxAsync(p => p.Id) : 1;
    }

    public async Task DeleteProduct(int productId)
    {
        try
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return;
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Product?> GetProduct(int productId)
    {
        try
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Product>?> GetProducts()
    {
        try
        {
            return await _dbContext.Products.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Product>?> GetProductsByCategoryId(int categoryId)
    {
        try
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateProduct(Product product)
    {
        try
        {
            var productToUpdate = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
            if (productToUpdate == null)
            {
                return;
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Category = product.Category;

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

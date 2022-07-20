namespace SupermarketManagement.DataStore.SQL;
public class ProductRepository : IProductRepository
{
    private readonly MarketDbContext _dbContext;

    public ProductRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
        if (product == null) return;

        var category = _dbContext.Categories.SingleOrDefault(c => c.Id == product.CategoryId);
        category?.Products?.Remove(product);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
    }

    public Product? GetProduct(int productId)
    {
        return _dbContext.Products.SingleOrDefault(p => p.Id == productId);
    }

    public IEnumerable<Product>? GetProducts()
    {
        return _dbContext.Products.AsEnumerable();
    }

    public IEnumerable<Product>? GetProductsByCategoryId(int categoryId)
    {
        return _dbContext.Products.Where(p => p.CategoryId == categoryId).AsEnumerable();
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = _dbContext.Products.SingleOrDefault(p => p.Id == product.Id);
        if (productToUpdate == null) return;

        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Quantity = product.Quantity;
        productToUpdate.Category = product.Category;
        productToUpdate.CategoryId = product.CategoryId;

        _dbContext.SaveChanges();
    }
}

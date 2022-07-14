namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetProducts();
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task<Product?> GetProduct(int productId);
    Task DeleteProduct(int productId);
}

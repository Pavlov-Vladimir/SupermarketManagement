namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetProducts();
}

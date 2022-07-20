namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface IProductRepository
{
    IEnumerable<Product>? GetProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    Product? GetProduct(int productId);
    void DeleteProduct(int productId);
    IEnumerable<Product>? GetProductsByCategoryId(int categoryId);
}

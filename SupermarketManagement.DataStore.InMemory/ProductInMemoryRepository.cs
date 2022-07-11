namespace SupermarketManagement.DataStore.InMemory;
public class ProductInMemoryRepository : IProductRepository
{
    private List<Product>? _products;

    public ProductInMemoryRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Coca-Cola", CategoryId = 1, Quantity = 100, Price = 1.11m },
            new Product { Id = 2, Name = "Pepsi", CategoryId = 1, Quantity = 150, Price = 1.22m },
            new Product { Id = 3, Name = "White bread", CategoryId = 2, Quantity = 100, Price = 0.70m },
            new Product { Id = 4, Name = "Black bread", CategoryId = 2, Quantity = 200, Price = 0.99m },
            new Product { Id = 5, Name = "Pork", CategoryId = 3, Quantity = 50, Price = 2.99m },
            new Product { Id = 6, Name = "Beef", CategoryId = 3, Quantity = 70, Price = 3.33m }
        };
    }

    public async Task AddProduct(Product product)
    {
        try
        {
            if (_products is not null)
            {
                if (IsExists(product))
                {
                    return;
                }

                int maxId = _products.Max(p => p.Id);
                product.Id = maxId + 1;

                await Task.Run(() => _products.Add(product));
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(ProductInMemoryRepository));
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private bool IsExists(Product product)
    {
        return _products!.Any(p => p.Name.Equals(product.Name, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<Product>?> GetProducts()
    {
        try
        {
            return await Task.FromResult(_products);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

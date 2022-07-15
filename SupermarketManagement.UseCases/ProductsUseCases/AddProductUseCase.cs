namespace SupermarketManagement.UseCases.ProductsUseCases;
public class AddProductUseCase : IAddProductUseCase
{
    private readonly IProductRepository _productRepository;

    public AddProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(Product product)
    {
        await _productRepository.AddProduct(product);
    }
}

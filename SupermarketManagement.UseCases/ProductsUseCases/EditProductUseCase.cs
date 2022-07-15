namespace SupermarketManagement.UseCases.ProductsUseCases;
public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository _productRepository;

    public EditProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(Product product)
    {
        await _productRepository.UpdateProduct(product);
    }
}

namespace SupermarketManagement.UseCases.ProductsUseCases;
public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository _productRepository;

    public EditProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Execute(Product product)
    {
        _productRepository.UpdateProduct(product);
    }
}

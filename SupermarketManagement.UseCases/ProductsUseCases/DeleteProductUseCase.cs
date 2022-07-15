namespace SupermarketManagement.UseCases.ProductsUseCases;
public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(int productId)
    {
        await _productRepository.DeleteProduct(productId);
    }
}

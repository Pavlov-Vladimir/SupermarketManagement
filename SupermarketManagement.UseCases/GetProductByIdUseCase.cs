namespace SupermarketManagement.UseCases;
public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Execute(int productId)
    {
        return await _productRepository.GetProduct(productId);
    }
}

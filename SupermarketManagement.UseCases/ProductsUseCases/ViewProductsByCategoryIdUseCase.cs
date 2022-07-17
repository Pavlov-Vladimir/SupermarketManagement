namespace SupermarketManagement.UseCases.ProductsUseCases;
public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>?> Execute(int categoryId)
    {
        return await _productRepository.GetProductsByCategoryId(categoryId);
    }
}

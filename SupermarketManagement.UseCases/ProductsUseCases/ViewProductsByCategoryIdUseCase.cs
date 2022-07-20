namespace SupermarketManagement.UseCases.ProductsUseCases;
public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product>? Execute(int categoryId)
    {
        return _productRepository.GetProductsByCategoryId(categoryId);
    }
}

namespace SupermarketManagement.UseCases.ProductsUseCases;
public class ViewProductsUseCase : IViewProductsUseCase
{
    private readonly IProductRepository _productsRepository;

    public ViewProductsUseCase(IProductRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public IEnumerable<Product>? Execute()
    {
        return _productsRepository.GetProducts();
    }
}

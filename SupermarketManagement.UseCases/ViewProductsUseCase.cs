using SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

namespace SupermarketManagement.UseCases;
public class ViewProductsUseCase : IViewProductsUseCase
{
    private readonly IProductRepository _productsRepository;

    public ViewProductsUseCase(IProductRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<Product>?> Execute()
    {
        return await _productsRepository.GetProducts();
    }
}

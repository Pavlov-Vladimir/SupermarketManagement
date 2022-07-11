namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IViewProductsUseCase
{
    Task<IEnumerable<Product>?> Execute();
}
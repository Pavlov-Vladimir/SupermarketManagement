namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IViewProductsUseCase
{
    IEnumerable<Product>? Execute();
}
namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IViewProductsByCategoryIdUseCase
{
    IEnumerable<Product>? Execute(int categoryId);
}
namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IViewProductsByCategoryIdUseCase
{
    Task<IEnumerable<Product>?> Execute(int categoryId);
}
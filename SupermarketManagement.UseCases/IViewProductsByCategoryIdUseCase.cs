namespace SupermarketManagement.UseCases;

public interface IViewProductsByCategoryIdUseCase
{
    Task<IEnumerable<Product>?> Execute(int categoryId);
}
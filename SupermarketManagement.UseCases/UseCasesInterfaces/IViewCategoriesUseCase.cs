namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IViewCategoriesUseCase
{
    Task<IEnumerable<Category>?> Execute();
}
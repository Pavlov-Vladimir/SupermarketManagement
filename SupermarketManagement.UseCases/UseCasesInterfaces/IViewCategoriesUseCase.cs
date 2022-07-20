namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IViewCategoriesUseCase
{
    IEnumerable<Category>? Execute();
}
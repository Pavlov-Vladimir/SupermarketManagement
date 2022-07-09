namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IAddCategoryUseCase
{
    Task Execute(Category category);
}
namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IEditCategoryUseCase
{
    Task Execute(Category category);
}
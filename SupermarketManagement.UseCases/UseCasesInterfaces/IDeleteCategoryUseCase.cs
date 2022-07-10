namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IDeleteCategoryUseCase
{
    Task Execute(int categoryId);
}
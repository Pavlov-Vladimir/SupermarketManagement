namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IGetCategoryByIdUseCase
{
    Task<Category?> Execute(int categoryId);
}
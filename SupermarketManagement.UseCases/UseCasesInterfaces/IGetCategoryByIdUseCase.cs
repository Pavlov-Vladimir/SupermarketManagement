namespace SupermarketManagement.UseCases.UseCasesInterfaces;

public interface IGetCategoryByIdUseCase
{
    Category? Execute(int categoryId);
}
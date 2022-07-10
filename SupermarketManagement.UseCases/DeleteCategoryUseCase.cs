namespace SupermarketManagement.UseCases;
public class DeleteCategoryUseCase : IDeleteCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Execute(int categoryId)
    {
        await _categoryRepository.DeleteCategory(categoryId);
    }
}

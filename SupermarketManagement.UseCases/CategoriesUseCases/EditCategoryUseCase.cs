namespace SupermarketManagement.UseCases.CategoriesUseCases;
public class EditCategoryUseCase : IEditCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public EditCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Execute(Category category)
    {
        await _categoryRepository.UpdateCategory(category);
    }
}

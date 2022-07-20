namespace SupermarketManagement.UseCases.CategoriesUseCases;
public class EditCategoryUseCase : IEditCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public EditCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void Execute(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }
}

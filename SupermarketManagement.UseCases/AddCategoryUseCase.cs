namespace SupermarketManagement.UseCases;
public class AddCategoryUseCase : IAddCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Execute(Category category)
    {
        await _categoryRepository.AddCategory(category);
    }
}

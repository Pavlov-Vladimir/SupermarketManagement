namespace SupermarketManagement.UseCases;
public class ViewCategoriesUseCase : IViewCategoriesUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>?> Execute()
    {
        return await _categoryRepository.GetCategories();
    }
}

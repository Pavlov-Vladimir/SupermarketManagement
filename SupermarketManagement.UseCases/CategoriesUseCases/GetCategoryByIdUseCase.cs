namespace SupermarketManagement.UseCases.CategoriesUseCases;
public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category?> Execute(int categoryId)
    {
        return await _categoryRepository.GetCategoryById(categoryId);
    }
}

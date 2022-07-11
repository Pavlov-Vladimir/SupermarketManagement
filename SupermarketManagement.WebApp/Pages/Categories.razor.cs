namespace SupermarketManagement.WebApp.Pages;

public partial class Categories
{
    private List<Category>? _categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public IGetCategoryByIdUseCase GetCategoryByIdUseCase { get; set; } = null!;
    [Inject]
    public IDeleteCategoryUseCase DeleteCategoryUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _categories = (await ViewCategoriesUseCase.Execute())?.ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void HandleAddingCategory_Click()
    {
        NavigationManager.NavigateTo("/AddCategory");
    }

    protected async Task HandleDeleting_Click(int categoryId)
    {
        await DeleteCategoryUseCase.Execute(categoryId);
        var category = _categories!.First(c => c.Id == categoryId);
        _categories!.Remove(category);
    }
}

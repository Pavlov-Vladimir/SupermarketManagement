namespace SupermarketManagement.WebApp.Pages;

public partial class Categories : ComponentBase
{
    private List<Category>? _categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public IGetCategoryByIdUseCase GetCategoryByIdUseCase { get; set; } = null!;
    [Inject]
    public IDeleteCategoryUseCase DeleteCategoryUseCase { get; set; } = null!;
    [Inject]
    public IViewProductsByCategoryIdUseCase ViewProductsByCategoryIdUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    protected override void OnInitialized()
    {
        _categories = ViewCategoriesUseCase.Execute()?.ToList();
    }

    private void HandleAddingCategory_Click()
    {
        NavigationManager.NavigateTo("/AddCategory");
    }

    protected void HandleDeleting_Click(int categoryId)
    {
        var categoryToDelete = GetCategoryByIdUseCase.Execute(categoryId);

        if (categoryToDelete == null)
        {
            ErrorMessage = "The category is not exists and cannot be deleted.";
            StateHasChanged();
        }
        else if (categoryToDelete.Products != null && categoryToDelete.Products.Any())
        {
            ErrorMessage = "The category cannot be deleted because it contains products.";
            StateHasChanged();
        }
        else
        {
            DeleteCategoryUseCase.Execute(categoryId);
            var category = _categories!.First(c => c.Id == categoryId);
            _categories!.Remove(category);
        }
    }
    
    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }
}

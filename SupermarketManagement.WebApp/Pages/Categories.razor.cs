namespace SupermarketManagement.WebApp.Pages;

public partial class Categories
{
    private List<Category>? categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            categories = (await ViewCategoriesUseCase.Execute())?.ToList();
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
}

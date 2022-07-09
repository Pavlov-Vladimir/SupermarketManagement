namespace SupermarketManagement.WebApp.Pages;

public partial class Categories
{
    private List<Category>? categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        categories = (await ViewCategoriesUseCase.Execute())?.ToList();
    }

    private void AddCategory_Click()
    {
        NavigationManager.NavigateTo("/AddCategory");
    }
}

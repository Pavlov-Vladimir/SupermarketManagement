namespace SupermarketManagement.WebApp.Pages;

public partial class Categories
{
    private List<Category>? categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        categories = (await ViewCategoriesUseCase.Execute())?.ToList();
    }
}

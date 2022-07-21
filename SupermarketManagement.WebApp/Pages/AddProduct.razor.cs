namespace SupermarketManagement.WebApp.Pages;

public partial class AddProduct : ComponentBase
{
    private const int STARTED_CATEGORY_ID = -1;
    public Product? Product { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    public string? ErrorMessage { get; set; }
    [Inject]
    public IAddProductUseCase AddProductUseCase { get; set; } = null!;
    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override void OnInitialized()
    {
        try
        {
            Product = new() { CategoryId = STARTED_CATEGORY_ID };
            Categories = ViewCategoriesUseCase.Execute();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected void HandleValidSubmit(Product product)
    {
        try
        {
            product.Price = Math.Round(product.Price, 2);
            AddProductUseCase.Execute(product);
            NavigationManager.NavigateTo("/Products");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }
}

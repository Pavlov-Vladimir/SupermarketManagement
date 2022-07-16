namespace SupermarketManagement.WebApp.Pages;

public partial class AddProduct
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

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Product = new Product();
            Product.CategoryId = STARTED_CATEGORY_ID;
            Categories = await ViewCategoriesUseCase.Execute();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task HandleValidSubmit(Product product)
    {
        try
        {
            product.Price = Math.Round(product.Price, 2);
            await AddProductUseCase.Execute(product);
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

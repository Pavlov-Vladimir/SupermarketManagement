namespace SupermarketManagement.WebApp.Pages;

public partial class Products
{
    public List<Product>? ProductsList { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IViewProductsUseCase ViewProductsUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IDeleteProductUseCase DeleteProductUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await GetProductsList();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private async Task GetProductsList()
    {
        ProductsList = (await ViewProductsUseCase.Execute())?.ToList();
    }

    private void HandleAddingProduct_Click()
    {
        NavigationManager.NavigateTo("/AddProduct");
    }

    private async Task HandleDeleting(int productId)
    {
        try
        {
            await DeleteProductUseCase.Execute(productId);
            await GetProductsList();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

    }
}

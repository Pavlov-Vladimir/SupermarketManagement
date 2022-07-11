namespace SupermarketManagement.WebApp.Pages;

public partial class Products
{
    public List<Product>? ProductsList { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IViewProductsUseCase ViewProductsUseCase { get; set; } = null!;    
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            ProductsList = (await ViewProductsUseCase.Execute())?.ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void HandleAddingProduct_Click()
    {
        NavigationManager.NavigateTo("/AddProduct");
    }
}

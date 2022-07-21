namespace SupermarketManagement.WebApp.Pages;

public partial class Products : ComponentBase
{
    public List<Product>? ProductsList { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IViewProductsUseCase ViewProductsUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IDeleteProductUseCase DeleteProductUseCase { get; set; } = null!;

    protected override void OnInitialized()
    {
        try
        {
            ProductsList = ViewProductsUseCase.Execute()?.ToList();            
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

    private void HandleDeleting(int productId)
    {
        try
        {
            DeleteProductUseCase.Execute(productId);
            ProductsList = ViewProductsUseCase.Execute()?.ToList();
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

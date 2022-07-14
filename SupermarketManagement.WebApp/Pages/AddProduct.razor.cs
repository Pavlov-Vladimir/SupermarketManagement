using SupermarketManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace SupermarketManagement.WebApp.Pages;

public partial class AddProduct
{
    private const int STARTED_CATEGORY_ID = -1;
    public Product? Product { get; set; }
    public static IEnumerable<Category>? Categories { get; set; } = new List<Category>();
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

    private async void HandleValidSubmit()
    {
        try
        {
            Product!.Price = Math.Round(Product.Price, 2);
            await AddProductUseCase.Execute(Product!);
            NavigationManager.NavigateTo("/Products");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

    }

    private void HandleCancelation_Click()
    {
        NavigationManager.NavigateTo("/Products");
    }

}

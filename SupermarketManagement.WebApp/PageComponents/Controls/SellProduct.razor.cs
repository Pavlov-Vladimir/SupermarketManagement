namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SellProduct
{
    [Parameter]
    public Product? SelectedProduct { get; set; }
    [Parameter]
    public EventCallback<Product> OnSoldProduct { get; set; }
    public Product? ProductToSell { get; set; }
    public string? ErrorMessage { get; set; }
    [Inject]
    public ISellProductUseCase SellProductUseCase { get; set; } = null!;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (SelectedProduct is not null)
        {
            ProductToSell = new Product
            {
                CategoryId = SelectedProduct.CategoryId,
                Id = SelectedProduct.Id,
                Name = SelectedProduct.Name,
                Price = SelectedProduct.Price,
                Quantity = 0
            };
        }
        else
        {
            ProductToSell = null;
        }
    }

    private async Task HandleValidSubmit()
    {
        if (ProductToSell!.Quantity <= 0)
        {
            ErrorMessage = $"The quantity to sell must be greater than zero. Change the number.";
            StateHasChanged();
        }
        else if (ProductToSell!.Quantity > SelectedProduct!.Quantity)
        {
            ErrorMessage = $"The quantity of {SelectedProduct.Name} is not enough. Change the number.";
            StateHasChanged();
        }
        else
        {
            await SellProductUseCase.Execute(ProductToSell.Id, ProductToSell.Quantity);
            await OnSoldProduct.InvokeAsync(ProductToSell);
            ErrorMessage = string.Empty;
            ProductToSell.Quantity = 0;
            StateHasChanged();
        }
    }
}

namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SellProduct
{
    [Parameter]
    public string? CashierName { get; set; }
    [Parameter]
    public Product? SelectedProduct { get; set; }
    [Parameter]
    public EventCallback<Product> OnSoldProduct { get; set; }
    public Product? ProductToSell { get; set; }
    public string? ErrorMessage { get; set; }
    [Inject]
    public ISellProductUseCase SellProductUseCase { get; set; } = null!;
    [Inject]
    public IRecordTransactionUseCase RecordTransactionUseCase { get; set; } = null!;

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

    private void HandleValidSubmit()
    {
        if (string.IsNullOrWhiteSpace(CashierName))
        {
            ErrorMessage = "Cashier's name is required. Enter your name.";
            StateHasChanged();
        }
        else
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
                SellProductUseCase.Execute(ProductToSell.Id, ProductToSell.Quantity);
                RecordTransactionUseCase.Execute(CashierName, ProductToSell.Id, ProductToSell.Quantity);
                OnSoldProduct.InvokeAsync(ProductToSell);
                ErrorMessage = string.Empty;
                ProductToSell.Quantity = 0;
                StateHasChanged();
            }
        }
    }
}

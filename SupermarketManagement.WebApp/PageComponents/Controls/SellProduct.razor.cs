namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SellProduct
{
    [Parameter]
    public Product? SelectedProduct { get; set; }
    [Parameter]
    public EventCallback<Product> SoldProduct { get; set; }
    public Product? ProductToSell { get; set; }
    public string? ErrorMessage { get; set; }

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
        SoldProduct.InvokeAsync(ProductToSell);
    }

    private void HandleSelling_Click()
    {
        if (ProductToSell!.Quantity > SelectedProduct!.Quantity)
        {
            ErrorMessage = $"Quantity of {SelectedProduct.Name} is not enough. Change the number.";
            StateHasChanged();
        }
        else
        {
            ErrorMessage = string.Empty;
            SelectedProduct!.Quantity -= ProductToSell!.Quantity;
            ProductToSell.Quantity = 0;
            StateHasChanged();
        }
    }
}

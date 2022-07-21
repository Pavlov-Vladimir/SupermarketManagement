namespace SupermarketManagement.WebApp.Pages;

public partial class TransactionsReport : ComponentBase
{
    public List<Transaction>? Transactions { get; set; }
    public string? CashierName { get; set; }
    public DateTime BegingDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today;
    [Inject]
    public IGetProductByIdUseCase GetProductByIdUseCase { get; set; } = null!;
    [Inject]
    public ISearchTransactionsUseCase SearchTransactionsUseCase { get; set; } = null!;
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    public void LoadTransactions(string cashierName, DateTime from, DateTime to)
    {
        Transactions = SearchTransactionsUseCase.Execute(cashierName, from, to)?.ToList();
        StateHasChanged();
    }

    private string? GetProductName(int productId)
    {
        return GetProductByIdUseCase.Execute(productId)?.Name;
    }

    private decimal GetProductPrice(int productId)
    {
        var product = GetProductByIdUseCase.Execute(productId);
        return product is null ? 0 : product.Price;
    }

    private void PrintReport()
    {
        JSRuntime.InvokeVoidAsync("print");
    }
}

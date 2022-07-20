namespace SupermarketManagement.WebApp.Pages;

public partial class TransactionsReport
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
        try
        {
            Transactions = SearchTransactionsUseCase.Execute(cashierName, from, to)?.ToList();
            StateHasChanged();
        }
        catch (Exception)
        {
            throw;
        }

    }

    private string? GetProductName(int productId)
    {
        try
        {
            return GetProductByIdUseCase.Execute(productId)?.Name;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private decimal GetProductPrice(int productId)
    {
        try
        {
            var product = GetProductByIdUseCase.Execute(productId);
            return product is null ? 0 : product.Price;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void PrintReport()
    {
        JSRuntime.InvokeVoidAsync("print");
    }
}

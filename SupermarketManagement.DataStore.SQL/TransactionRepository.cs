namespace SupermarketManagement.DataStore.SQL;
public class TransactionRepository : ITransactionRepository
{
    private readonly MarketDbContext _dbContext;

    public TransactionRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Transaction>? GetByDate(DateTime date)
    {
        return _dbContext.Transactions.Where(t => t.TimeStamp.Date == date.Date).AsEnumerable();
    }

    public IEnumerable<Transaction>? GetTransactions()
    {
        return _dbContext.Transactions.AsEnumerable();
    }

    public void Save(string cashierName, int productId, int qtySold)
    {
        if (string.IsNullOrWhiteSpace(cashierName)) return;

        var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
        if (product == null) return;

        _dbContext.Transactions.Add(new Transaction
        {
            CashierName = cashierName,
            ProductId = productId,
            QtySold = qtySold,
            Price = product.Price * qtySold,
            QtyBefore = product.Quantity + qtySold,
            TimeStamp = DateTime.Now
        });

        _dbContext.SaveChanges();
    }

    public IEnumerable<Transaction>? SearchTransactions(string cashierName, DateTime beginDate, DateTime endDate)
    {
        if (cashierName == null)
        {
            return _dbContext.Transactions
                .Where(t => t.TimeStamp.Date >= beginDate.Date)
                .Where(t => t.TimeStamp.Date <= endDate.Date)
                .AsEnumerable();
        }
        return _dbContext.Transactions
            .Where(t => EF.Functions.Like(t.CashierName, $"%{cashierName}%"))
            .Where(t => t.TimeStamp.Date >= beginDate.Date)
            .Where(t => t.TimeStamp.Date <= endDate.Date)
            .AsEnumerable();
    }
}

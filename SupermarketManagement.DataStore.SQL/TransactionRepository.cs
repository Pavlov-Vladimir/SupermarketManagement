namespace SupermarketManagement.DataStore.SQL;
public class TransactionRepository : ITransactionRepository
{
    private readonly MarketDbContext _dbContext;

    public TransactionRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Transaction>?> GetByDate(DateTime date)
    {
        try
        {
            return await _dbContext.Transactions
                .Where(t => t.TimeStamp.Date == date.Date)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Transaction>?> GetTransactions()
    {
        try
        {
            return await _dbContext.Transactions.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Save(string cashierName, int productId, int qtySold)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return;
            }

            var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return;
            }

            await _dbContext.Transactions.AddAsync(new Transaction
            {
                Id = CreateTransactionId(),
                CashierName = cashierName,
                ProductId = productId,
                QtySold = qtySold,
                Price = product.Price * qtySold,
                QtyBefore = product.Quantity + qtySold,
                TimeStamp = DateTime.Now
            });
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private int CreateTransactionId()
    {
        return _dbContext.Transactions.Any() ? _dbContext.Transactions.Max(t => t.Id) + 1 : 1;
    }

    public async Task<IEnumerable<Transaction>?> SearchTransactions(string cashierName, DateTime beagineDate, DateTime endDate)
    {
        try
        {
            if (cashierName == null)
            {
                return await _dbContext.Transactions
                    .Where(t => t.TimeStamp.Date >= beagineDate.Date &&
                                t.TimeStamp.Date <= endDate.Date)
                    .ToListAsync();
            }
            return await _dbContext.Transactions
                .Where(t => t.CashierName == cashierName &&
                            t.TimeStamp.Date >= beagineDate.Date &&
                            t.TimeStamp.Date <= endDate.Date)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

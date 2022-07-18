namespace SupermarketManagement.DataStore.InMemory;
public class TransactionInMemoryRepository : ITransactionRepository
{
    private readonly List<Transaction>? _transactions;
    private readonly IProductRepository _productRepository;

    public TransactionInMemoryRepository(IProductRepository productRepository)
    {
        _transactions = new List<Transaction>();
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Transaction>?> GetByDate(DateTime date)
    {
        try
        {
            if (_transactions is not null)
            {
                return await Task.FromResult(_transactions.Where(t => t.TimeStamp.Date == date.Date));
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(TransactionInMemoryRepository));
            }
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
            return await Task.FromResult(_transactions);
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
            if (_transactions is not null)
            {
                var product = await _productRepository.GetProduct(productId);
                if (product == null)
                {
                    throw new EntityNotFoundException($"Id = {productId}");
                }
                int transactionId = CreateNewTransactionId();

                await Task.Run(() => _transactions.Add(new Transaction
                {
                    Id = transactionId,
                    CashierName = cashierName,
                    ProductId = productId,
                    QtySold = qtySold,
                    QtyBefore = product.Quantity + qtySold,
                    Price = product.Price,
                    TimeStamp = DateTime.Now
                }));
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(TransactionInMemoryRepository));
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Transaction>?> SearchTransactions(string cashierName, DateTime beagineDate, DateTime endDate)
    {
        try
        {
            if (_transactions is not null)
            {
                if (_transactions.Any())
                {
                    return await Task.Run(() => _transactions.Where(t =>
                        t.CashierName.Equals(cashierName, StringComparison.InvariantCultureIgnoreCase) &&
                        t.TimeStamp.Date >= beagineDate.Date &&
                        t.TimeStamp.Date <= endDate.Date));
                }
                return null;
            }
            else
            {
                throw new DataStoreNotFoundException(nameof(TransactionInMemoryRepository));
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private int CreateNewTransactionId()
    {
        if (_transactions!.Any())
        {
            int maxId = _transactions!.Max(t => t.Id);
            return maxId + 1;
        }
        return 1;
    }
}

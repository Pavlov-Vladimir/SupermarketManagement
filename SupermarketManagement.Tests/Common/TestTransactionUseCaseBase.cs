namespace SupermarketManagement.Tests.Common;
public abstract class TestTransactionUseCaseBase : IDisposable
{
    protected readonly MarketDbContext dbContext;
    protected readonly TransactionRepository transactionRepository;

    public TestTransactionUseCaseBase()
    {
        dbContext = MarketContextFactory.Create();
        transactionRepository = new(dbContext);
    }

    public void Dispose()
    {
        MarketContextFactory.Destroy(dbContext);
    }
}

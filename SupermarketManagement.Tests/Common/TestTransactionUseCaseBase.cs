namespace SupermarketManagement.Tests.Common;
public abstract class TestTransactionUseCaseBase : IDisposable
{
    protected readonly MarketDbContext dbContext;
    protected readonly TransactionRepository transactionRepository;
    protected readonly Fixture fixture;

    public TestTransactionUseCaseBase()
    {
        dbContext = MarketContextFactory.Create();
        transactionRepository = new(dbContext);
        fixture = new Fixture();
    }

    public void Dispose()
    {
        MarketContextFactory.Destroy(dbContext);
    }
}

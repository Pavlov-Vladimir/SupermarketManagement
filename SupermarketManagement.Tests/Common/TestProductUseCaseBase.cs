namespace SupermarketManagement.Tests.Common;
public abstract class TestProductUseCaseBase : IDisposable
{
    protected readonly MarketDbContext dbContext;
    protected readonly ProductRepository productRepository;
    protected readonly Fixture fixture;

    public TestProductUseCaseBase()
    {
        dbContext = MarketContextFactory.Create();
        productRepository = new(dbContext);
        fixture = new Fixture();
    }

    public void Dispose()
    {
        MarketContextFactory.Destroy(dbContext);
    }
}

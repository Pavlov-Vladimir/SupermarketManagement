namespace SupermarketManagement.Tests.Common;
public abstract class TestUseCaseBase : IDisposable
{
    protected readonly MarketDbContext Context;

    public TestUseCaseBase()
    {
        Context = MarketContextFactory.Create();
    }

    public void Dispose()
    {
        MarketContextFactory.Destroy(Context);
    }
}

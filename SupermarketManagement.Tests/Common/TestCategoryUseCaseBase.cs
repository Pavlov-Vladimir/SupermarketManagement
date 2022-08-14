using SupermarketManagement.UseCases.DataStorePlaginInterfaces;

namespace SupermarketManagement.Tests.Common;
public abstract class TestCategoryUseCaseBase : IDisposable
{
    protected readonly MarketDbContext dbContext;
    protected readonly CategoryRepository categoryRepository;

    public TestCategoryUseCaseBase()
    {
        dbContext = MarketContextFactory.Create();
        categoryRepository = new(dbContext);
    }

    public void Dispose()
    {
        MarketContextFactory.Destroy(dbContext);
    }
}

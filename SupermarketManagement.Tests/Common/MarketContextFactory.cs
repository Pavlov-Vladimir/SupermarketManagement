namespace SupermarketManagement.Tests.Common;
public class MarketContextFactory
{
    public static MarketDbContext Create()
    {
        var options = new DbContextOptionsBuilder<MarketDbContext>()
            .UseInMemoryDatabase("DB_FOR_TESTS")
            .Options;
        return new MarketDbContext(options);
    }

    public static void Destroy(MarketDbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}

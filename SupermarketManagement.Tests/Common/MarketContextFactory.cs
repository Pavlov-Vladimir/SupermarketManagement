namespace SupermarketManagement.Tests.Common;
public class MarketContextFactory
{
    public const int CATEGORY_ID_FOR_DELETE = 3;
    public const int CATEGORY_ID_FOR_UPDATE = 3;
    public const int PRODUCT_ID_FOR_DELETE = 4;
    public const int PRODUCT_ID_FOR_UPDATE = 4;
    public const int NOT_RELEVANT_ID = 100;

    public static MarketDbContext Create()
    {
        var options = new DbContextOptionsBuilder<MarketDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var dbContext = new MarketDbContext(options);
        //dbContext.Database.EnsureCreated();

        dbContext.Categories.AddRange(
                new Category { Id = 1, Name = "Beverage", Description = "Beverage" },
                new Category { Id = 2, Name = "Bakery", Description = "Bakery" },
                new Category { Id = CATEGORY_ID_FOR_DELETE, Name = "Meat", Description = "Meat" }
            );
        dbContext.Products.AddRange(
                new Product { Id = 1, Name = "Coca-Cola", CategoryId = 1, Quantity = 100, Price = 1.11m },
                new Product { Id = 2, Name = "Pepsi", CategoryId = 1, Quantity = 150, Price = 1.22m },
                new Product { Id = 3, Name = "White bread", CategoryId = 2, Quantity = 100, Price = 0.70m },
                new Product { Id = PRODUCT_ID_FOR_DELETE, Name = "Black bread", CategoryId = 2, Quantity = 200, Price = 0.99m }
            );
        dbContext.Transactions.AddRange(
                new Transaction { Id = 1, CashierName = "Bob", Price = 1.11m, ProductId = 1, QtyBefore = 101, QtySold = 1, TimeStamp = DateTime.Now.AddDays(-1) },
                new Transaction { Id = 2, CashierName = "Bob", Price = 1.22m, ProductId = 2, QtyBefore = 151, QtySold = 1, TimeStamp = DateTime.Now },
                new Transaction { Id = 3, CashierName = "Tom", Price = 1.11m, ProductId = 1, QtyBefore = 101, QtySold = 1, TimeStamp = DateTime.Now.AddDays(-1) },
                new Transaction { Id = 4, CashierName = "Tom", Price = 1.22m, ProductId = 2, QtyBefore = 151, QtySold = 1, TimeStamp = DateTime.Now }
            );
        dbContext.SaveChanges();

        return dbContext;
    }

    public static void Destroy(MarketDbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}

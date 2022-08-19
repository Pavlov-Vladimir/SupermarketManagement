namespace SupermarketManagement.DataStore.MySQL;
public class MySqlMarketDbContext : DbContext
{
    public MySqlMarketDbContext(DbContextOptions<MySqlMarketDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Beverage", Description = "Beverage" },
                new Category { Id = 2, Name = "Bakery", Description = "Bakery" },
                new Category { Id = 3, Name = "Meat", Description = "Meat" }
            );

        modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Coca-Cola", CategoryId = 1, Quantity = 100, Price = 1.11m },
                new Product { Id = 2, Name = "Pepsi", CategoryId = 1, Quantity = 150, Price = 1.22m },
                new Product { Id = 3, Name = "White bread", CategoryId = 2, Quantity = 100, Price = 0.70m },
                new Product { Id = 4, Name = "Black bread", CategoryId = 2, Quantity = 200, Price = 0.99m },
                new Product { Id = 5, Name = "Pork", CategoryId = 3, Quantity = 50, Price = 2.99m },
                new Product { Id = 6, Name = "Beef", CategoryId = 3, Quantity = 70, Price = 3.33m }
            );
    }
}

namespace SupermarketManagement.Tests.TransactionsUseCases;
public class RecordTransactionUseCaseTests : TestTransactionUseCaseBase
{
	private readonly ProductRepository productRepository;

	public RecordTransactionUseCaseTests()
	{
		productRepository = new ProductRepository(dbContext);
	}

	[Fact]
	public void RecordTransactionUseCase_Success()
	{
		//Arrange
		string cashierName = "Jerry";
		int productId = 1;
		int qtySold = 3;
		var product = dbContext.Products.Find(productId);
		
		var sut = new RecordTransactionUseCase(transactionRepository, productRepository);

		//Act
		sut.Execute(cashierName, productId, qtySold);
		var actual = dbContext.Transactions.SingleOrDefault(t =>
			t.CashierName == cashierName &&
			t.ProductId == productId &&
			t.QtySold == qtySold &&
			t.QtyBefore == product!.Quantity + qtySold);

        //Assert
		actual.Should().NotBeNull();
    }

    [Fact]
    public void RecordTransactionUseCase_DoNothingOnEmptyName()
    {
        //Arrange
        string cashierName = "";
        int productId = 1;
        int qtySold = 3;

        var sut = new RecordTransactionUseCase(transactionRepository, productRepository);

        //Act
        sut.Execute(cashierName, productId, qtySold);
        var actual = dbContext.Transactions.SingleOrDefault(t => t.CashierName == cashierName);

        //Assert
        actual.Should().BeNull();
    }

    [Fact]
    public void RecordTransactionUseCase_DoNothingOnWrongProductId()
    {
        //Arrange
        string cashierName = "Jerry";
        int productId = MarketContextFactory.NOT_RELEVANT_ID;
        int qtySold = 3;

        var sut = new RecordTransactionUseCase(transactionRepository, productRepository);

        //Act
        sut.Execute(cashierName, productId, qtySold);
        var actual = dbContext.Transactions.SingleOrDefault(t => t.CashierName == cashierName);

        //Assert
        actual.Should().BeNull();
    }

    [Theory]
    [InlineData(-11)]
    [InlineData(0)]
    [InlineData(1111)]
    public void RecordTransactionUseCase_FailOnWrongQuantitySold(int sold)
    {
        //Arrange
        string cashierName = "Jerry";
        int productId = 1;
        int qtySold = sold;
        var sut = new RecordTransactionUseCase(transactionRepository, productRepository);

        //Act        

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Execute(cashierName, productId, qtySold));
    }
}
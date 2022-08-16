namespace SupermarketManagement.Tests.TransactionsUseCases;
public class TodayTransactionsByCashierUseCaseTests : TestTransactionUseCaseBase
{
	[Fact]
	public void TodayTransactionsByCashierUseCase_Success()
	{
		//Arrange
		var expected = dbContext.Transactions.Where(t => t.CashierName == "Bob" && t.TimeStamp.Date == DateTime.Today)
			.AsEnumerable();
		var sut = new TodayTransactionsByCashierUseCase(transactionRepository);

        //Act
		var actual = sut.Execute("Bob");

        //Assert
		actual.Should().BeEquivalentTo(expected).And.HaveCount(1);
    }

    [Fact]
    public void TodayTransactionsByCashierUseCase_ReturnEmptyOnWrongName()
    {
        //Arrange
        var sut = new TodayTransactionsByCashierUseCase(transactionRepository);

        //Act
        var actual = sut.Execute("BoT");

        //Assert
        actual.Should().BeEmpty();
    }
}
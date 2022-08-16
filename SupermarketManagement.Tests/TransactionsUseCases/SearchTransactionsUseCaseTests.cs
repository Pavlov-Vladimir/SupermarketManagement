namespace SupermarketManagement.Tests.TransactionsUseCases;
public class SearchTransactionsUseCaseTests : TestTransactionUseCaseBase
{
	[Theory]
	[MemberData(nameof(GetDataForTransactions))]
	public void SearchTransactionsUseCase_Success(string cashierName, DateTime start, DateTime stop)
	{
		//Arrange
		var expected = dbContext.Transactions
			.Where(t => t.TimeStamp.Date >= start.Date)
			.Where(t => t.TimeStamp.Date <= stop.Date)
			.Where(t => t.CashierName.Contains(cashierName, StringComparison.InvariantCultureIgnoreCase))
			.AsEnumerable();
		var sut = new SearchTransactionsUseCase(transactionRepository);

		//Act
		var actual = sut.Execute(cashierName, start, stop);

        //Assert
		actual.Should().BeEquivalentTo(expected);
    }

	[Fact]
    public void SearchTransactionsUseCase_SuccessWhenCashierNameIsNull()
    {
        //Arrange
        var expected = dbContext.Transactions
            .Where(t => t.TimeStamp.Date >= DateTime.Now.Date)
            .Where(t => t.TimeStamp.Date <= DateTime.Now.Date)
            .AsEnumerable();
        var sut = new SearchTransactionsUseCase(transactionRepository);

		//Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		var actual = sut.Execute(null, DateTime.Now, DateTime.Now);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

		//Assert
		actual.Should().BeEquivalentTo(expected).And.HaveCount(2);
    }

    public static IEnumerable<object[]> GetDataForTransactions()
	{
		yield return new object[] { "bob", DateTime.Now, DateTime.Now };
		yield return new object[] { "bob", DateTime.Now.AddDays(-3), DateTime.Now };
		yield return new object[] { "tom", DateTime.Now, DateTime.Now };
		yield return new object[] { "bot", DateTime.Now.AddDays(-3), DateTime.Now };
    }
}
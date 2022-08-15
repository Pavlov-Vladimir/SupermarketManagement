namespace SupermarketManagement.Tests.TransactionsUseCases;
public class GetTransactionsByDateUseCaseTests : TestTransactionUseCaseBase
{
    [Theory]
	[MemberData(nameof(GetDates))]
	public void GetTransactionsByDateUseCase_Success(DateTime date)
	{
		//Arrange
		var expected = dbContext.Transactions.Where(t => t.TimeStamp.Date == date.Date).AsEnumerable();
		var sut = new GetTransactionsByDateUseCase(transactionRepository);

        //Act
		var actual = sut.Execute(date);
		
        //Assert
		actual.Should().BeEquivalentTo(expected).And.HaveCount(2);
    }

	public static IEnumerable<object[]> GetDates()
	{
        yield return new object[] { DateTime.Now };
        yield return new object[] { DateTime.Now.AddDays(-1) };
    }
}
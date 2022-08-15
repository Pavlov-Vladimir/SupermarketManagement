namespace SupermarketManagement.Tests.TransactionsUseCases;
public class GetTransactionsUseCaseTests : TestTransactionUseCaseBase
{
	[Fact]
	public void GetTransactionsUseCase_Success()
	{
		//Arrange
		var expected = dbContext.Transactions.AsEnumerable();
		var sut = new GetTransactionsUseCase(transactionRepository);

		//Act
		var actual = sut.Execute();

        //Assert
		actual.Should().BeEquivalentTo(expected).And.HaveCount(4);
    }
}
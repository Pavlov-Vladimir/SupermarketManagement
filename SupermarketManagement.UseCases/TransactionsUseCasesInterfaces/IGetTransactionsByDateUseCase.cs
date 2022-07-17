namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IGetTransactionsByDateUseCase
{
    Task<IEnumerable<Transaction>?> Execute(DateTime date);
}
namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IGetTransactionsByDateUseCase
{
    IEnumerable<Transaction>? Execute(DateTime date);
}
namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IGetTransactionsUseCase
{
    IEnumerable<Transaction>? Execute();
}
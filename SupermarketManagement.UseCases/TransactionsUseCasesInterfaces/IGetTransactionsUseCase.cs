namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IGetTransactionsUseCase
{
    Task<IEnumerable<Transaction>?> Execute();
}
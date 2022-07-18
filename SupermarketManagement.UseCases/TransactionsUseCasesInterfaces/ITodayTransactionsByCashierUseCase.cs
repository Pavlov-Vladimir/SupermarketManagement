namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface ITodayTransactionsByCashierUseCase
{
    Task<IEnumerable<Transaction>?> Execute(string cashierName);
}
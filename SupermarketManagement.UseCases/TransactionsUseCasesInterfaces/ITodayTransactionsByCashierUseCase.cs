namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface ITodayTransactionsByCashierUseCase
{
    IEnumerable<Transaction>? Execute(string cashierName);
}
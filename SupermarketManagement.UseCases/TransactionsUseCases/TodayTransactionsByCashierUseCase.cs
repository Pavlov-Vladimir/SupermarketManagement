namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class TodayTransactionsByCashierUseCase : ITodayTransactionsByCashierUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public TodayTransactionsByCashierUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction>? Execute(string cashierName)
    {
        return _transactionRepository.SearchTransactions(cashierName, DateTime.Today, DateTime.Today);
    }
}

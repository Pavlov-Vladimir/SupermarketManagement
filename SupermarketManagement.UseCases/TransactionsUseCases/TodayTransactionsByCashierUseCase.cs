namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class TodayTransactionsByCashierUseCase : ITodayTransactionsByCashierUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public TodayTransactionsByCashierUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>?> Execute(string cashierName)
    {
        return await _transactionRepository.SearchTransactions(cashierName, DateTime.Today, DateTime.Today);
    }
}

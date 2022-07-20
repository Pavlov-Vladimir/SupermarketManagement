namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class SearchTransactionsUseCase : ISearchTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public SearchTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction>? Execute(string cashierName, DateTime beagineDate, DateTime endDate)
    {
        return _transactionRepository.SearchTransactions(cashierName, beagineDate, endDate);
    }
}

namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class SearchTransactionsUseCase : ISearchTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public SearchTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>?> Execute(string cashierName, DateTime beagineDate, DateTime endDate)
    {
        return await _transactionRepository.SearchTransactions(cashierName, beagineDate, endDate);
    }
}

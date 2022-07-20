namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class GetTransactionsUseCase : IGetTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction>? Execute()
    {
        return _transactionRepository.GetTransactions();
    }
}

namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class GetTransactionsUseCase : IGetTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>?> Execute()
    {
        return await _transactionRepository.GetTransactions();
    }
}

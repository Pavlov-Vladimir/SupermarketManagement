namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class GetTransactionsByDateUseCase : IGetTransactionsByDateUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsByDateUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>?> Execute(DateTime date)
    {
        return await _transactionRepository.GetByDate(date);
    }
}

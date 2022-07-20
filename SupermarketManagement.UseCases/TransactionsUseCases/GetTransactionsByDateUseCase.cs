namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class GetTransactionsByDateUseCase : IGetTransactionsByDateUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsByDateUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction>? Execute(DateTime date)
    {
        return _transactionRepository.GetByDate(date);
    }
}

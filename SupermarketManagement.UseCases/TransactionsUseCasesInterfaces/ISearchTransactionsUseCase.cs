namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface ISearchTransactionsUseCase
{
    Task<IEnumerable<Transaction>?> Execute(string cashierName, DateTime beagineDate, DateTime endDate);
}
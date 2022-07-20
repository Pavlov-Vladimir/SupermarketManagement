namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface ISearchTransactionsUseCase
{
    IEnumerable<Transaction>? Execute(string cashierName, DateTime beagineDate, DateTime endDate);
}
namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IRecordTransactionUseCase
{
    Task Execute(string cashierName, int productId, int qtySold);
}
namespace SupermarketManagement.UseCases.TransactionsUseCasesInterfaces;

public interface IRecordTransactionUseCase
{
    void Execute(string cashierName, int productId, int qtySold);
}
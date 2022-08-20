namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface ITransactionRepository
{
    void Save(string cashierName, int productId, int qtySold);
    IEnumerable<Transaction>? GetByDate(DateTime date);
    IEnumerable<Transaction>? GetTransactions();
    IEnumerable<Transaction>? SearchTransactions(string cashierName, DateTime beagineDate, DateTime endDate);
}

namespace SupermarketManagement.UseCases.DataStorePlaginInterfaces;
public interface ITransactionRepository
{
    Task Save(string cashierName, int productId,int qtySold);
    Task<IEnumerable<Transaction>?> GetByDate(DateTime date);
    Task<IEnumerable<Transaction>?> GetTransactions();
    Task<IEnumerable<Transaction>?> SearchTransactions(string cashierName, DateTime beagineDate, DateTime endDate);
}

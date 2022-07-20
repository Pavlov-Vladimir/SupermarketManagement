namespace SupermarketManagement.UseCases.TransactionsUseCases;
public class RecordTransactionUseCase : IRecordTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IProductRepository _productRepository;

    public RecordTransactionUseCase(ITransactionRepository transactionRepository, IProductRepository productRepository)
    {
        _transactionRepository = transactionRepository;
        _productRepository = productRepository;
    }

    public void Execute(string cashierName, int productId, int qtySold)
    {
        var product = _productRepository.GetProduct(productId);
        if (product == null)
            return;

        _transactionRepository.Save(cashierName, productId, qtySold);
    }
}

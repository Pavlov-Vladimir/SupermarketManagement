namespace SupermarketManagement.UseCases.ProductsUseCases;
public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Execute(int productId, int qtyToSell)
    {
        if (qtyToSell < 0)
            throw new ArgumentOutOfRangeException("Reason", "The quantity must be a positive number.");

        var product = _productRepository.GetProduct(productId);
        if (product is null)
            return;

        product.Quantity -= qtyToSell;
        _productRepository.UpdateProduct(product);
    }
}

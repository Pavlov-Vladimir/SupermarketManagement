namespace SupermarketManagement.UseCases;
public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;

    public SellProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(int productId, int qtyToSell)
    {
        var product = await _productRepository.GetProduct(productId);
        if (product is null)
        {
            return;
        }
        product.Quantity -= qtyToSell;
        await _productRepository.UpdateProduct(product);
    }
}

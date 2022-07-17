namespace SupermarketManagement.UseCases;

public interface ISellProductUseCase
{
    Task Execute(int productId, int qtyToSell);
}
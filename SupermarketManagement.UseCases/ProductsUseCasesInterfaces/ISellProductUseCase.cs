namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface ISellProductUseCase
{
    Task Execute(int productId, int qtyToSell);
}
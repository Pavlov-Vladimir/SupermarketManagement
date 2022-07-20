namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface ISellProductUseCase
{
    void Execute(int productId, int qtyToSell);
}
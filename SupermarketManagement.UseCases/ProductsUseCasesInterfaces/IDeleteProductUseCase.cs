namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IDeleteProductUseCase
{
    Task Execute(int productId);
}
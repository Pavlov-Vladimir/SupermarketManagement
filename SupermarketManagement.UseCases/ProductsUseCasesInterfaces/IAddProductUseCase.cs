namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IAddProductUseCase
{
    Task Execute(Product product);
}
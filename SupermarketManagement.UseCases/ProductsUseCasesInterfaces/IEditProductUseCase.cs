namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IEditProductUseCase
{
    Task Execute(Product product);
}
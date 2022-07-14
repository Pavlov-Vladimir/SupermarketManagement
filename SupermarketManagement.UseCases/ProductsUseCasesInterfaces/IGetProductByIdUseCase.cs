namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IGetProductByIdUseCase
{
    Task<Product?> Execute(int productId);
}
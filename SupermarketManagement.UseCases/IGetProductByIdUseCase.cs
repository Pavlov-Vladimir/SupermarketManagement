namespace SupermarketManagement.UseCases;

public interface IGetProductByIdUseCase
{
    Task<Product?> Execute(int productId);
}
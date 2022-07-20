namespace SupermarketManagement.UseCases.ProductsUseCasesInterfaces;

public interface IGetProductByIdUseCase
{
    Product? Execute(int productId);
}
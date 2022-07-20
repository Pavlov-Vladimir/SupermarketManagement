﻿namespace SupermarketManagement.UseCases.ProductsUseCases;
public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product? Execute(int productId)
    {
        return _productRepository.GetProduct(productId);
    }
}

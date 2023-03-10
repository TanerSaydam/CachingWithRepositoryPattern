using CachingWithRepositoryPattern.DataAccess.Repositories.Products;
using CachingWithRepositoryPattern.Entities.Models;

namespace CachingWithRepositoryPattern.Business.Services.Products;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task<IList<Product>> GetAll()
    {
        return await _productRepository.GetAll();
    }
}

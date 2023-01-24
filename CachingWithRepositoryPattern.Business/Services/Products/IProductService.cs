using CachingWithRepositoryPattern.Entities.Models;

namespace CachingWithRepositoryPattern.Business.Services.Products;

public interface IProductService
{
    Task AddAsync(Product product);
    IQueryable<Product> GetAll();
}

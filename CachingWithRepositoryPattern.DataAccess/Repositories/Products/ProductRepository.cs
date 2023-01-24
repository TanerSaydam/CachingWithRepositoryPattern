using CachingWithRepositoryPattern.DataAccess.Context;
using CachingWithRepositoryPattern.Entities.Models;

namespace CachingWithRepositoryPattern.DataAccess.Repositories.Products;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}

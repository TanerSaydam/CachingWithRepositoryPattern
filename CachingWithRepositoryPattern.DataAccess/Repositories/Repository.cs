using CachingWithRepositoryPattern.DataAccess.Context;

namespace CachingWithRepositoryPattern.DataAccess.Repositories;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();  
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsQueryable();
    }
}

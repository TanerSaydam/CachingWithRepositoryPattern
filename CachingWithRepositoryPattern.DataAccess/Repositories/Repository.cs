using CachingWithRepositoryPattern.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace CachingWithRepositoryPattern.DataAccess.Repositories;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _memoryCache;
    public Repository(AppDbContext context)
    {
        _context = context;
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>()!;  
    }

    public async Task AddAsync(T entity)
    {
        var table = _context.Set<T>();
        string tableName = table.EntityType.ConstructorBinding.RuntimeType.Name;
        string key = $"{tableName}.GetAll";

        _memoryCache.Remove(key);

        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();  
    }   
    
    public async Task<IList<T>> GetAll()
    {
        var entity = _context.Set<T>();
        string tableName = entity.EntityType.ConstructorBinding.RuntimeType.Name;
        string key = $"{tableName}.GetAll";

        return await _memoryCache.GetOrCreateAsync(
            key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
                return await _context.Set<T>().ToListAsync();
            });
    }

    public async Task<T> GetById(int id)
    {
        var entity = _context.Set<T>();
        string tableName = entity.EntityType.ConstructorBinding.RuntimeType.Name;
        string key = $"{tableName}.GetById.{id}";

        return await _memoryCache.GetOrCreateAsync(
            key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(60));
                return await _context.Set<T>().FindAsync(id);
            })
    }
}

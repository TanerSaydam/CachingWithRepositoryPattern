namespace CachingWithRepositoryPattern.DataAccess.Repositories;

public interface IRepository<T>
    where T : class
{
    Task AddAsync(T entity);    
    Task<IList<T>> GetAll();
}

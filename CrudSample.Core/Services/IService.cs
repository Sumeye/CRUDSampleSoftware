namespace CrudSample.Core.Services
{
    public interface IService<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T updateEntity, T setEntity);
        Task RemoveAsync(T entity);
    }
}

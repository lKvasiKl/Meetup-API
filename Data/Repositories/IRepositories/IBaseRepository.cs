using Data.Entities;

namespace Data.IRepositories
{
    public interface IBaseRepository<TEntity, T>
        where TEntity : Entity<T>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(T id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

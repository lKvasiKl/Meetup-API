using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity, T>
        where TEntity : Entity<T>
    {
        protected readonly MeetupContext _meetupContext;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
            DbSet = _meetupContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = DbSet.Add(entity);
            await _meetupContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public virtual async Task<TEntity> GetByIdAsync(T id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity).Entity;
            await _meetupContext.SaveChangesAsync();

            return updatedEntity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _meetupContext.SaveChangesAsync();
        }
    }
}

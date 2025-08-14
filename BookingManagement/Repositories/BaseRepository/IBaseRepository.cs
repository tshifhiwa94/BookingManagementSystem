using System.Linq.Expressions;

namespace BookingManagement.Repositories.BaseRepositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }

}

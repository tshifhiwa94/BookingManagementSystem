using BookingManagement.Data;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingManagement.Repositories.BaseRepository
{

    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly BookManagementDbContext _context;
        public BaseRepository(BookManagementDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            if (entity is RecordEntity<Guid> recordEntity)
            {
                recordEntity.CreationTime = DateTime.UtcNow;
                recordEntity.CreatedBy = Guid.NewGuid();
            }

            await _context.SaveChangesAsync();
            return entity;
        }


        public Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Check if TEntity is a subclass of RecordEntity<TKey> and apply IsDeleted filter
            if (typeof(RecordEntity<TKey>).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(e => !(e as RecordEntity<Guid>).IsDeleted);
            }
            // Apply includes
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Apply includes
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            // Filter by Id
            query = query.Where(e => EF.Property<TKey>(e, "Id").Equals(id));

            // Check if TEntity is a subclass of RecordEntity<TKey> and apply IsDeleted filter
            if (typeof(RecordEntity<TKey>).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(e => !(e as RecordEntity<TKey>).IsDeleted);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity is RecordEntity<Guid> recordEntity)
            {
                recordEntity.LastModificationTime = DateTime.UtcNow;
                recordEntity.LastModifiedBy = Guid.NewGuid();
            }

            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                return false;

            if (entity is RecordEntity<Guid> recordEntity)
            {
                recordEntity.DeletionTime = DateTime.UtcNow;
                recordEntity.DeletedBy = Guid.NewGuid();
                recordEntity.IsDeleted = true;
            }

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

using BackendDeveloperProject.Core.Models;
using BackendDeveloperProject.Core.Repositories;
using BackendDeveloperProject.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BackendDeveloperProject.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string? include = null, string? prefix = null)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(include))
            {
                query = query.Include(include);
            }
            if (!string.IsNullOrEmpty(prefix))
            {
                query = query.Where(x => x.Name.Contains(prefix));
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, string? include = null)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(include))
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(int id, string? include = null)
        {
            var entity = await GetByIdAsync(id, include);
            if (entity != null)
                _dbSet.Remove(entity);
        }
    }
}

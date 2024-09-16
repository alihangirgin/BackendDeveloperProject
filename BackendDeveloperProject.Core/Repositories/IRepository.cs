using BackendDeveloperProject.Core.Models;

namespace BackendDeveloperProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(string? include = null);
        Task<TEntity?> GetByIdAsync(int id, string? include = null);
        Task DeleteAsync(int id, string? include = null);
    }
}

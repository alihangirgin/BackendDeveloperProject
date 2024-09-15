using BackendDeveloperProject.Core.Models;

namespace BackendDeveloperProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}

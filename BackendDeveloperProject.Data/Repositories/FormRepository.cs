using BackendDeveloperProject.Core.Models;
using BackendDeveloperProject.Core.Repositories;
using BackendDeveloperProject.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BackendDeveloperProject.Data.Repositories
{
    public class FormRepository : Repository<Form>, IFormRepository
    {
        public FormRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

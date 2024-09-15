using BackendDeveloperProject.Core.Repositories;
using BackendDeveloperProject.Core.UnitOfWork;
using BackendDeveloperProject.Data.DataAccess;
using BackendDeveloperProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private FormRepository _formRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IFormRepository Forms => _formRepository = _formRepository ?? new FormRepository(_dbContext);


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

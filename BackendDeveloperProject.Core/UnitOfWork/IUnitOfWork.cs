using BackendDeveloperProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperProject.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFormRepository Forms { get; }
        Task<int> Commit();
    }
}

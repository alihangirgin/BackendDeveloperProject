using BackendDeveloperProject.Core.Dtos;
using BackendDeveloperProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperProject.Core.Services
{
    public interface IFormService
    {
        Task AddFormAsync(FormDto model);
        Task<FormDto?> GetFormAsync(int id);
        Task<IEnumerable<FormDto>> GetFormsAsync(string? prefix = null);
        Task DeleteFormAsync(int id);
    }
}

using BackendDeveloperProject.Core.Dtos;
using BackendDeveloperProject.Core.Models;
using BackendDeveloperProject.Core.Services;
using BackendDeveloperProject.Core.UnitOfWork;

namespace BackendDeveloperProject.Business
{
    public class FormService : IFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddFormAsync(FormDto model)
        {
            Form formEntity = new()
            {
                Description = model.Description,
                Name = model.Name,
                Fields = model.Fields.Select(x=> new Field()
                {
                    DataType = x.DataType,
                    Name = x.Name,
                    Required = x.Required,
                }).ToList()
            };
            await _unitOfWork.Forms.AddAsync(formEntity);
            await _unitOfWork.Commit();
        }
    }
}

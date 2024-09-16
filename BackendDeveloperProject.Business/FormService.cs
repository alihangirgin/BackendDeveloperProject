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
                Fields = model.Fields.Select(x => new Field()
                {
                    DataType = x.DataType,
                    Name = x.Name,
                    Required = x.Required,
                }).ToList()
            };
            await _unitOfWork.Forms.AddAsync(formEntity);
            await _unitOfWork.Commit();
        }

        public async Task<FormDto?> GetFormAsync(int id)
        {
            var form = await _unitOfWork.Forms.GetByIdAsync(id, "Fields");
            if (form == null) return null;
            return new FormDto()
            {
                Id = id,
                CreatedBy = form.CreatedBy,
                Description = form.Description,
                Name = form.Name,
                Fields = form.Fields.Select(x => new FieldDto()
                {
                    Name = x.Name,
                    DataType = x.DataType,
                    Required = x.Required
                }).ToList()
            };
        }

        public async Task<IEnumerable<FormDto>> GetFormsAsync()
        {
            var forms = await _unitOfWork.Forms.GetAllAsync("Fields");
            return forms.Select(x => new FormDto()
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                Description = x.Description,
                Name = x.Name,
                Fields = x.Fields.Select(y => new FieldDto() {
                    Name = y.Name,
                    DataType = y.DataType,
                    Required = y.Required
                }).ToList()
            }).ToList();
        }

        public async Task DeleteFormAsync(int id)
        {
            await _unitOfWork.Forms.DeleteAsync(id, "Fields");
            await _unitOfWork.Commit();
        }
    }
}

using BackendDeveloperProject.Core.Models;

namespace BackendDeveloperProject.Core.Dtos
{
    public class FormDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public virtual List<FieldDto> Fields { get; set; }
    }
}

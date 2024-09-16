using BackendDeveloperProject.Core.Models;

namespace BackendDeveloperProject.Core.Dtos
{
    public class FormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public virtual List<FieldDto> Fields { get; set; }
    }
}

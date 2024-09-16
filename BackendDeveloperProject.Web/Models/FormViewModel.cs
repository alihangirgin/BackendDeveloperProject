using BackendDeveloperProject.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace BackendDeveloperProject.Web.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Form adı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Form Açıklama gereklidir.")]
        public string Description { get; set; }
        public virtual List<FieldViewModel> Fields { get; set; }
    }
}

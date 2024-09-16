using System.ComponentModel.DataAnnotations;

namespace BackendDeveloperProject.Web.Models
{
    public class FieldViewModel
    {
        public bool Required { get; set; }
        [Required(ErrorMessage = "Field adı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field Veri tipi gereklidir.")]
        public string DataType { get; set; }
    }
}

namespace BackendDeveloperProject.Core.Models
{
    public class Form : Entity
    {
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}

namespace BackendDeveloperProject.Core.Models
{
    public class Form : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}

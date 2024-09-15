namespace BackendDeveloperProject.Core.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}

namespace projectEF.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

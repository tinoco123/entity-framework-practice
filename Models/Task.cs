namespace projectEF.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public virtual Category Categoria { get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}

namespace projectEF.Models
{
    public class Task
    {
        // [Key]
        public Guid TaskId { get; set; }
        // [ForeignKey("Category")]
        public Guid CategoriaId { get; set; }
        // [Required]
        // [MaxLength(30, ErrorMessage = "El nombre de la tarea no debe exceder los 30 caracteres"), MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public virtual Category Categoria { get; set; }
        // [NotMapped]
        public string Resume { get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}

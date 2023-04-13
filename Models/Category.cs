using System.ComponentModel.DataAnnotations;

namespace projectEF.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage="El nombre de la tarea no debe exceder los 30 caracteres"), MinLength(3)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

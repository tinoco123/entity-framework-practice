using Microsoft.EntityFrameworkCore;
using projectEF.Models;

public class TasksContext : DbContext
{
    public DbSet<projectEF.Models.Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categories = new List<Category>();
        categories.Add(new Category() { CategoryId = Guid.Parse("24d8f5ca-2451-463d-9ead-db339b16af4e"), Nombre = "Universidad", Peso = 50 });
        categories.Add(new Category() { CategoryId = Guid.Parse("7ab81c93-7b17-43b1-9557-ec31ae80fa71"), Nombre = "Grupo de alabanza", Peso = 50, Descripcion = "Canciones del grupo de alabanza" });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Categoria");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Nombre).IsRequired().HasMaxLength(30);
            category.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(300);
            category.Property(p => p.Peso);
            category.HasData(categories);
        });

        List<projectEF.Models.Task> tasks = new List<projectEF.Models.Task>();
        tasks.Add(new projectEF.Models.Task() { TaskId = Guid.Parse("b35e2399-5842-4199-bf75-26511adde087"), CategoriaId = Guid.Parse("24d8f5ca-2451-463d-9ead-db339b16af4e"), DateCreated = DateTime.Now, Deadline = new DateTime(2023, 04, 20, 15, 30, 0), PrioridadTarea = Prioridad.Alta, Title = "Estudiar diagramas de clase" });
        tasks.Add(new projectEF.Models.Task() { TaskId = Guid.Parse("633e026b-489e-4960-bd01-ed5736ab1b6c"), CategoriaId = Guid.Parse("7ab81c93-7b17-43b1-9557-ec31ae80fa71"), DateCreated = DateTime.Now, Deadline = new DateTime(2023, 04, 18, 15, 30, 0), PrioridadTarea = Prioridad.Alta, Title = "Mandar canciones para el domingo" });

        modelBuilder.Entity<projectEF.Models.Task>(task =>
        {
            task.ToTable("Tarea");
            task.HasKey(p => p.TaskId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(100);
            task.Property(p => p.Description).IsRequired(false).HasMaxLength(300);
            task.Property(p => p.DateCreated);
            task.Property(p => p.PrioridadTarea);
            task.Ignore(p => p.Resume);
            task.HasOne<Category>(c => c.Categoria)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.CategoriaId);
            task.HasData(tasks);
        });
    }
}
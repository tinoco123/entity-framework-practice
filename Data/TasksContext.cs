using Microsoft.EntityFrameworkCore;
using projectEF.Models;

public class TasksContext: DbContext
{
    public DbSet<projectEF.Models.Task> Tasks { get; set;}
    public DbSet<Category> Categories { get; set;}

    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Categoria");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Nombre).IsRequired().HasMaxLength(30);
            category.Property(p => p.Descripcion).HasMaxLength(300);
        });

        modelBuilder.Entity<projectEF.Models.Task>(task =>
        {
            task.ToTable("Tarea");
            task.HasKey(p => p.TaskId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(100);
            task.Property(p => p.Description).HasMaxLength(300);
            task.Property(p => p.DateCreated);
            task.Property(p => p.PrioridadTarea);
            task.Ignore(p => p.Resume);
            task.HasOne<Category>(c => c.Categoria)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.CategoriaId);

        });
    }
}
using Microsoft.EntityFrameworkCore;
using projectEF.Models;

public class TasksContext: DbContext
{
    public DbSet<projectEF.Models.Task> Tasks { get; set;}
    public DbSet<Category> Categories { get; set;}

    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
        
    }
}
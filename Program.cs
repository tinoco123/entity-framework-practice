using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("TasksConnection"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en SQLServer: " + dbContext.Database.IsSqlServer());
});

app.MapGet("/eliminardb", async([FromServices] TasksContext dbContext) =>
// Drop the database if it exists
{
    
    return Results.Ok(dbContext.Database.EnsureDeleted());
});

app.MapGet("/api/tareas", async([FromServices] TasksContext dbContext ) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Categoria).Where(p => p.Deadline > DateTime.Now));
});

app.MapPost("/api/tareas", async ([FromServices] TasksContext dbContext, [FromBody] projectEF.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.DateCreated = DateTime.Now;
    await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("api/tareas/{id}", async([FromServices] TasksContext dbContext, [FromBody] projectEF.Models.Task task, [FromRoute] Guid id) =>
{
    projectEF.Models.Task tareaActual = dbContext.Tasks.Find(id);
    if (tareaActual != null)
    {
        tareaActual.Title = task.Title;
        tareaActual.CategoriaId = task.CategoriaId;
        tareaActual.Description = task.Description;
        tareaActual.Deadline = task.Deadline;
        tareaActual.PrioridadTarea = task.PrioridadTarea;

        await dbContext.SaveChangesAsync();
        return Results.Ok();

    }

    return Results.NotFound();
});
app.Run();

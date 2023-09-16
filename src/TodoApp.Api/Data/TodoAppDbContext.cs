using Microsoft.EntityFrameworkCore;

namespace TodoApp.Api.Data;
public class TodoAppDbContext : DbContext
{
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
    {
    }

    public DbSet<TodoApp.Api.Entities.Task> Tasks { get; set; }
}

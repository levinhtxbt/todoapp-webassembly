using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Entities;

namespace TodoApp.Api.Data;
public class TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Entities.Task> Tasks { get; set; }
}

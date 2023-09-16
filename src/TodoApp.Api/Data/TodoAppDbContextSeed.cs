using Microsoft.AspNetCore.Identity;
using TodoApp.Api.Entities;
using TodoApp.Model.Enums;

namespace TodoApp.Api.Data;

public class TodoAppDbContextSeed
{
    private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
    public async System.Threading.Tasks.Task SeedAsync(TodoAppDbContext context, ILogger<TodoAppDbContext> logger)
    {
        if (!context.Users.Any())
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mr",
                LastName = "A",
                Email = "admin1@gmail.com",
                NormalizedEmail = "ADMIN1@GMAIL.COM",
                PhoneNumber = "032132131",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
            context.Users.Add(user);
        }

        if (!context.Tasks.Any())
        {
            context.Tasks.Add(new Entities.Task()
            {
                Id = Guid.NewGuid(),
                Title = "Same tasks 1",
                CreatedAt = DateTime.Now,
                Priority = Priority.High,
                Status = Status.Todo
            });
        }

        await context.SaveChangesAsync();

    }
}

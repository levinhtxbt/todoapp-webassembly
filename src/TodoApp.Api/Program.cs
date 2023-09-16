using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoApp.Api.Data;
using TodoApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApp Api", Version = "v1" });
    c.EnableAnnotations();
});
builder.Services.AddDbContext<TodoAppDbContext>(options =>
    options.UseSqlite("Data Source=TodoApp.db"));
var app = builder.Build();
app.MigrateDbContext<TodoAppDbContext>((context, services) =>
{
    var logger = services.GetRequiredService<ILogger<TodoAppDbContext>>();
    new TodoAppDbContextSeed().SeedAsync(context, logger).Wait();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
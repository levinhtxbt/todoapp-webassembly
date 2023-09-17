using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints
{
    public class AddNewTask(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<NewTaskDto>
        .WithActionResult
    {
        [HttpPost("/api/tasks")]
        [SwaggerOperation(
            Summary = "Add new task",
            Description = "Add new task",
            OperationId = "Task.Add",
            Tags = new[] { "TaskEndpoints" })]
        public override async Task<ActionResult> HandleAsync(NewTaskDto request, CancellationToken cancellationToken = default)
        {
            var task = new Entities.Task
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = Model.Enums.Status.Todo,
                CreatedAt = DateTime.Now
            };
            dbContext.Tasks.Add(task);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new StatusCodeResult(201);
        }
    }
}
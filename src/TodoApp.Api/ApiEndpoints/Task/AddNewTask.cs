using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;
using TodoApp.Model.Enums;

namespace TodoApp.Api.ApiEndpoints.Task
{
    public class AddNewTask(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<NewTaskDto>
        .WithActionResult<TaskDto>
    {
        [HttpPost("/api/tasks")]
        [SwaggerOperation(
            Summary = "Add new task",
            Description = "Add new task",
            OperationId = "Task.Add",
            Tags = new[] { "TaskEndpoints" })]
        public override async Task<ActionResult<TaskDto>> HandleAsync(NewTaskDto request, CancellationToken cancellationToken = default)
        {
            var task = new Entities.Task
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority.HasValue ? request.Priority.Value : Priority.Low,
                Status = Model.Enums.Status.Todo,
                CreatedAt = DateTime.Now
            };
            dbContext.Tasks.Add(task);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return StatusCode(201, new TaskDto()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                Status = task.Status,
                CreatedAt = task.CreatedAt,
                AssigneeId = task.AssigneeId
            });
        }
    }
}
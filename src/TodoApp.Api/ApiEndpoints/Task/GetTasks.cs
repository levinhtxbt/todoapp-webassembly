using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints.Task
{
    public class GetTasks(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<SearchTaskDto>
        .WithActionResult<List<TaskDto>>
    {
        [HttpGet("/api/tasks")]
        [SwaggerOperation(
            Summary = "Get all tasks",
            Description = "Get all tasks",
            OperationId = "Task.GetAll",
            Tags = new[] {"TaskEndpoints"})]
        public override async Task<ActionResult<List<TaskDto>>> HandleAsync(
            [FromQuery] SearchTaskDto request, CancellationToken cancellationToken = new())
        {
            var task = await dbContext.Tasks
                .Include(inc => inc.Assignee)
                .Where(w => request.AssigneeId == null || w.AssigneeId == request.AssigneeId)
                .Where(w => request.Status == null || w.Status == request.Status)
                .Where(w => request.Priority == null || w.Priority == request.Priority)
                .Where(w => request.Title == null || w.Title.Contains(request.Title))
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedAt = t.CreatedAt,
                    AssigneeId = t.AssigneeId,
                    AssigneeName = t.Assignee != null ? $"{t.Assignee.FirstName} {t.Assignee.LastName}" : null,
                    Status = t.Status,
                    Priority = t.Priority
                })
                .ToListAsync(cancellationToken);

            return Ok(task);
        }
    }
}
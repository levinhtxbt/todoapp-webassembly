using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints.Task
{
    public class UpdateTask(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<UpdateTaskDto>
        .WithActionResult
    {
        [HttpPut("/api/tasks/{id}")]
        [SwaggerOperation(
            Summary = "Update a Task",
            Description = "Update a Task",
            OperationId = "Task.Update",
            Tags = new[] {"TaskEndpoints"})]
        public override async Task<ActionResult> HandleAsync([FromRoute] UpdateTaskDto request,
            CancellationToken cancellationToken = default)
        {
            var task = await dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id.ToString().ToLower() == request.Id.ToLower(),
                    cancellationToken: cancellationToken);
            if (task == null)
            {
                return NotFound($"Task {request.Id} not found");
            }

            task.Title = request.Data.Title;
            task.Description = request.Data.Description;
            task.AssigneeId = request.Data.AssigneeId;
            task.Status = request.Data.Status;
            task.Priority = request.Data.Priority;

            dbContext.Tasks.Update(task);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}
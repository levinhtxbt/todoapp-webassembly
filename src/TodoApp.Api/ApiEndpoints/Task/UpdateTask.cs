using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints.Task
{
    public class UpdateTask(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<UpdateTaskRequest>
        .WithActionResult
    {
        [HttpPut("/api/tasks/{id}")]
        [SwaggerOperation(
            Summary = "Update a Task",
            Description = "Update a Task",
            OperationId = "Task.Update",
            Tags = new[] {"TaskEndpoints"})]
        public override async Task<ActionResult> HandleAsync([FromRoute] UpdateTaskRequest request,
            CancellationToken cancellationToken = default)
        {
            var task = await dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id.ToString().ToLower() == request.Id.ToLower(),
                    cancellationToken: cancellationToken);
            if (task == null)
            {
                return NotFound($"Task {request.Id} not found");
            }

            task.Title = request.Dto.Title;
            task.Description = request.Dto.Description;
            task.AssigneeId = request.Dto.AssigneeId;
            task.Status = request.Dto.Status;
            task.Priority = request.Dto.Priority;

            dbContext.Tasks.Update(task);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }

    // We have to rewrite the request because Shared Model doesn't work with FromRoute and FromBody
    public class UpdateTaskRequest
    {
        [FromRoute(Name = "id")]
        public new string Id { get; set; }

        [FromBody]
        public new UpdateTaskDto Dto { get; set; }
    }
}
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;

namespace TodoApp.Api.ApiEndpoints.Task
{
    public class DeleteTask(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult
    {
        [HttpDelete("/api/tasks/{id}")]
        [SwaggerOperation(
            Summary = "Delete a Task",
            Description = "Delete a Task",
            OperationId = "Task.Delete",
            Tags = new[] { "TaskEndpoints" })]
        public override async Task<ActionResult> HandleAsync([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var task = dbContext.Tasks.FirstOrDefault(x => x.Id.ToString().ToLower() == id.ToLower());
            if (task == null)
            {
                return NotFound($"Task {id} not found");
            }
            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
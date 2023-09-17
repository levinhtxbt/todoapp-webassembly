using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints
{
    public class GetTaskById(TodoAppDbContext dbContext) : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult<TaskDto>
    {
        [HttpGet("/api/tasks/{id}")]
        [SwaggerOperation(
            Summary = "Get a Task by Id",
            Description = "Get a Task by Id",
            OperationId = "Task.GetById",
            Tags = new[] {"TaskEndpoints"})]
        public override async Task<ActionResult<TaskDto>> HandleAsync([FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(2000, cancellationToken);
            var task = await dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id.ToString().ToLower() == id.ToLower(),
                    cancellationToken: cancellationToken);
            if (task == null)
            {
                return NotFound($"Task {id} not found");
            }

            return Ok(task);
        }
    }
}
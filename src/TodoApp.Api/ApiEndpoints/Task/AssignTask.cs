using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints.Task;

public class AssignTask(TodoAppDbContext dbContext) : EndpointBaseAsync
    .WithRequest<AssignTaskDto>
    .WithActionResult
{
    [HttpPost("/api/tasks/assign")]
    [SwaggerOperation(
        Summary = "Assign a Task",
        Description = "Assign a Task",
        OperationId = "Task.Assign",
        Tags = new[] {"TaskEndpoints"})]
    public override async Task<ActionResult> HandleAsync(AssignTaskDto request,
        CancellationToken cancellationToken = new())
    {
        var task = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId,
            cancellationToken: cancellationToken);
        if (task == null)
        {
            return NotFound($"Task {request.TaskId} not found");
        }
        
        task.AssigneeId = request.AssigneeId;

        dbContext.Tasks.Update(task);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}
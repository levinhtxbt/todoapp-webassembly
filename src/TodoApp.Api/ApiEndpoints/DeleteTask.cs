using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;

namespace TodoApp.Api.ApiEndpoints
{
    public class DeleteTask : EndpointBaseAsync.WithRequest<string>.WithActionResult
    {
        private readonly TodoAppDbContext _dbContext;
        public DeleteTask(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete("/api/tasks/{id}")]
        [SwaggerOperation(
            Summary = "Delete a Task",
            Description = "Delete a Task",
            OperationId = "Task.Delete",
            Tags = new[] { "TaskEndpoints" })]
        public override async Task<ActionResult> HandleAsync([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id.ToString().ToLower() == id.ToLower());
            if (task == null)
            {
                return NotFound($"Task {id} not found");
            }
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
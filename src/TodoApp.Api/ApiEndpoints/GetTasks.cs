using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints
{
    public class GetTasks : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<List<TaskDto>>
    {
        private readonly TodoAppDbContext _dbContext;

        public GetTasks(TodoAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("/api/tasks")]
        [SwaggerOperation(
            Summary = "Get all tasks",
            Description = "Get all tasks",
            OperationId = "Task.GetAll",
            Tags = new[] { "TaskEndpoints" })]
        public override async Task<ActionResult<List<TaskDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var task = await _dbContext.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                AssigneeId = t.AssigneeId,
                Status = t.Status,
                Priority = t.Priority
            }).ToListAsync(cancellationToken);

            return Ok(task);
        }
    }
}
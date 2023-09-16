using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto;

namespace TodoApp.Api.ApiEndpoints
{
    public class AddNewTask : EndpointBaseAsync.WithRequest<NewTaskDto>.WithActionResult
    {
        private readonly TodoAppDbContext _dbContext;

        public AddNewTask(TodoAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

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
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return new StatusCodeResult(201);
        }
    }
}
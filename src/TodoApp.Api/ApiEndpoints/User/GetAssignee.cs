using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Api.Data;
using TodoApp.Model.Dto.User;

namespace TodoApp.Api.ApiEndpoints.User;

public class GetAssignee : EndpointBaseAsync.WithoutRequest.WithActionResult<AssigneeDto>
{
    private readonly TodoAppDbContext _dbContext;

    public GetAssignee(TodoAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("/api/users/assignees")]
    [SwaggerOperation(
        Summary = "Get all assignees",
        Description = "Get all assignees",
        OperationId = "Assignee.GetAll",
        Tags = new[] {"AssigneeEndpoints"})]
    public override async Task<ActionResult<AssigneeDto>> HandleAsync(
        CancellationToken cancellationToken = new CancellationToken())
    {
        var users = await _dbContext.Users.Select(x => new AssigneeDto
        {
            Id = x.Id,
            Name = $"{x.FirstName} {x.LastName}"
        }).ToListAsync(cancellationToken);

        return Ok(users);
    }
}
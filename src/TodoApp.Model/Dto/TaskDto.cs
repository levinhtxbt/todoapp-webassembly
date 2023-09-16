using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto;

public class TaskDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public Guid? AssigneeId { get; set; }

    public Status Status { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Api.Enums;

namespace TodoApp.Api.Entities;

public class Task
{

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Assignee { get; set; }

    public Enums.Status Status { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }




}

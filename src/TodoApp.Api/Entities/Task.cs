using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Api.Enums;

namespace TodoApp.Api.Entities;

public class Task
{

    [Key]
    public Guid Id { get; set; }

    [MaxLength(255)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; } = string.Empty;

    public Guid? AssigneeId { get; set; }

    [ForeignKey(nameof(AssigneeId))]
    public User? Assignee { get; set; }

    public Status Status { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

}

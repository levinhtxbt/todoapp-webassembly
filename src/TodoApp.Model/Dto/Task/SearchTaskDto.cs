using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto;

public class SearchTaskDto
{
    public string? Title { get; set; }

    public Guid? AssigneeId { get; set; }

    public Status? Status { get; set; }
    
    public Priority? Priority { get; set; }
}
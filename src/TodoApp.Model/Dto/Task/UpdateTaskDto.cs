using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto
{
    public class UpdateTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Guid? AssigneeId { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }
    }
}
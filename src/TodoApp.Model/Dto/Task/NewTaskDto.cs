using System.ComponentModel.DataAnnotations;
using TodoApp.Model.Enums;

namespace TodoApp.Model.Dto
{
    public class NewTaskDto
    {
        [MaxLength(100, ErrorMessage = "Title is too long (100 characters limit)")]
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public Priority? Priority { get; set; }
        
        public Guid? AssigneeId { get; set; }
    }
}
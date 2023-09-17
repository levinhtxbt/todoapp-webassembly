using Refit;
using TodoApp.Model.Dto;

namespace TodoApp.Web.Services;

public interface ITaskApiServices
{
    [Get("/api/tasks")]
    Task<List<TaskDto>> GetTasksAsync();

    [Get("/api/tasks/{id}")]
    Task<TaskDto> GetTaskByIdAsync(string id);

    [Post("/api/tasks")]
    Task<TaskDto> CreateTaskAsync([Body] NewTaskDto taskDto);

    [Put("/api/tasks/{id}")]
    Task<TaskDto> UpdateTaskAsync(string id, [Body]TaskDto taskDto);
    
    [Delete("/api/tasks/{id}")]
    Task DeleteTaskAsync(string id);
}
using Refit;
using TodoApp.Model.Dto;

namespace TodoApp.Wasm.Services;

public interface ITaskApiServices
{
    [Get("/api/tasks")]
    Task<List<TaskDto>> GetTasksAsync([Query] SearchTaskDto searchTaskDto);

    [Get("/api/tasks/{id}")]
    Task<TaskDto> GetTaskByIdAsync(string id);

    [Post("/api/tasks")]
    Task<TaskDto> CreateTaskAsync([Body] NewTaskDto taskDto);

    [Put("/api/tasks/{id}")]
    Task UpdateTaskAsync(string id, [Body] UpdateTaskDto taskDto);

    [Post("/api/tasks/assign")]
    Task AssignTaskAsync([Body] AssignTaskDto taskDto);

    [Delete("/api/tasks/{id}")]
    Task DeleteTaskAsync(string id);
}
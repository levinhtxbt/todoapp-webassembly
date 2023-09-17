using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class Todo
{
    private IEnumerable<TaskDto> _tasks = new List<TaskDto>();

    [Inject]
    private ITaskApiServices _taskApiServices { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        _tasks = await _taskApiServices.GetTasksAsync();
    }
    
}
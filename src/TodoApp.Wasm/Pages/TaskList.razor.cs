using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskList
{
    private IEnumerable<TaskDto> tasks = new List<TaskDto>();

    [Inject]
    private ITaskApiServices taskApiServices { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        tasks = await taskApiServices.GetTasksAsync();
    }
    
}
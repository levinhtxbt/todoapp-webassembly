using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskDetail
{
    [Parameter]
    public string Id { get; set; }
    
    [Inject]
    private ITaskApiServices _taskApiServices { get; set; }

    private TaskDto? task;
    
    protected override async Task OnInitializedAsync()
    {
        task = await _taskApiServices.GetTaskByIdAsync(Id);
    }
}
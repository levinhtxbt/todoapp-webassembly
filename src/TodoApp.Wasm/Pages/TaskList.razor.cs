using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Model.Dto.User;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskList
{
    private IEnumerable<TaskDto> tasks;

    private SearchTaskDto searchQuery = new();
    
    private List<AssigneeDto> assignees = new();
    
    
    [Inject]
    private ITaskApiServices taskApiServices { get; set; }
    
    [Inject]
    private IUserApiService UserApiService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
        assignees = await UserApiService.GetAssigneesAsync();
    }

    private async Task Search()
    {
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }

    private async Task ClearSearch()
    {
        searchQuery.Priority = null;
        searchQuery.Status = null;
        searchQuery.Title = null;
        searchQuery.AssigneeId = null;
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }
}


using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskList
{
    private IEnumerable<TaskDto> tasks;

    private SearchTaskDto searchQuery = new();

    [Inject]
    private ITaskApiServices taskApiServices { get; set; }

    protected override async Task OnInitializedAsync()
    {
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }

    private async Task OnSearch(SearchTaskDto searchQuery)
    {
        this.searchQuery = searchQuery;
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }
}
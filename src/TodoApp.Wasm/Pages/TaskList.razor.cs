using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TodoApp.Model.Dto;
using TodoApp.Wasm.Components;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskList
{
    private IEnumerable<TaskDto> tasks;

    private SearchTaskDto searchQuery = new();

    private Confirmation confirmation { get; set; }
    
    [Inject]
    private ITaskApiServices taskApiServices { get; set; }
    
    private Guid DeleteId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }

    private async Task OnSearch(SearchTaskDto searchQuery)
    {
        this.searchQuery = searchQuery;
        tasks = await taskApiServices.GetTasksAsync(searchQuery);
    }
    
    private void OnDelete(Guid id)
    {
        DeleteId = id;
        confirmation.Show();
        //confirmation.Show($"Are you sure you want to delete task {id}?", "Delete", OnConfirmDelete);
    }
    private async Task OnConfirmDelete()
    {
       await taskApiServices.DeleteTaskAsync(DeleteId.ToString());
       await OnSearch(searchQuery);
    }

    
}
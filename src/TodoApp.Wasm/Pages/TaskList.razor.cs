using System.Data;
using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;
using TodoApp.Model.Dto.User;
using TodoApp.Wasm.Components;
using TodoApp.Wasm.Services;

namespace TodoApp.Wasm.Pages;

public partial class TaskList
{
    private IEnumerable<TaskDto> tasks;

    private SearchTaskDto searchQuery = new();

    public MetaData MetaData { get; set; }

    private ConfirmationModal ConfirmationModal { get; set; }

    private AssignTaskModal AssignTaskModal { get; set; }

    [Inject]
    private ITaskApiServices taskApiServices { get; set; }

    private Guid DeleteId { get; set; }

    private Guid ItemId { get; set; }

    [CascadingParameter]
    public Error? Error { get; set; }

    protected override async Task OnInitializedAsync()
    {
        searchQuery.PageSize = 3;
        await OnSearch(searchQuery);
        Error.ProcessError(new EvaluateException("ABC"));
    }

    private async Task OnSearch(SearchTaskDto searchQuery)
    {
        this.searchQuery = searchQuery;

        var result = await taskApiServices.GetTasksAsync(searchQuery);

        MetaData = new MetaData(
            result.Page,
            result.TotalPages,
            result.HasPreviousPage,
            result.HasNextPage);

        tasks = result.Items;
    }

    private void DeleteTask(Guid id)
    {
        DeleteId = id;
        ConfirmationModal.Show("Are you sure you want to delete this task?");
    }

    private void AssignTask(Guid id)
    {
        ItemId = id;
        AssignTaskModal.Show();
    }

    private async Task OnDelete()
    {
        await taskApiServices.DeleteTaskAsync(DeleteId.ToString());
        await OnSearch(searchQuery);
    }

    private async Task OnAssignTask(AssigneeDto assignee)
    {
        await taskApiServices.AssignTaskAsync(new AssignTaskDto
        {
            TaskId = ItemId,
            AssigneeId = assignee.Id
        });

        await OnSearch(searchQuery);
    }

    private async Task OnPageSelected(int page)
    {
        searchQuery.Page = page;
        await OnSearch(searchQuery);
    }
}
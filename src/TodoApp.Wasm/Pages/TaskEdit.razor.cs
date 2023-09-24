using Microsoft.AspNetCore.Components;
using TodoApp.Model.Dto;

namespace TodoApp.Wasm.Pages;

public partial class TaskEdit
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    private UpdateTaskDto? UpdateTaskModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var task = await TaskApiServices.GetTaskByIdAsync(Id);

        UpdateTaskModel = new();
        UpdateTaskModel.Title = task.Title;
        UpdateTaskModel.Description = task.Description;
        UpdateTaskModel.AssigneeId = task.AssigneeId;
        UpdateTaskModel.Status = task.Status;
        UpdateTaskModel.Priority = task.Priority;
    }

    private async Task UpdateTaskAsync()
    {
        try
        {
            await TaskApiServices.UpdateTaskAsync(Id, UpdateTaskModel!);
            
            ToastService.ShowSuccess("Task updated successfully");
            NavManager.NavigateTo("/todo");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            ToastService.ShowError("Task update failed");
        }
    }
}
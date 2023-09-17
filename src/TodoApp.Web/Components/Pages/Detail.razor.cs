using Microsoft.AspNetCore.Components;
using TodoApp.Web.Services;
using TodoApp.Model.Dto;

namespace TodoApp.Web.Components.Pages;

public partial class Detail
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    
    [Inject]
    private ITaskApiServices _taskApiServices { get; set; }
    
    private TaskDto _task { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        _task = await _taskApiServices.GetTaskByIdAsync(Id);
    }
}
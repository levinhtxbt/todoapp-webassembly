using Microsoft.AspNetCore.Components;
using Refit;
using TodoApp.Model.Dto;
using TodoApp.Web.Services;

namespace TodoApp.Web.Components.Pages;

public partial class Todo
{
    private IEnumerable<TaskDto> _tasks;

    [Inject]
    private ITaskApiServices _taskApiServices { get; set; }

    [Inject]
    private IConfiguration _configuration { get; set; }

    [Inject]
    private HttpClient _httpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _tasks = await _httpClient.GetFromJsonAsync<List<TaskDto>>($"api/tasks");

        //_tasks = await _taskApiServices.GetTasksAsync();
        // var api = RestService.For<ITaskApiServices>(_configuration.GetValue<string>("Api")!);
        // _tasks = await api.GetTasksAsync();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            _tasks = await _taskApiServices.GetTasksAsync();
            StateHasChanged();
        }
    }
}
using Refit;
using TodoApp.Model.Dto.User;

namespace TodoApp.Wasm.Services;

public interface IUserApiService
{
    [Get("/api/users/assignees")]
    public Task<List<AssigneeDto>> GetAssigneesAsync();
}
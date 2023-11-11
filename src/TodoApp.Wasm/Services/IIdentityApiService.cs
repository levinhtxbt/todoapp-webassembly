using Refit;
using TodoApp.Model.Dto.Identity;

namespace TodoApp.Wasm.Services;

public interface IIdentityApiService
{
    [Post("/login")]
    Task<LoginResponse> LoginAsync([Body] LoginRequest loginRequest);

    
    [Get("/manage/info")]
    Task<ManageInfoResponse> GetManageInfoAsync([Header("Authorization")] string authorization);
    // [Post("/api/identity/register")]
    // Task RegisterAsync([Body] RegisterRequest registerRequest);
}
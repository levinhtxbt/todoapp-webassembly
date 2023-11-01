using Refit;
using TodoApp.Model.Dto.Identity;

namespace TodoApp.Wasm.Services;

public interface IIdentityApiService
{
    [Post("/login")]
    Task<LoginResponse> LoginAsync([Body] LoginRequest loginRequest);

    // [Post("/api/identity/register")]
    // Task RegisterAsync([Body] RegisterRequest registerRequest);
}
namespace TodoApp.Model.Dto.Identity;

public class LoginResponse
{
    public string TokenType { get; set; } = default!;

    public string AccessToken { get; set; } = default!;

    public string RefreshToken { get; set; } = default!;

    public int ExpiresIn { get; set; }
}
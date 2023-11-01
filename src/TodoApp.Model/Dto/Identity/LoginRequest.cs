using System.ComponentModel.DataAnnotations;

namespace TodoApp.Model.Dto.Identity;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
namespace TodoApp.Model.Dto.Identity;

public class ManageInfoResponse
{
    public string Email { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public Dictionary<string,string> Claims { get; set; }
}
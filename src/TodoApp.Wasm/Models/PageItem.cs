namespace TodoApp.Model.Dto;

public record PageItem(int Page, bool Enabled, string Text, bool Active = false)
{
    public bool Active { get; set; } = Active;
}

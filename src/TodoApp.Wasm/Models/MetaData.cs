namespace TodoApp.Model.Dto;

public record MetaData(int CurrentPage, int TotalPages, bool HasPrevious, bool HasNext)
{
    public int CurrentPage { get; set; } = CurrentPage;
    public int TotalPages { get; init; } = TotalPages;
    public bool HasPrevious { get; init; } = HasPrevious;
    public bool HasNext { get; init; } = HasNext;
}

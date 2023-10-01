namespace TodoApp.Model.Dto;

public class PaginationRequest
{
    public int Page { get; set; }
        = 1;

    public int PageSize { get; set; }
        = 10;

    public string? SortBy { get; set; }

    public bool IsSortAscending { get; set; }
}
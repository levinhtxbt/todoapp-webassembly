namespace TodoApp.Model.Dto;

public class PaginationRequest
{
    public int Page { get; set; }

    public int PageSize { get; set; }
        = 10;

    public string? SortBy { get; set; }

    public bool IsSortAscending { get; set; }
}
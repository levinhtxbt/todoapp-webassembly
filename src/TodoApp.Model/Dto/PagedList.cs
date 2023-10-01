namespace TodoApp.Model.Dto;

public class PagedList<TItem>
{
    public List<TItem> Items { get; set; }
        = new();

    public int TotalCount { get; set; }
    
    public int Page { get; set; }
    
    public int PageSize { get; set; }
    
    public int TotalPages => (int) Math.Ceiling(TotalCount / (double) PageSize);
    
    public bool HasPreviousPage => Page > 1;
    
    public bool HasNextPage => Page < TotalPages;
    
    

}
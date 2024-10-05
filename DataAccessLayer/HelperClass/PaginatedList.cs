using System.Collections;

namespace BusinessLogicLayer.DTOs.HelperClass;

public class PaginatedList<T> : IEnumerable
{
    public List<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public int TotalRecords { get; }

    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        TotalRecords = count;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
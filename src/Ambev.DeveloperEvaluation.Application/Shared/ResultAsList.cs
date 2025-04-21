namespace Ambev.DeveloperEvaluation.Application.Shared;

public sealed record ResultAsList<T>
{
    public ICollection<T>? Data { get; private set; }
    public int? CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalItems { get; private set; }

    public ResultAsList(ICollection<T>? response)
    {
        Data = response;

        if (Data is not null)
        {
            TotalItems = Data.Count;
            TotalPages = Data.Count / CurrentPage ?? 1;
        }
    }

    public ResultAsList(List<T>? response, int pageSize, int pageIndex = 0)
    {
        if (response is null)
        {
            Data = null;
            return;
        }

        Data = response;
        
        if (Data is not null)
        {
            TotalItems = response.Count;

            Data = response
                .Skip(pageSize * pageIndex)
                .Take(pageSize).ToList();

            TotalPages = Data.Count / (pageIndex == 0 ? 1 : pageIndex);
        }
    }
}

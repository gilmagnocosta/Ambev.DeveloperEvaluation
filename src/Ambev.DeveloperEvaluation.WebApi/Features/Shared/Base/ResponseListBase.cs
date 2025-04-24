namespace Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;

public class ResponseListBase
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
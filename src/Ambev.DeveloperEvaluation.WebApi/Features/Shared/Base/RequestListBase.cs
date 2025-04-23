namespace Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;

public class RequestListBase
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 100;
    public string Order { get; set; } = string.Empty;
}
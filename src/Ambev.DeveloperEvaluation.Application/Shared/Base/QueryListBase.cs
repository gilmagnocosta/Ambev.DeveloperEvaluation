namespace Ambev.DeveloperEvaluation.Application.Shared.Base;

public class QueryListBase
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 100;
    public string Order { get; set; } = string.Empty;
}
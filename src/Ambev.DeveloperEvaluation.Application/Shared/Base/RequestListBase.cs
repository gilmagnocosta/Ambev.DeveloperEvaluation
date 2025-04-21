namespace Ambev.DeveloperEvaluation.Application.Shared.Base;

public class RequestListBase
{
    public int _page { get; set; } = 0;
    public int _size { get; set; } = 100;
    public string _order { get; set; } = string.Empty;
}
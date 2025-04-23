using Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

public class ListProductsByCategoryRequest : RequestListBase
{
    public string Category { get; set; } = string.Empty;
}


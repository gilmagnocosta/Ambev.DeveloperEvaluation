using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductsByCategoryResult
{
    /// <summary>
    /// Gets or sets the total items returned
    /// </summary>
    public int TotalItems { get; set; }
    public List<GetProductResult>? Items { get; set; }
}

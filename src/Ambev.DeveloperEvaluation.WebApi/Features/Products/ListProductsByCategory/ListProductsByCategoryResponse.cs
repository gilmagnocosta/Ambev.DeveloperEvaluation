using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

/// <summary>
/// Response model for ListProductsByCategory operation
/// </summary>
public class ListProductsByCategoryResponse
{
    /// <summary>
    /// Gets or sets the total items returned
    /// </summary>
    public int TotalItems { get; set; }
    public List<GetProductResponse>? Items { get; set; }
}

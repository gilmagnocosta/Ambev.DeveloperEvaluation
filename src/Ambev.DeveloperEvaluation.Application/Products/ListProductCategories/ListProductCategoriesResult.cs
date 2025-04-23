using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategories;

/// <summary>
/// Response model for ListProductCategories operation
/// </summary>
public class ListProductCategoriesResult
{
    /// <summary>
    /// Gets or sets the list of the product categories.
    /// </summary>
    public string Category { get; set; }
}

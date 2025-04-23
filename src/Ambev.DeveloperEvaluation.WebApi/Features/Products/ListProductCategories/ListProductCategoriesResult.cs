using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Response model for ListProductCategories operation
/// </summary>
public class ListProductCategoriesResult
{
    /// <summary>
    /// Gets or sets the category list.
    /// </summary>
    public List<string>? Categories { get; set; }
}

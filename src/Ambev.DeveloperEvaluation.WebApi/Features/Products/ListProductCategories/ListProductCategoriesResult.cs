using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Response model for ListProductCategories operation
/// </summary>
public class ListProductCategoriesResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the product categories.
    /// </summary>
    /// <value>A GUID that uniquely identifies the product in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description for the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the iamge for the product.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rating of the product.
    /// </summary>
    public ProductRatingModel? Rating { get; set; }
}

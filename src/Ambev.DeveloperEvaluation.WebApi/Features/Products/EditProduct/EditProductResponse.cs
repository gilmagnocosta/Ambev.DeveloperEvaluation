using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.EditProduct;

/// <summary>
/// API response model for EditProduct operation
/// </summary>
public class EditProductResponse
{
    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product to be created.
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

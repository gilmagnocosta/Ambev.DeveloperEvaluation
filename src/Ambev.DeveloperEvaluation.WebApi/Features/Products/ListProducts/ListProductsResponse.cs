using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Response model for ListProducts operation
/// </summary>
public class ListProductsResponse : ResponseListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetProductResponse>? Data { get; set; }
}

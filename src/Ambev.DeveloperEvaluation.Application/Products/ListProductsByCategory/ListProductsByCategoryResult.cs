using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Shared.Base;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductsByCategoryResult : ResultListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetProductResult>? Data { get; set; }

    public ListProductsByCategoryResult(ICollection<GetProductResult> data, int currentPage, int pageSize, int totalItems)
    {
        Data = data;
        CurrentPage = currentPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}

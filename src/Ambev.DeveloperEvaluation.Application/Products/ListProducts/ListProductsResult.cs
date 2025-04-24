using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Shared.Base;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Response model for ListProducts operation
/// </summary>
public class ListProductsResult : ResultListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetProductResult>? Data { get; set; }

    public ListProductsResult(ICollection<GetProductResult> data, int currentPage, int pageSize, int totalItems)
    {
        Data = data;
        CurrentPage = currentPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}

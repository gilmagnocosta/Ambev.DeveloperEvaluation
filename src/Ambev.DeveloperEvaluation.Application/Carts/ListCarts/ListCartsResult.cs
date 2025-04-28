using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Shared.Base;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Response model for ListCarts operation
/// </summary>
public class ListCartsResult : ResultListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetCartResult>? Data { get; set; }

    public ListCartsResult(ICollection<GetCartResult> data, int currentPage, int pageSize, int totalItems)
    {
        Data = data;
        CurrentPage = currentPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}

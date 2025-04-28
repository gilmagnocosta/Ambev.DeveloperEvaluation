using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Response model for ListCart operation
/// </summary>
public class ListCartsResponse : ResponseListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetCartResponse>? Data { get; set; }
}

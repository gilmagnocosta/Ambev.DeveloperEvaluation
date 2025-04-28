using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the Cart.
    /// </summary>
    /// <value>A GUID that uniquely identifies the Cart in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the date of the cart
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the cart items
    /// </summary>
    public ICollection<CartItemResult>? Products { get; set; }
}

using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new Cart in the system.
/// </summary>
public class CreateCartRequest
{
    /// <summary>
    /// Gets or sets the User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the date of the cart
    /// </summary>
    public DateTime Date { get; set; }

    public ICollection<CartItemModel>? Products { get; set; }
}
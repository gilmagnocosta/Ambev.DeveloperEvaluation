using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.EditCart;

/// <summary>
/// API response model for EditCart operation
/// </summary>
public class EditCartResponse
{
    /// <summary>
    /// The unique identifier of the Cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the date of the cart
    /// </summary>
    public DateTime Date { get; set; }

    public virtual ICollection<CartItemModel>? Products { get; set; }
}

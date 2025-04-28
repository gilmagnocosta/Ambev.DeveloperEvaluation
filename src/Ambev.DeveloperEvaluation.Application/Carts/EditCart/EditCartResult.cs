using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

namespace Ambev.DeveloperEvaluation.Application.Carts.EditCart;

/// <summary>
/// Represents the response returned after successfully creating a new Cart.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly Editd user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class EditCartResult
{
    /// <summary>
    /// Gets or sets the Cart Id
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
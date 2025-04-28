using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.EditCart;

/// <summary>
/// Represents a request to update a Cart in the system.
/// </summary>
public class EditCartRequest
{
    /// <summary>
    /// Gets or sets the title of the Cart to be updated
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

    public ICollection<CartItemModel>? Products { get; set; }
}
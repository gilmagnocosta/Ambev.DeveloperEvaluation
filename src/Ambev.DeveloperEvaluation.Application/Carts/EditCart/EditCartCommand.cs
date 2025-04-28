using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.EditCart;

/// <summary>
/// Command for update a Cart
/// </summary>
/// <remarks>
/// This command is used to capture the required data for update a Cart.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="EditCartResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="EditCartCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class EditCartCommand : IRequest<EditCartResult>
{
    /// <summary>
    /// Cart Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the Cart to be Editd.
    /// </summary>

    /// <summary>
    /// Gets or sets the User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the date of the cart
    /// </summary>
    public DateTime Date { get; set; }

    public virtual ICollection<CartItemModel> Products { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new EditCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
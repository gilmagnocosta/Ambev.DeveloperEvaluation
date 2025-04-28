using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.EditCart;

/// <summary>
/// Validator for EditCartCommand that defines validation rules for Cart creation command.
/// </summary>
public class EditCartCommandValidator : AbstractValidator<EditCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the EditCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Id: Required
    /// - UserId: Required
    /// - Date: Required, must be a valid date
    /// - Products: Required, must be at least 1 item
    /// </remarks>
    public EditCartCommandValidator()
    {
        RuleFor(cart => cart.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(cart => cart.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("{PropertyName} is required.");

        RuleFor(cart => cart.Date)
            .NotEmpty()
            .GreaterThan(DateTime.MinValue)
            .WithMessage("{PropertyName} must be a valid date.");

        RuleFor(cart => cart.Products)
            .NotEmpty()
            .WithMessage("{PropertyName} must be at least 1 item.");
    }
}
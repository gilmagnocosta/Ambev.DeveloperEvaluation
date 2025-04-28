using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.EditCart;

/// <summary>
/// Validator for EditCartRequest that defines validation rules for Cart creation.
/// </summary>
public class EditCartRequestValidator : AbstractValidator<EditCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the EditCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Required
    /// - Date: Required
    /// - Products: Required
    /// </remarks>
    public EditCartRequestValidator()
    {
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
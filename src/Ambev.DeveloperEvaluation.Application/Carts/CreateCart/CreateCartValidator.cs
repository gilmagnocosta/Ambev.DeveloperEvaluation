using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for Cart creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Required
    /// - Date: Required, must be a valid date
    /// - Products: Required, must be at least 1 item
    /// </remarks>
    public CreateCartCommandValidator()
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
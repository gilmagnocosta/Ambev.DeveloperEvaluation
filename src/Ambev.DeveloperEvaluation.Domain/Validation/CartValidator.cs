using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(cart => cart.UserId).NotEqual(Guid.Empty);

        RuleFor(cart => cart.Date)
            .NotEmpty()
            .GreaterThan(DateTime.MinValue)
            .WithMessage("{PropertyName} must be a valid date.");

        RuleFor(cart => cart.Products)
            .NotEmpty()
            .WithMessage("{PropertyName} must be at least 1 item.");
    }
}

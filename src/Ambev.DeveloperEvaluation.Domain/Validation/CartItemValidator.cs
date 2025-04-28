using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        RuleFor(product => product.ProductId).NotEqual(Guid.Empty);

        RuleFor(product => product.Quantity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater then or equal to 1.");
    }
}

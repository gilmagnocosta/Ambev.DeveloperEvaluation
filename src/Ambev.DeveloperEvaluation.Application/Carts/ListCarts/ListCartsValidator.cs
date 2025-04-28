using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Validator for GetCartCommand
/// </summary>
public class ListCartsValidator : AbstractValidator<ListCartsQuery>
{
    /// <summary>
    /// Initializes validation rules for GetCartCommand
    /// </summary>
    public ListCartsValidator()
    {
        RuleFor(Cart => Cart.Page)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(Cart => Cart.Size)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(x => x.Order)
            .MinimumLength(1)
            .Must(x => x.Contains(" ")).WithMessage("Order must be a column name and the order direction (asc or desc). Ex.: title asc");
    }
}

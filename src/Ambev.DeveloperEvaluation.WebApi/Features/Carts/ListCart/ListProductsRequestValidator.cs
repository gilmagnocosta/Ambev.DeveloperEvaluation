using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Validator for ListCartsCommand
/// </summary>
public class ListCartsRequestValidator : AbstractValidator<ListCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListCartCommand
    /// </summary>
    public ListCartsRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");
        
        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("Size is required");

        RuleFor(x => x.Order)
            .MinimumLength(1)
            .Must(x => x.Contains(" ")).WithMessage("Order must be a column name and the order direction (asc or desc). Ex.: title asc");
    }
}

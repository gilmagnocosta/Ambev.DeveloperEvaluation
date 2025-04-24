using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Validator for ListProductCommand
/// </summary>
public class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductCommand
    /// </summary>
    public ListProductsRequestValidator()
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

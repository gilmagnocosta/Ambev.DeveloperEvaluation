using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class ListProductsByCategoryValidator : AbstractValidator<ListProductsByCategoryQuery>
{
    /// <summary>
    /// Initializes validation rules for ListProductByCategoryQuery
    /// </summary>
    public ListProductsByCategoryValidator()
    {
        RuleFor(x => x.Category)
           .NotEmpty()
           .MinimumLength(1)
           .MaximumLength(50)
           .WithMessage("Product category is required");

        RuleFor(product => product.Page)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(product => product.Size)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(x => x.Order)
            .MinimumLength(1)
            .Must(x => x.Contains(" ")).WithMessage("Order must be a column name and the order direction (asc or desc). Ex.: title asc");
    }
}

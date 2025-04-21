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
    }
}

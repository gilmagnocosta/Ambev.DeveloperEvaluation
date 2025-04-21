using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

/// <summary>
/// Validator for ListProductsByCategoryCommand
/// </summary>
public class ListProductsByCategoryValidator : AbstractValidator<ListProductsByCategoryQuery>
{
    /// <summary>
    /// Initializes validation rules for ListProductsByCategoryCommand
    /// </summary>
    public ListProductsByCategoryValidator()
    {
        RuleFor(product => product.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot be longer than 20 characters.");
    }
}

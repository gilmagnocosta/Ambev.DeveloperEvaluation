using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

/// <summary>
/// Validator for ListProductsByCategoryCommand
/// </summary>
public class ListProductsByCategoryRequestValidator : AbstractValidator<ListProductsByCategoryRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductsByCategoryCommand
    /// </summary>
    public ListProductsByCategoryRequestValidator()
    {
        RuleFor(product => product.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot be longer than 20 characters.");

        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("Size is required");

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage("Order is required");
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Validator for ListProductCategoriesCommand
/// </summary>
public class ListProductCategoriesValidator : AbstractValidator<ListProductCategoriesQuery>
{
    /// <summary>
    /// Initializes validation rules for ListProductCategoriesCommand
    /// </summary>
    public ListProductCategoriesValidator()
    {
        
    }
}

using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Validator for ListProductCategoriesCommand
/// </summary>
public class ListProductCategoriesRequestValidator : AbstractValidator<ListProductCategoriesRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductCategoriesCommand
    /// </summary>
    public ListProductCategoriesRequestValidator()
    {
        
    }
}

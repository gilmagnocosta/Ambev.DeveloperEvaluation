using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class ListProductsValidator : AbstractValidator<ListProductsQuery>
{
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public ListProductsValidator()
    {
        
    }
}

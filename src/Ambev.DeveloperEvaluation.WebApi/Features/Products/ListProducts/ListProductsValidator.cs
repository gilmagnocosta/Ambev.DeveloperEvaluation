using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class ListProductsValidator : AbstractValidator<ListProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public ListProductsValidator()
    {
        
    }
}

using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.EditProduct;

/// <summary>
/// Command for update a product
/// </summary>
/// <remarks>
/// This command is used to capture the required data for update a product, 
/// including title, description, category, image, rating. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="EditProductResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="EditProductCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class EditProductCommand : IRequest<EditProductResult>
{
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the title of the product to be Editd.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description for the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the iamge for the product.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rating of the product.
    /// </summary>
    public ProductRatingModel Rating { get; set; } = new ProductRatingModel();


    public ValidationResultDetail Validate()
    {
        var validator = new EditProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
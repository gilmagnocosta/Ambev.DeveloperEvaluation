using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 50 characters
    /// - Description: Required, must be between 3 and 200 characters
    /// - Category: Required, must be between 3 and 20 characters
    /// - Image: Required, must be between 3 and 100 characters
    /// </remarks>
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} cannot be longer than 50 characters.");

        RuleFor(product => product.Description)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(200).WithMessage("{PropertyName} cannot be longer than 200 characters.");

        RuleFor(product => product.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot be longer than 20 characters.");

        RuleFor(product => product.Image)
            .NotEmpty()
            .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("{PropertyName} cannot be longer than 100 characters.");
    }
}
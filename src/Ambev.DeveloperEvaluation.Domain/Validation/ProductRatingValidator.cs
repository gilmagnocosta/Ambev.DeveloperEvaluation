using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductRatingValidator : AbstractValidator<ProductRating>
{
    public ProductRatingValidator()
    {
        RuleFor(product => product.Rate)
            .GreaterThanOrEqualTo(0).WithMessage("Rate must be greater than or equal to 0.")
            .LessThanOrEqualTo(5).WithMessage("Rate must be less than or equal to 5.");

        RuleFor(product => product.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Count must be greater than or equal to 0.");
    }
}

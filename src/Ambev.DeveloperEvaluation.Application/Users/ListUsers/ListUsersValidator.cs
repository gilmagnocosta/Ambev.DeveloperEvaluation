using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Validator for ListUsersQuery
/// </summary>
public class ListUsersValidator : AbstractValidator<ListUsersQuery>
{
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public ListUsersValidator()
    {
        RuleFor(product => product.Page)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(product => product.Size)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(x => x.Order)
            .MinimumLength(1)
            .Must(x => x.Contains(" ")).WithMessage("Order must be a column name and the order direction (asc or desc). Ex.: title asc");
    }
}

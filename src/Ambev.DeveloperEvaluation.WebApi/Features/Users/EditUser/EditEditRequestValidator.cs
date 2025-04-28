using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.EditUser;

/// <summary>
/// Validator for EditUserRequest that defines validation rules for User creation.
/// </summary>
public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
{
    /// <summary>
    /// Initializes a new instance of the EditUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public EditUserRequestValidator()
    {
        RuleFor(user => user.Name.Firstname).NotEmpty()
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 50 characters.");

        RuleFor(user => user.Name.Lastname).NotEmpty().Length(2, 50)
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 50 characters.");

        RuleFor(user => user.Address.City).NotEmpty().Length(3, 50)
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 50 characters.");

        RuleFor(user => user.Address.Street).NotEmpty().Length(3, 50)
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 50 characters.");

        RuleFor(user => user.Address.Number).NotEmpty()
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 1 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 20 characters.");

        RuleFor(user => user.Address.ZipCode).NotEmpty()
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("{PropertyName} connot be longer than 20 characters.");

        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}
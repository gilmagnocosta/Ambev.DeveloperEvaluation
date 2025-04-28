using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.EditUser;

/// <summary>
/// Validator for EditUserCommand that defines validation rules for User creation command.
/// </summary>
public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    /// <summary>
    /// Initializes a new instance of the EditUserCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public EditUserCommandValidator()
    {
        RuleFor(user => user.Name).NotNull();
        RuleFor(user => user.Address).NotNull();

        When(u => u.Name != null, () =>
        {
            RuleFor(user => user.Name.Firstname).NotEmpty().Length(2, 50);
            RuleFor(user => user.Name.Lastname).NotEmpty().Length(2, 50);
        });

        When(u => u.Address != null, () =>
        {
            RuleFor(user => user.Address.City).NotEmpty().Length(3, 50);
            RuleFor(user => user.Address.Street).NotEmpty().Length(3, 50);
            RuleFor(user => user.Address.Number).NotEmpty().Length(1, 20);
            RuleFor(user => user.Address.ZipCode).NotEmpty().Length(3, 20);
            When(g => g.Address.Geolocation != null, () =>
            {
                RuleFor(user => user.Address.Geolocation.Lat).NotEmpty().Length(3, 50);
                RuleFor(user => user.Address.Geolocation.Long).NotEmpty().Length(3, 50);
            });

        });

        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}
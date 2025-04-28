using Ambev.DeveloperEvaluation.Application.Users.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.EditUser;

/// <summary>
/// Represents the response returned after successfully creating a new User.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly Editd user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class EditUserResult
{
    public Guid Id { get; set; }

    public NameModel Name { get; set; }
    public AddressModel Address { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public UserStatus Status { get; set; }
}
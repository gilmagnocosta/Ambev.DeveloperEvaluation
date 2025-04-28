using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.EditUser;

/// <summary>
/// Profile for mapping between User entity and EditUserResponse
/// </summary>
public class EditUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditUser operation
    /// </summary>
    public EditUserProfile()
    {
        CreateMap<EditUserCommand, User>();
        CreateMap<User, EditUserResult>();
    }
}

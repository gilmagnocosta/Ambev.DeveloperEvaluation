using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Profile for mapping between User entity and DeleteUserResponse
/// </summary>
public class DeleteUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteUser operation
    /// </summary>
    public DeleteUserProfile()
    {
        CreateMap<DeleteUserCommand, User>();
        CreateMap<User, DeleteUserResult>();
    }
}

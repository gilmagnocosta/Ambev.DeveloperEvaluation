using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.EditUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.EditUser;

/// <summary>
/// Profile for mapping between Application and API EditUser responses
/// </summary>
public class EditUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditUser feature
    /// </summary>
    public EditUserProfile()
    {
        CreateMap<EditUserRequest, EditUserCommand>();
        CreateMap<EditUserResult, EditUserResponse>();
    }
}

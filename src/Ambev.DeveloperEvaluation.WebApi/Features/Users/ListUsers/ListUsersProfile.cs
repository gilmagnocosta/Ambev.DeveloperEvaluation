using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.ListUsers;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Profile for mapping between User entity and ListUsersResponse
/// </summary>
public class ListUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListUsers operation
    /// </summary>
    public ListUsersProfile()
    {
        CreateMap<ListUsersRequest, ListUsersQuery>();
        CreateMap<ListUsersResult, ListUsersResponse>();
    }
}

using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class UsersSharedProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public UsersSharedProfile()
    {
        CreateMap<WebApi.Features.Users.Shared.Models.NameModel, Application.Users.Shared.Models.NameModel>().ReverseMap();
        CreateMap<WebApi.Features.Users.Shared.Models.AddressModel, Application.Users.Shared.Models.AddressModel>().ReverseMap();
        CreateMap<WebApi.Features.Users.Shared.Models.GeolocationModel, Application.Users.Shared.Models.GeolocationModel>().ReverseMap();
    }
}

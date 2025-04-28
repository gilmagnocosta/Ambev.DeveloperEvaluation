using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public class UsersSharedProfile : Profile
{
    public UsersSharedProfile()
    {
        CreateMap<Name, NameModel>().ReverseMap();
        CreateMap<Address, AddressModel>().ReverseMap();
        CreateMap<Geolocation, GeolocationModel>().ReverseMap();
    }
}

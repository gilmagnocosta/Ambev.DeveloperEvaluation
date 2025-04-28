using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Profile for mapping between product entity and ListCartResponse
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCart operation
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<ListCartsRequest, ListCartsQuery>();
        CreateMap<ListCartsResult, ListCartsResponse>();
    }
}

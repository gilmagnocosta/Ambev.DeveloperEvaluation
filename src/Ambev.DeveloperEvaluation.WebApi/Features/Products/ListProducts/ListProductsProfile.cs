using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Profile for mapping between product entity and ListProductsResponse
/// </summary>
public class ListProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProducts operation
    /// </summary>
    public ListProductsProfile()
    {
        CreateMap<Guid, Application.Products.ListProducts.ListProductsQuery>()
            .ConstructUsing(id => new Application.Products.ListProducts.ListProductsQuery());
    }
}

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProducts;

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
        CreateMap<ListProductsRequest, ListProductsQuery>();
        CreateMap<ListProductsResult, ListProductsResponse>();
    }
}

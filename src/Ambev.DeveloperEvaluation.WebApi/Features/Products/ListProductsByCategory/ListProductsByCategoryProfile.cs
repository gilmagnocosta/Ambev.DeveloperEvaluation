using Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

/// <summary>
/// Profile for mapping between product entity and ListProductsByCategoryResponse
/// </summary>
public class ListProductsByCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProductsByCategory operation
    /// </summary>
    public ListProductsByCategoryProfile()
    {
        CreateMap<ListProductsByCategoryRequest, ListProductsByCategoryQuery>();
    }
}

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Profile for mapping between product entity and ListProductCategoriesResponse
/// </summary>
public class ListProductCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProductCategories operation
    /// </summary>
    public ListProductCategoriesProfile()
    {
        CreateMap<Guid, Application.Products.ListProductCategories.ListProductCategoriesQuery>()
            .ConstructUsing(id => new Application.Products.ListProductCategories.ListProductCategoriesQuery());
    }
}

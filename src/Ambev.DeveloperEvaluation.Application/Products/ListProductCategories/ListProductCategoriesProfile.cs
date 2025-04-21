using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategories;

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
        CreateMap<List<string>, ListProductCategoriesResult>();
    }
}

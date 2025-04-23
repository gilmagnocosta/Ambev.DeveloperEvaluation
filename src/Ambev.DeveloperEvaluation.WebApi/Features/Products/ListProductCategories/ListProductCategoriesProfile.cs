using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.EditProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.EditProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProductCategories;

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
        CreateMap<ListProductCategoriesRequest, ListProductCategoriesQuery>();
    }
}

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

/// <summary>
/// Profile for mapping between product entity and ListProductsResponse
/// </summary>
public class ListProductsByCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProducts operation
    /// </summary>
    public ListProductsByCategoryProfile()
    {
        CreateMap<Product, ListProductsByCategoryResult>();
    }
}

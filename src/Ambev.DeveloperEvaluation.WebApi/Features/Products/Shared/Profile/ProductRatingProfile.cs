using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between ProductRating entity and ProductRatingModel
/// </summary>
public class ProductRatingProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public ProductRatingProfile()
    {
        CreateMap<ProductRatingModel, ProductRating>();
        CreateMap<ProductRating, ProductRatingModel>();
    }
}

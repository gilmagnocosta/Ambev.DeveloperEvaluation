using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.EditProduct;

/// <summary>
/// Profile for mapping between User entity and EditUserResponse
/// </summary>
public class EditProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditProduct operation
    /// </summary>
    public EditProductProfile()
    {
        CreateMap<EditProductCommand, Product>();
        CreateMap<Product, EditProductResult>();
    }
}

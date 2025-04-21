using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.EditProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.EditProduct;

/// <summary>
/// Profile for mapping between Application and API EditProduct responses
/// </summary>
public class EditProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditProduct feature
    /// </summary>
    public EditProductProfile()
    {
        CreateMap<EditProductRequest, EditProductCommand>();
        CreateMap<EditProductResult, EditProductResponse>();
    }
}

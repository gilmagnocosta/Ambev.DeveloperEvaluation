using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.Shared.Base;
using Ambev.DeveloperEvaluation.Application.Shared.Base;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between RequestListBase and QueryListBase
/// </summary>
public class RequestListBaseProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public RequestListBaseProfile()
    {
        CreateMap<RequestListBase, QueryListBase>();
        CreateMap<QueryListBase, RequestListBase>();
    }
}

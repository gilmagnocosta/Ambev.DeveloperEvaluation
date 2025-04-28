using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.EditCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.EditCart;

/// <summary>
/// Profile for mapping between Application and API EditCart responses
/// </summary>
public class EditCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditCart feature
    /// </summary>
    public EditCartProfile()
    {
        CreateMap<EditCartRequest, EditCartCommand>();
        CreateMap<EditCartResult, EditCartResponse>();
    }
}

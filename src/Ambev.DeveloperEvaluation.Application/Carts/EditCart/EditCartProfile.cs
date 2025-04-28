using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.EditCart;

/// <summary>
/// Profile for mapping between User entity and EditUserResponse
/// </summary>
public class EditCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for EditCart operation
    /// </summary>
    public EditCartProfile()
    {
        CreateMap<EditCartCommand, Cart>();
        CreateMap<Cart, EditCartResult>();
    }
}

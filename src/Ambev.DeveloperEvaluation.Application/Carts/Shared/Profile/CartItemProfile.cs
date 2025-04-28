using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateProduct;

/// <summary>
/// Profile for mapping between CartItem entity and CartItemModel
/// </summary>
public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<CartItemModel, CartItem>();
        CreateMap<CartItem, CartItemModel>();
    }
}
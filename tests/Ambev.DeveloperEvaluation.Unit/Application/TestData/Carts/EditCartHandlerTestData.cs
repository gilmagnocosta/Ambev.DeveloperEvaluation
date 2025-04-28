using Ambev.DeveloperEvaluation.Application.Carts.EditCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using Microsoft.CodeAnalysis;
using NSubstitute.ReceivedExtensions;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData.Carts;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class EditCartHandlerTestData
{
    /// <summary>
    /// Configures the Faker to edit valid Cart entities.
    /// The edited Carts will have valid:
    /// - Title 
    /// - Description
    /// - Category
    /// - Image
    /// </summary>
    private static readonly Faker<EditCartCommand> editCartHandlerFaker = new Faker<EditCartCommand>()
        .RuleFor(u => u.Id, f => Guid.NewGuid())
        .RuleFor(u => u.UserId, f => Guid.NewGuid())
        .RuleFor(u => u.Date, f => DateTime.Now)
        .RuleFor(u => u.Products, f => new List<CartItemModel> { new CartItemModel(Guid.NewGuid(), 1), new CartItemModel(Guid.NewGuid(), 1) });

    private static readonly Faker<Cart> cartFaker = new Faker<Cart>()
        .RuleFor(u => u.Id, f => Guid.NewGuid())
        .RuleFor(u => u.UserId, f => Guid.NewGuid())
        .RuleFor(u => u.Date, f => DateTime.Now)
        .RuleFor(u => u.Products, f => new List<CartItem> {
            new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 1
            },
            new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 1
            }
        });

    private static readonly Faker<CartItem> cartItemFaker = new Faker<CartItem>()
        .RuleFor(u => u.ProductId, f => Guid.NewGuid())
        .RuleFor(u => u.Quantity, 1);

    /// <summary>
    /// Generates a valid Cart entity with randomized data.
    /// The edited Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart entity with randomly generated data.</returns>
    public static EditCartCommand GenerateValidCommand()
    {
        return editCartHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Cart entity with randomized data.
    /// The generated Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart entity with randomly generated data.</returns>
    public static Cart GenerateValidCart()
    {
        return cartFaker.Generate();
    }

    /// <summary>
    /// Generates a valid CartItem entity with randomized data.
    /// The generated CartItem will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid CartItem entity with randomly generated data.</returns>
    public static CartItem GenerateValidCartItem()
    {
        return cartItemFaker.Generate();
    }
}

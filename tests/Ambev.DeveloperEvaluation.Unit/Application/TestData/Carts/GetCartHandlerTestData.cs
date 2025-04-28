using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;
using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData.Carts;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class GetCartHandlerTestData
{
    /// <summary>
    /// Configures the Faker to get valid Cart entities.
    /// The get Carts will have valid:
    /// - Id
    /// </summary>
    private static readonly Faker<GetCartQuery> getCartQueryHandlerFaker = new Faker<GetCartQuery>()
        .RuleFor(u => u.Id, Guid.NewGuid());

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

    private static readonly Faker<GetCartResult> getCartResultFaker = new Faker<GetCartResult>()
        .RuleFor(u => u.Id, f => Guid.NewGuid())
        .RuleFor(u => u.UserId, f => Guid.NewGuid())
        .RuleFor(u => u.Date, f => DateTime.Now)
        .RuleFor(u => u.Products, f => new List<CartItemResult> {
            new CartItemResult(Guid.NewGuid(), Guid.NewGuid(), 1),
            new CartItemResult(Guid.NewGuid(), Guid.NewGuid(), 1)
        });

    /// <summary>
    /// Generates a valid Cart query with randomized data.
    /// The retrieved Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart query with randomly generated data.</returns>
    public static GetCartQuery GenerateValidQuery()
    {
        return getCartQueryHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Cart entity with randomized data.
    /// The retrieved Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart entity with randomly generated data.</returns>
    public static Cart GenerateValidCart()
    {
        return cartFaker.Generate();
    }

    // <summary>
    /// Generates a valid CartResult with randomized data.
    /// </summary>
    /// <returns>A valid CartResult with randomly generated data.</returns>
    public static GetCartResult GenerateValidCartResult()
    {
        return getCartResultFaker.Generate();
    }
}

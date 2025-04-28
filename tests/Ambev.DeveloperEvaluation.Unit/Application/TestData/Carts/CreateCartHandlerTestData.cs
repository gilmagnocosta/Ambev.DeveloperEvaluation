using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData.Carts;
/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateCartHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Cart entities.
    /// The generated Carts will have valid
    /// </summary>
    private static readonly Faker<CreateCartCommand> createCartHandlerFaker = new Faker<CreateCartCommand>()
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

    /// <summary>
    /// Generates a valid Cart entity with randomized data.
    /// The generated Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart entity with randomly generated data.</returns>
    public static CreateCartCommand GenerateValidCommand()
    {
        return createCartHandlerFaker.Generate();
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
}

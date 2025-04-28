using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CartTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Cart entities.
    /// The generated Carts will have valid:
    /// - Title (using internet usernames)
    /// - Description (meeting complexity requirements)
    /// - Category (valid format)
    /// - Image (Brazilian format)
    /// </summary>
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
    public static Cart GenerateValidCart()
    {
        return cartFaker.Generate();
    }

    /// <summary>
    /// Generates a valid UserId that meets all requirements.
    /// </summary>
    /// <returns>A valid UserId meeting all requirements.</returns>
    public static Guid GenerateValidUserId()
    {
        return Guid.NewGuid();
    }

    /// <summary>
    /// Generates a valid Date that meets all requirements.
    /// The generated Date will have:
    /// - Valid Datetime
    /// </summary>
    /// <returns>A valid date meeting all requirements.</returns>
    public static DateTime GenerateValidDate()
    {
        return DateTime.UtcNow;
    }

    /// <summary>
    /// Generates a valid cart item that meets all requirements.
    /// </summary>
    /// <returns>A valid cart item meeting all requirements.</returns>
    public static CartItem GenerateValidCartItem()
    {
        return new CartItem
        {
            Id = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 1
        };
    }

    /// <summary>
    /// Generates a invalid Userid.
    /// This is useful for testing UserId validation error cases.
    /// </summary>
    /// <returns>A empty UserId Guid.</returns>
    public static Guid GenerateInvalidUserId()
    {
        return Guid.Empty;
    }

    /// <summary>
    /// Generates a invalid CartItem.
    /// This is useful for testing CartItem validation error cases.
    /// </summary>
    /// <returns>A empty CartItem</returns>
    public static CartItem GenerateEmptyCartItem()
    {
        return null;
    }
}

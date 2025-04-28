using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using Ambev.DeveloperEvaluation.Application.Products.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData.Carts;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ListCartsHandlerTestData
{
    /// <summary>
    /// Configures the Faker to list valid Cart entities.
    /// The list Carts will have valid:
    /// - Page
    /// - Size
    /// - Order (column and direction)
    /// </summary>
    private static readonly Faker<ListCartsQuery> listCartsHandlerFaker = new Faker<ListCartsQuery>()
        .RuleFor(u => u.Page, 1)
        .RuleFor(u => u.Size, 10)
        .RuleFor(u => u.Order, "title desc");

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
    /// Generates a valid Cart query with randomized data.
    /// The retrieved Cart will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Cart query with randomly generated data.</returns>
    public static ListCartsQuery GenerateValidQuery()
    {
        return listCartsHandlerFaker.Generate();
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

    public static List<GetCartResult> GenerateValidGetCartResultList(int length)
    {
        var faker = new Faker();

        var list = new List<GetCartResult>();

        for (int i = 0; i < length; i++)
        {
            list.Add(new GetCartResult
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Products = new List<CartItemResult> { 
                    new CartItemResult
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 1
                    },
                    new CartItemResult
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 1
                    }
                }
            });
        }

        return list;
    }

    public static List<Cart> GenerateValidCartList(int length)
    {
        var list = new List<Cart>();

        for (int i = 0; i < length; i++)
        {
            list.Add(cartFaker.Generate());
        }

        return list;
    }
}

using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ListProductsByCategoryHandlerTestData
{
    /// <summary>
    /// Configures the Faker to list valid Product entities.
    /// The list Products will have valid:
    /// - Page
    /// - Size
    /// - Order (column and direction)
    /// </summary>
    private static readonly Faker<ListProductsByCategoryQuery> listProductsByCategoryHandlerFaker = new Faker<ListProductsByCategoryQuery>()
        .RuleFor(u => u.Category, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Page, 1)
        .RuleFor(u => u.Size, 10)
        .RuleFor(u => u.Order, "title desc");

    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(u => u.Id, f => Guid.NewGuid())
        .RuleFor(u => u.Title, f => f.Name.Random.AlphaNumeric(50))
        .RuleFor(u => u.Description, f => f.Random.AlphaNumeric(200))
        .RuleFor(u => u.Category, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Image, f => f.Random.AlphaNumeric(100));

    /// <summary>
    /// Generates a valid Product query with randomized data.
    /// The retrieved Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product query with randomly generated data.</returns>
    public static ListProductsByCategoryQuery GenerateValidQuery()
    {
        return listProductsByCategoryHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The retrieved product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    public static List<GetProductResult> GenerateValidGetProductResultList(int length)
    {
        var faker = new Faker();

        var list = new List<GetProductResult>();

        for (int i = 0; i < length; i++)
        {
            list.Add(new GetProductResult
            {
                Category = faker.Random.AlphaNumeric(20),
                Description = faker.Random.AlphaNumeric(200),
                Id = Guid.NewGuid(),
                Image = faker.Random.AlphaNumeric(100),
                Rating = new DeveloperEvaluation.Application.Products.Shared.Models.ProductRatingModel
                {
                    Count = 1,
                    Rate = 1
                },
                Title = faker.Random.AlphaNumeric(50)
            });
        }

        return list;
    }

    public static List<Product> GenerateValidProductList(int length)
    {
        var list = new List<Product>();

        for (int i = 0; i < length; i++)
        {
            list.Add(ProductFaker.Generate());
        }

        return list;
    }
}

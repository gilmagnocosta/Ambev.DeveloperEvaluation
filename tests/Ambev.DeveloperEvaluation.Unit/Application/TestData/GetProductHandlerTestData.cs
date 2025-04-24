using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class GetProductHandlerTestData
{
    /// <summary>
    /// Configures the Faker to get valid Product entities.
    /// The get Products will have valid:
    /// - Id
    /// </summary>
    private static readonly Faker<GetProductQuery> getProductHandlerFaker = new Faker<GetProductQuery>()
        .RuleFor(u => u.Id, Guid.NewGuid());

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
    public static GetProductQuery GenerateValidQuery()
    {
        return getProductHandlerFaker.Generate();
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
}

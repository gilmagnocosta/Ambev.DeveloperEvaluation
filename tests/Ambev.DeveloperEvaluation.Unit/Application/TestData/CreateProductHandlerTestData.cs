using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateProductHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated Products will have valid:
    /// - Title 
    /// - Description
    /// - Category
    /// - Image
    /// </summary>
    private static readonly Faker<CreateProductCommand> createProductHandlerFaker = new Faker<CreateProductCommand>()
        .RuleFor(u => u.Title, f => f.Random.AlphaNumeric(50))
        .RuleFor(u => u.Description, f => f.Random.AlphaNumeric(200))
        .RuleFor(u => u.Category, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Image, f => f.Random.AlphaNumeric(100));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static CreateProductCommand GenerateValidCommand()
    {
        return createProductHandlerFaker.Generate();
    }
}

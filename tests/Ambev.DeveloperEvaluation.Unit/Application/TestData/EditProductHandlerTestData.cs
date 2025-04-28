using Ambev.DeveloperEvaluation.Application.Products.EditProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class EditProductHandlerTestData
{
    /// <summary>
    /// Configures the Faker to edit valid Product entities.
    /// The edited Products will have valid:
    /// - Title 
    /// - Description
    /// - Category
    /// - Image
    /// </summary>
    private static readonly Faker<EditProductCommand> editProductHandlerFaker = new Faker<EditProductCommand>()
        .RuleFor(u => u.Title, f => f.Random.AlphaNumeric(50))
        .RuleFor(u => u.Description, f => f.Random.AlphaNumeric(200))
        .RuleFor(u => u.Category, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Image, f => f.Random.AlphaNumeric(100));

    private static readonly Faker<Product> productFaker = new Faker<Product>()
        .RuleFor(u => u.Id, f => Guid.NewGuid())
        .RuleFor(u => u.Title, f => f.Name.Random.AlphaNumeric(50))
        .RuleFor(u => u.Description, f => f.Random.AlphaNumeric(200))
        .RuleFor(u => u.Category, f => f.Random.AlphaNumeric(20))
        .RuleFor(u => u.Image, f => f.Random.AlphaNumeric(100));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The edited Product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static EditProductCommand GenerateValidCommand()
    {
        return editProductHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return productFaker.Generate();
    }
}

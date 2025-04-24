using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Title (using internet usernames)
    /// - Description (meeting complexity requirements)
    /// - Category (valid format)
    /// - Image (Brazilian format)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(u => u.Title, f => f.Name.Random.AlphaNumeric(50))
        .RuleFor(u => u.Description, f => f.Random.AlphaNumeric(200))
        .RuleFor(u => u.Category, f => $"Cat-{f.Random.AlphaNumeric(16)}")
        .RuleFor(u => u.Image, f => f.Random.AlphaNumeric(100));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid title that meets all requirements.
    /// The generated title will have:
    /// - At least 3 characters
    /// - At most 50 characters
    /// </summary>
    /// <returns>A valid title meeting all requirements.</returns>
    public static string GenerateValidTitle()
    {
        return new Faker().Random.AlphaNumeric(50);
    }

    /// <summary>
    /// Generates a valid description that meets all requirements.
    /// The generated description will have:
    /// - At least 3 characters
    /// - At most 200 characters
    /// </summary>
    /// <returns>A valid description meeting all requirements.</returns>
    public static string GenerateValidDescription()
    {
        return new Faker().Random.AlphaNumeric(200);
    }

    /// <summary>
    /// Generates a valid category that meets all requirements.
    /// The generated category will have:
    /// - At least 3 characters
    /// - At most 20 characters
    /// </summary>
    /// <returns>A valid category meeting all requirements.</returns>
    public static string GenerateValidCategory()
    {
        return new Faker().Random.AlphaNumeric(20);
    }

    /// <summary>
    /// Generates a valid image that meets all requirements.
    /// The generated image will have:
    /// - At least 3 characters
    /// - At most 100 characters
    /// </summary>
    /// <returns>A valid image meeting all requirements.</returns>
    public static string GenerateValidImage()
    {
        return new Faker().Random.AlphaNumeric(100);
    }

    /// <summary>
    /// Generates a title that exceeds the maximum length limit.
    /// The generated title will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing title length validation error cases.
    /// </summary>
    /// <returns>A title that exceeds the maximum length limit.</returns>
    public static string GenerateLongTitle()
    {
        return new Faker().Random.String2(51);
    }

    /// <summary>
    /// Generates a description that exceeds the maximum length limit.
    /// The generated description will:
    /// - Be longer than 200 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing description length validation error cases.
    /// </summary>
    /// <returns>A description that exceeds the maximum length limit.</returns>
    public static string GenerateLongDescription()
    {
        return new Faker().Random.String2(251);
    }

    /// <summary>
    /// Generates a category that exceeds the maximum length limit.
    /// The generated category will:
    /// - Be longer than 20 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing category length validation error cases.
    /// </summary>
    /// <returns>A category that exceeds the maximum length limit.</returns>
    public static string GenerateLongCategory()
    {
        return new Faker().Random.String2(21);
    }

    /// <summary>
    /// Generates a image that exceeds the maximum length limit.
    /// The generated image will:
    /// - Be longer than 20 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing image length validation error cases.
    /// </summary>
    /// <returns>A image that exceeds the maximum length limit.</returns>
    public static string GenerateLongImage()
    {
        return new Faker().Random.String2(101);
    }
}

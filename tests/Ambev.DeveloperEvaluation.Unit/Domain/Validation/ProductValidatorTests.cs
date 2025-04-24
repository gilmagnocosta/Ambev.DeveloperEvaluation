using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all products properties including title, description, category, image requirements.
/// </summary>
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// This test verifies that a product with valid:
    /// - TItle (3-50 characters)
    /// - Description (3-200)
    /// - Category (3-20)
    /// - Image (3-100)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid title.
    /// This test verifies that title that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// - At most 50 characters
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 3 and 50 characters.
    /// </summary>
    /// <param name="title">The invalid title to test.</param>
    [Theory(DisplayName = "Invalid title should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidTitle_When_Validated_Then_ShouldHaveError(string title)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = title;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    /// <summary>
    /// Tests that validation fails when title exceeds maximum length.
    /// This test verifies that title longer than 50 characters fail validation.
    /// The test uses TestDataGenerator to create a title that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Title longer than maximum length should fail validation")]
    public void Given_TitleLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = ProductTestData.GenerateLongTitle();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    /// <summary>
    /// Tests that validation fails for invalid description formats.
    /// This test verifies that description that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// - At most 200 characters
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 3 and 200 characters.
    /// </summary>
    /// <param name="description">The invalid description to test.</param>
    [Theory(DisplayName = "Invalid description should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidDescription_When_Validated_Then_ShouldHaveError(string description)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = description;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    /// <summary>
    /// Tests that validation fails when description exceeds maximum length.
    /// This test verifies that description longer than 200 characters fail validation.
    /// The test uses TestDataGenerator to create a description that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Description longer than maximum length should fail validation")]
    public void Given_DescriptionLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = ProductTestData.GenerateLongDescription();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    /// <summary>
    /// Tests that validation fails for invalid description formats.
    /// This test verifies that category that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// - At most 20 characters
    /// fail validation with appropriate error messages.
    /// The category is a required field and must be between 3 and 20 characters.
    /// </summary>
    /// <param name="category">The invalid description to test.</param>
    [Theory(DisplayName = "Invalid category should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidCategory_When_Validated_Then_ShouldHaveError(string category)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Category = category;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Category);
    }

    /// <summary>
    /// Tests that validation fails when category exceeds maximum length.
    /// This test verifies that category longer than 20 characters fail validation.
    /// The test uses TestDataGenerator to create a description that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Category longer than maximum length should fail validation")]
    public void Given_CategoryLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Category = ProductTestData.GenerateLongCategory();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Category);
    }

    /// <summary>
    /// Tests that validation fails for invalid image formats.
    /// This test verifies that image that are:
    /// - Empty strings
    /// - Less than 3 characters
    /// - At most 200 characters
    /// fail validation with appropriate error messages.
    /// The title is a required field and must be between 3 and 200 characters.
    /// </summary>
    /// <param name="image">The invalid description to test.</param>
    [Theory(DisplayName = "Invalid image should fail validation")]
    [InlineData("")] // Empty
    [InlineData("ab")] // Less than 3 characters
    public void Given_InvalidImage_When_Validated_Then_ShouldHaveError(string image)
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Image = image;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image);
    }

    /// <summary>
    /// Tests that validation fails when image exceeds maximum length.
    /// This test verifies that image longer than 100 characters fail validation.
    /// The test uses TestDataGenerator to create a image that exceeds the maximum
    /// length limit, ensuring the validation rule is properly enforced.
    /// </summary>
    [Fact(DisplayName = "Image longer than maximum length should fail validation")]
    public void Given_ImageLongerThanMaximum_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Image = ProductTestData.GenerateLongImage();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image);
    }
}

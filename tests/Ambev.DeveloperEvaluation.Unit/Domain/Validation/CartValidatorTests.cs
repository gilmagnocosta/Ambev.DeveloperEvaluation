using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the CartValidator class.
/// </summary>
public class CartValidatorTests
{
    private readonly CartValidator _validator;

    public CartValidatorTests()
    {
        _validator = new CartValidator();
    }

    /// <summary>
    /// Tests that validation passes when all Cart properties are valid.
    /// This test verifies that a Cart with valid:
    /// - TItle (3-50 characters)
    /// - Description (3-200)
    /// - Category (3-20)
    /// - Image (3-100)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid Cart should pass all validation rules")]
    public void Given_ValidCart_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var Cart = CartTestData.GenerateValidCart();

        // Act
        var result = _validator.TestValidate(Cart);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid UserId.
    /// This test verifies that UserId that are:
    /// - Empty Guid
    /// fail validation with appropriate error messages.
    /// The UserId is a required field and must be a valid Guid.
    /// </summary>
    /// <param name="userId">The invalid UserId to test.</param>
    [Theory(DisplayName = "Invalid UserId should fail validation")]
    [InlineData(null)]
    public void Given_InvalidUserId_When_Validated_Then_ShouldHaveError(Guid userId)
    {
        // Arrange
        var cart = CartTestData.GenerateValidCart();
        cart.UserId = userId;

        // Act
        var result = _validator.TestValidate(cart);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserId);
    }

    /// <summary>
    /// Tests that validation fails for invalid CartiItem.
    /// This test verifies that CartItem that are:
    /// - Empty Items
    /// fail validation with appropriate error messages.
    /// The CartItem is a required field and must be at least 1 item.
    /// </summary>
    /// <param name="cartItem">The invalid description to test.</param>
    [Theory(DisplayName = "Invalid CartiItem should fail validation")]
    [InlineData(null)]
    public void Given_InvalidCartItem_When_Validated_Then_ShouldHaveError(List<CartItem> cartItem)
    {
        // Arrange
        var cart = CartTestData.GenerateValidCart();
        cart.Products = cartItem;

        // Act
        var result = _validator.TestValidate(cart);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Products);
    }
}

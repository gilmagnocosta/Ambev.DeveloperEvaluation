using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Cart entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class CartTests
{
    /// <summary>
    /// Tests that validation passes when all Cart properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid Cart data")]
    public void Given_ValidCartData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var cart = CartTestData.GenerateValidCart();

        // Act
        var result = cart.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when user properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid cart data")]
    public void Given_InvalidCartData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var Cart = new Cart
        {
            Id = Guid.Empty,
            Products = null,
            UserId = Guid.Empty
        };

        // Act
        var result = Cart.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}

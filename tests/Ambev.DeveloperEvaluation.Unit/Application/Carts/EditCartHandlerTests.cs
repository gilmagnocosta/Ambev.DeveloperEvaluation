using Ambev.DeveloperEvaluation.Application.Carts.EditCart;
using Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData.Carts;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="EditCartHandler"/> class.
/// </summary>
public class EditCartHandlerTests
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly EditCartHandler _handler;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="EditCartHandlerTests"/> class.
    /// Sets up the test dependencies and Edits fake data generators.
    /// </summary>
    public EditCartHandlerTests()
    {
        _cartRepository = Substitute.For<ICartRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new EditCartHandler(_cartRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Cart update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Cart data When update Cart Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = EditCartHandlerTestData.GenerateValidCommand();
        var cart = EditCartHandlerTestData.GenerateValidCart();
        command.Id = cart.Id;

        var result = new EditCartResult
        {
            Id = cart.Id,
        };

        _mapper.Map<Cart>(command).Returns(cart);
        _mapper.Map<EditCartResult>(cart).Returns(result);

        _cartRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(cart);

        // When
        var editCartResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        editCartResult.Should().NotBeNull();
        editCartResult.Id.Should().Be(cart.Id);
        await _cartRepository.Received(1).UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Cart update request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Cart data When creating Cart Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new EditCartCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to Cart entity")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        // Given
        var command = EditCartHandlerTestData.GenerateValidCommand();
        var cart = EditCartHandlerTestData.GenerateValidCart();
        var cartItem = EditCartHandlerTestData.GenerateValidCartItem();

        command.Id = cart.Id;

        var result = new EditCartResult
        {
            Id = command.Id,
            UserId = command.UserId,
            Date = command.Date,
            Products = new List<CartItemModel>
            {
                new CartItemModel(cart.Products.ToArray()[0].Id, cart.Products.ToArray()[0].ProductId.Value, 1),
                new CartItemModel (cart.Products.ToArray()[1].Id, cart.Products.ToArray()[1].ProductId.Value, 1),
            }
        };

        _mapper.Map<CartItem>(Arg.Any<CartItemModel>()).Returns(cartItem);
        _mapper.Map<EditCartResult>(cart).Returns(result);

        _cartRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(cart);

        _cartRepository.UpdateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
            .Returns(cart);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<EditCartResult>(Arg.Is<Cart>(c =>
            c.Id == cart.Id &&
            c.UserId == cart.UserId));
    }
}

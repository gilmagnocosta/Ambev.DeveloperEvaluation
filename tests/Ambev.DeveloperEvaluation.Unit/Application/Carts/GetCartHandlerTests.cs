using Ambev.DeveloperEvaluation.Application.Carts.EditCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
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
/// Contains unit tests for the <see cref="GetCartHandler"/> class.
/// </summary>
public class GetCartHandlerTests
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly GetCartHandler _handler;
    private readonly List<Cart> _carts = new List<Cart>
    {
        GetCartHandlerTestData.GenerateValidCart(),
        GetCartHandlerTestData.GenerateValidCart(),
        GetCartHandlerTestData.GenerateValidCart(),
        GetCartHandlerTestData.GenerateValidCart(),
        GetCartHandlerTestData.GenerateValidCart()
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="EditCartHandlerTests"/> class.
    /// Sets up the test dependencies and Edits fake data generators.
    /// </summary>
    public GetCartHandlerTests()
    {
        _cartRepository = Substitute.For<ICartRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new GetCartHandler(_cartRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Cart update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Cart data When query Cart By Id Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var query = GetCartHandlerTestData.GenerateValidQuery();
        var cart = GetCartHandlerTestData.GenerateValidCart();

        var result = GetCartHandlerTestData.GenerateValidCartResult();
        result.Id = cart.Id;

        _mapper.Map<Cart>(query).Returns(cart);
        _mapper.Map<GetCartResult>(cart).Returns(result);

        _cartRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(cart);

        // When
        var getCartResult = await _handler.Handle(query, CancellationToken.None);

        // Then
        getCartResult.Should().NotBeNull();
        getCartResult.Id.Should().Be(cart.Id);
        await _cartRepository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Cart Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Cart Id When get Cart By Id Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new GetCartQuery(Guid.Empty); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid query When handling Then maps query to Cart entity")]
    public async Task Handle_ValidRequest_MapsCommandToCart()
    {
        // Given
        var query = GetCartHandlerTestData.GenerateValidQuery();
        var cart = _carts.First();

        var result = GetCartHandlerTestData.GenerateValidCartResult();

        _mapper.Map<Cart>(query).Returns(cart);
        _mapper.Map<GetCartResult>(cart).Returns(result);

        _cartRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(cart);

        // When
        await _handler.Handle(query, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<GetCartResult>(Arg.Is<Cart>(c =>
            c.Id == cart.Id &&
            c.UserId == cart.UserId &&
            c.Products.Any()));
    }
}

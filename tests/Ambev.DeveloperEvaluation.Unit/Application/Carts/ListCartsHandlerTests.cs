using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
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
/// Contains unit tests for the <see cref="ListCartsHandlerTests"/> class.
/// </summary>
public class ListCartsHandlerTests
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly ListCartsHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListCartsHandlerTests"/> class.
    /// Sets up the test dependencies and Edits fake data generators.
    /// </summary>
    public ListCartsHandlerTests()
    {
        _cartRepository = Substitute.For<ICartRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new ListCartsHandler(_cartRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Cart update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid parameters When query Cart list Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var query = ListCartsHandlerTestData.GenerateValidQuery();
        var Carts = ListCartsHandlerTestData.GenerateValidCartList(20);
        var result = ListCartsHandlerTestData.GenerateValidGetCartResultList(20);

        //_mapper.Map<Cart>(query).Returns(Cart);
        _mapper.Map<List<GetCartResult>>(Carts).Returns(result);

        _cartRepository.GetAllAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>())
            .Returns((Carts, Carts.Count()));

        // When
        var listCartResult = await _handler.Handle(query, CancellationToken.None);

        // Then
        listCartResult.Should().NotBeNull();
        listCartResult.Data.Should().NotBeEmpty();
        await _cartRepository.Received(1).GetAllAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Cart Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid query parameters When list all Carts Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var query = new ListCartsQuery(); // Empty query will fail validation

        // When
        var act = () => _handler.Handle(query, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid query When handling Then maps query to Cart list result")]
    public async Task Handle_ValidRequest_MapsCommandToCart()
    {
        // Given
        var query = ListCartsHandlerTestData.GenerateValidQuery();
        var carts = ListCartsHandlerTestData.GenerateValidCartList(20);
        var result = ListCartsHandlerTestData.GenerateValidGetCartResultList(20);

        _mapper.Map<List<GetCartResult>>(carts).Returns(result);


        _cartRepository.GetAllAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>())
             .Returns((carts, carts.Count()));

        // When
        await _handler.Handle(query, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<List<GetCartResult>>(Arg.Is<List<Cart>>(c =>
            c.Any() &&
            c.Count == carts.Count()));
    }
}

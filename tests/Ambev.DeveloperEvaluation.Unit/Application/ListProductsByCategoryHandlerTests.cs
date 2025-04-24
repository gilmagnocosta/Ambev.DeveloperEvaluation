using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="ListProductsByCategoryHandlerTests"/> class.
/// </summary>
public class ListProductsByCategoryHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ListProductsByCategoryHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListProductsHandlerTests"/> class.
    /// Sets up the test dependencies and Edits fake data generators.
    /// </summary>
    public ListProductsByCategoryHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new ListProductsByCategoryHandler(_productRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Product update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid parameters When query product list by category Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var query = ListProductsByCategoryHandlerTestData.GenerateValidQuery();
        var products = ListProductsByCategoryHandlerTestData.GenerateValidProductList(20);
        var result = ListProductsByCategoryHandlerTestData.GenerateValidGetProductResultList(20);

        _mapper.Map<List<GetProductResult>>(products).Returns(result);

        _productRepository.GetAllByCategoryAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>())
            .Returns((products, products.Count()));

        // When
        var listProductByCategoryResult = await _handler.Handle(query, CancellationToken.None);

        // Then
        listProductByCategoryResult.Should().NotBeNull();
        listProductByCategoryResult.Data.Should().NotBeEmpty();
        await _productRepository.Received(1).GetAllByCategoryAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Product parameters request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid query parameters When list all products by category Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var query = new ListProductsByCategoryQuery(); // Empty query will fail validation

        // When
        var act = () => _handler.Handle(query, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid query When handling Then maps query to Product list result")]
    public async Task Handle_ValidRequest_MapsCommandToProduct()
    {
        // Given
        var query = ListProductsByCategoryHandlerTestData.GenerateValidQuery();
        var products = ListProductsByCategoryHandlerTestData.GenerateValidProductList(20);
        var result = ListProductsByCategoryHandlerTestData.GenerateValidGetProductResultList(20);

        _mapper.Map<List<GetProductResult>>(products).Returns(result);


        _productRepository.GetAllByCategoryAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>(), Arg.Any<bool>(), Arg.Any<CancellationToken>())
             .Returns((products, products.Count()));

        // When
        await _handler.Handle(query, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<List<GetProductResult>>(Arg.Is<List<Product>>(c =>
            c.Any() &&
            c.Count == products.Count()));
    }
}

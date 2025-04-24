using Ambev.DeveloperEvaluation.Application.Products.EditProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="GetProductHandler"/> class.
/// </summary>
public class GetProductHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly GetProductHandler _handler;
    private readonly List<Product> _products = new List<Product>
    {
        EditProductHandlerTestData.GenerateValidProduct(),
        EditProductHandlerTestData.GenerateValidProduct(),
        EditProductHandlerTestData.GenerateValidProduct(),
        EditProductHandlerTestData.GenerateValidProduct(),
        EditProductHandlerTestData.GenerateValidProduct()
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="EditProductHandlerTests"/> class.
    /// Sets up the test dependencies and Edits fake data generators.
    /// </summary>
    public GetProductHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new GetProductHandler(_productRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Product update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Product data When query Product By Id Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = GetProductHandlerTestData.GenerateValidQuery();
        var product = _products.First();

        var result = new GetProductResult
        {
            Id = product.Id,
            Category = product.Category,
            Description = product.Description,
            Image = product.Image,
            Title = product.Title
        };

        _mapper.Map<Product>(command).Returns(product);
        _mapper.Map<GetProductResult>(product).Returns(result);

        _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(product);

        // When
        var getProductResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        getProductResult.Should().NotBeNull();
        getProductResult.Id.Should().Be(product.Id);
        await _productRepository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Product Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Product Id When get Product By Id Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new GetProductQuery(Guid.Empty); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid query When handling Then maps query to Product entity")]
    public async Task Handle_ValidRequest_MapsCommandToProduct()
    {
        // Given
        var query = GetProductHandlerTestData.GenerateValidQuery();
        var product = _products.First();

        var result = new GetProductResult
        {
            Id = query.Id,
            Category = product.Category,
            Description = product.Description,
            Image = product.Image,
            Title = product.Title
        };

        _mapper.Map<Product>(query).Returns(product);
        _mapper.Map<GetProductResult>(product).Returns(result);

        _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(product);

        // When
        await _handler.Handle(query, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<GetProductResult>(Arg.Is<Product>(c =>
            c.Title == product.Title &&
            c.Description == product.Description &&
            c.Category == product.Category &&
            c.Image == product.Image));
    }
}

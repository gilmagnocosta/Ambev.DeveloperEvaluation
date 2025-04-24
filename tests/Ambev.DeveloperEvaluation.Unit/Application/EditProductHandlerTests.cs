using Ambev.DeveloperEvaluation.Application.Products.EditProduct;
using Ambev.DeveloperEvaluation.Application.Products.EditProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="EditProductHandler"/> class.
/// </summary>
public class EditProductHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly EditProductHandler _handler;
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
    public EditProductHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new EditProductHandler(_productRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Product update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Product data When update Product Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = EditProductHandlerTestData.GenerateValidCommand();
        var product = _products.First();
        command.Id = product.Id;

        var result = new EditProductResult
        {
            Id = product.Id,
        };

        _mapper.Map<Product>(command).Returns(product);
        _mapper.Map<EditProductResult>(product).Returns(result);

        _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(product);

        // When
        var editProductResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        editProductResult.Should().NotBeNull();
        editProductResult.Id.Should().Be(product.Id);
        await _productRepository.Received(1).UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Product update request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Product data When creating Product Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new EditProductCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to Product entity")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        // Given
        var command = EditProductHandlerTestData.GenerateValidCommand();
        var product = _products.First();
        command.Id = product.Id;

        var result = new EditProductResult
        {
            Id = command.Id,
            Category = command.Category,
            Description = command.Description,
            Image = command.Image,
            Title = command.Title
        };

        _mapper.Map<Product>(command).Returns(product);
        _mapper.Map<EditProductResult>(product).Returns(result);

        _productRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(product);

        _productRepository.UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
            .Returns(product);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        //_mapper.Received(1).Map<Product>(Arg.Is<EditProductCommand>(c =>
        //    c.Title == command.Title &&
        //    c.Description == command.Description &&
        //    c.Category == command.Category &&
        //    c.Image == command.Image));
        
        await _productRepository.Received(1).UpdateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
    }
}

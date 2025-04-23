using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.EditProduct;

/// <summary>
/// Handler for processing EditProductCommand requests
/// </summary>
public class EditProductHandler : IRequestHandler<EditProductCommand, EditProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of EditProductHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for EditProductCommand</param>
    public EditProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the EditProductCommand request
    /// </summary>
    /// <param name="command">The EditProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Editd product details</returns>
    public async Task<EditProductResult> Handle(EditProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new EditProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        // Verify if it is already exists with the same title
        var existingProduct = await _productRepository.GetByTitleAsync(command.Title, cancellationToken);
        if (existingProduct != null)
            throw new InvalidOperationException($"Product with title {command.Title} already exists");

        // Get Current
        var entity = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (entity == null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
            {
                ErrorMessage = $"Product not found"
            });

            throw new ValidationException(validationResult.Errors);
        }

        await _productRepository.UpdateAsync(entity, cancellationToken);
        var result = _mapper.Map<EditProductResult>(entity);
        
        return result;
    }
}

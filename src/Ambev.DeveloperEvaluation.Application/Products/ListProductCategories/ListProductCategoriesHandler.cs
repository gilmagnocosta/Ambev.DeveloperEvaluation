using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Shared;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategories;

/// <summary>
/// Handler for processing ListProductCategoriesCommand requests
/// </summary>
public class ListProductCategoriesHandler : IRequestHandler<ListProductCategoriesQuery, List<string>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProductCategoriesHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListProductCategoriesCommand</param>
    public ListProductCategoriesHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductCategoriesCommand request
    /// </summary>
    /// <param name="request">The ListProductCategories command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product categories list if found</returns>
    public async Task<List<string>> Handle(ListProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var validator = new ListProductCategoriesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        List<string> items = await _productRepository.GetAllProductCategoriesAsync(cancellationToken);

        return items;
    }
}

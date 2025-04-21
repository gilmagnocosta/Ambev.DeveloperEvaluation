using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Shared;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

/// <summary>
/// Handler for processing ListProductsCommand requests
/// </summary>
public class ListProductsByCategoryHandler : IRequestHandler<ListProductsByCategoryQuery, ResultAsList<ListProductsByCategoryResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private const string STANDARD_COLUMN_ORDER = "title";
    private const string STANDARD_DIRECTION_ORDER = "asc";

    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="productRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListProductsByCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductsCommand request
    /// </summary>
    /// <param name="request">The ListProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product list if found</returns>
    public async Task<ResultAsList<ListProductsByCategoryResult>> Handle(ListProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var validator = new ListProductsByCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderParams = !string.IsNullOrEmpty(request._order) ? request._order.Split(' ') : [STANDARD_COLUMN_ORDER, STANDARD_DIRECTION_ORDER];

        var (items, count) = await _productRepository.GetAllByCategoryAsync(request.Category, request._page, request._size, orderParams[0], orderParams[1] == "asc" ? true : false, cancellationToken);
        
        return _mapper.Map<ResultAsList<ListProductsByCategoryResult>>(
            new ResultAsList<Product>(items, request._size, request._page));
    }
}

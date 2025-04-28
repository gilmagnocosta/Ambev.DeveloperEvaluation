using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Handler for processing ListCartsCommand requests
/// </summary>
public class ListCartsHandler : IRequestHandler<ListCartsQuery, ListCartsResult>
{
    private readonly ICartRepository _CartRepository;
    private readonly IMapper _mapper;
    private const string STANDARD_COLUMN_ORDER = "date";
    private const string STANDARD_DIRECTION_ORDER = "asc";

    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="CartRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListCartsHandler(
        ICartRepository CartRepository,
        IMapper mapper)
    {
        _CartRepository = CartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListCartsCommand request
    /// </summary>
    /// <param name="request">The ListCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart list if found</returns>
    public async Task<ListCartsResult> Handle(ListCartsQuery request, CancellationToken cancellationToken)
    {
        var validator = new ListCartsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderParams = !string.IsNullOrEmpty(request.Order) ? request.Order.Split(' ') : [STANDARD_COLUMN_ORDER, STANDARD_DIRECTION_ORDER];

        var (items, count) = await _CartRepository.GetAllAsync(
            request.Page, 
            request.Size, 
            orderParams[0], 
            orderParams[1] == "asc" ? true : false, 
            cancellationToken);

        var resultItems = _mapper.Map<List<GetCartResult>>(items);

        return new ListCartsResult(resultItems, request.Page, request.Size, count);
    }
}

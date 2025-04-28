using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.EditCart;

/// <summary>
/// Handler for processing EditCartCommand requests
/// </summary>
public class EditCartHandler : IRequestHandler<EditCartCommand, EditCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of EditCartHandler
    /// </summary>
    /// <param name="cartRepository">The Cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for EditCartCommand</param>
    public EditCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the EditCartCommand request
    /// </summary>
    /// <param name="command">The EditCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Editd Cart details</returns>
    public async Task<EditCartResult> Handle(EditCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new EditCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        // Get Current
        var entity = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (entity == null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
            {
                ErrorMessage = $"Cart not found"
            });

            throw new ValidationException(validationResult.Errors);
        }

        // Verify if it is already exists with the same user
        var existingCart = await _cartRepository.GetByUserAsync(command.UserId, cancellationToken);
        if (existingCart != null && existingCart.Id != entity.Id)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
            {
                ErrorMessage = $"Already exists another cart for this user"
            });

            throw new ValidationException(validationResult.Errors);
        }

        entity.Date = command.Date;
        entity.UpdatedAt = DateTime.UtcNow;
        entity?.Products?.ForEach(x => x.Id = Guid.Empty);

        //for (var i = 0; i < entity?.Products?.Count; i++)
        //{
        //    entity?.Products?.ForEach(x => x.Id = Guid.Empty);
        //}

        if (entity?.Products == null) entity.Products = new List<CartItem>();
        foreach (var item in command.Products)
        {
            entity.Products.Add(_mapper.Map<CartItem>(item));
        }

        await _cartRepository.UpdateAsync(entity, cancellationToken);
        var result = _mapper.Map<EditCartResult>(entity);
        
        return result;
    }
}

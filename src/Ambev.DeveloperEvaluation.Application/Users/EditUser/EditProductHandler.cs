using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.EditUser;

/// <summary>
/// Handler for processing EditUserCommand requests
/// </summary>
public class EditUserHandler : IRequestHandler<EditUserCommand, EditUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of EditUserHandler
    /// </summary>
    /// <param name="UserRepository">The User repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for EditUserCommand</param>
    public EditUserHandler(IUserRepository UserRepository, IMapper mapper)
    {
        _userRepository = UserRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the EditUserCommand request
    /// </summary>
    /// <param name="command">The EditUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Editd User details</returns>
    public async Task<EditUserResult> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new EditUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        // Get Current
        var entity = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
        if (entity == null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
            {
                ErrorMessage = $"User not found"
            });

            throw new ValidationException(validationResult.Errors);
        }

        // Verify if it is already exists with the same email
        var existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null && existingUser.Id != entity.Id)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
            {
                ErrorMessage = $"User with email '{command.Email}' already exists"
            });

            throw new ValidationException(validationResult.Errors);
        }

        entity.Address = new Domain.ValueObjects.Address
        {
            City = command.Address.City,
            Number = command.Address.Number,
            Street = command.Address.Street,
            ZipCode = command.Address.ZipCode,
        };
        entity.Address.Geolocation = new Domain.ValueObjects.Geolocation();
        entity.Address.Geolocation.SetLocation(command.Address.Geolocation.Lat, command.Address.Geolocation.Long);
        entity.Email = command.Email;
        entity.Role = command.Role;
        entity.Password = command.Password;
        entity.Phone = command.Phone;
        entity.Username = command.Username;
        entity.Name.SetName(command.Name.Firstname, command.Name.Lastname);

        entity.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(entity, cancellationToken);
        var result = _mapper.Map<EditUserResult>(entity);
        
        return result;
    }
}

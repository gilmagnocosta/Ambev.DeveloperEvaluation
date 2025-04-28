using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for cart entity operations
/// </summary>
public interface ICartRepository
{
    /// <summary>
    /// Creates a new Cart in the repository
    /// </summary>
    /// <param name="Cart">The Cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Cart</returns>
    Task<Cart> CreateAsync(Cart Cart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a Cart in the repository
    /// </summary>
    /// <param name="Cart">The Cart to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated Cart</returns>
    Task<Cart> UpdateAsync(Cart Cart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Cart by User Id
    /// </summary>
    /// <param name="userId">The unique identifier of the User</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    Task<Cart?> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Cart from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Cart was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all Carts from the repository
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="orderColumn"></param>
    /// <param name="ascending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The Cart list if found and the count of items returned</returns>
    Task<(List<Cart>?, int)> GetAllAsync(int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default);
}
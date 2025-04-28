using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;
    
    /// <summary>
    /// Initializes a new instance of CartRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Cart in the database
    /// </summary>
    /// <param name="cart">The Cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Cart</returns>
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Update a Cart in the database
    /// </summary>
    /// <param name="cart">The Cart to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated Cart</returns>
    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Retrieves a Cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a Cart by User
    /// </summary>
    /// <param name="userId">The unique identifier of the User</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    public async Task<Cart?> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Carts.FirstOrDefaultAsync(o => o.UserId == userId, cancellationToken);
    }

    /// <summary>
    /// Retrieves all Carts
    /// </summary>
    /// <param name="page">Page</param>
    /// <param name="size">Page size</param>
    /// <param name="orderColumn">Order column</param>
    /// <param name="ascending">Order direction</param>
    /// <param name="cancellationToken">Calcellation token</param>
    /// <returns>List of all Carts</returns>
    public async Task<(List<Cart>?, int)> GetAllAsync(int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default)
    {
        var items = await _context.Carts
            .Skip(size * (page - 1))
            .Take(size)
            .ToListAsync(cancellationToken);

        items = items.OrderBy(orderColumn, ascending)?.ToList();

        var itemsCount = await _context.Carts.CountAsync(cancellationToken);

        return (items, itemsCount);
    }

    /// <summary>
    /// Deletes a Cart from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Cart was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

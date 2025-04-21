using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    
    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Update a product in the database
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated product</returns>
    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by their title
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(u => u.Title == title, cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by their category
    /// </summary>
    /// <param name="category">The category to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(u => u.Category == category, cancellationToken);
    }

    /// <summary>
    /// Retrieves all products
    /// </summary>
    /// <param name="page">Page</param>
    /// <param name="size">Page size</param>
    /// <param name="orderColumn">Order column</param>
    /// <param name="ascending">Order direction</param>
    /// <param name="cancellationToken">Calcellation token</param>
    /// <returns></returns>
    public async Task<(List<Product>?, int)> GetAllAsync(int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default)
    {
        var items = await _context.Products
            .Skip(size * page)
            .Take(size)
            .ToListAsync(cancellationToken);

        items = items.OrderBy(orderColumn, ascending)?.ToList();

        var itemsCount = await _context.Products.CountAsync(cancellationToken);

        return (items, itemsCount);
    }

    /// <summary>
    /// Retrieves a list of all products by category
    /// </summary>
    /// <param name="category">Product category</param>
    /// <param name="page">Page</param>
    /// <param name="size">Size of page</param>
    /// <param name="orderColumn">Order column</param>
    /// <param name="ascending">Order direction</param>
    /// <param name="cancellationToken">Calcellation token</param>
    /// <returns></returns>
    public async Task<(List<Product>?, int)> GetAllByCategoryAsync(string category, int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default)
    {
        var items = await _context.Products
            .Where(x => x.Category == category)
            .Skip(size * page)
            .Take(size)
            .ToListAsync(cancellationToken);

        items = items.OrderBy(orderColumn, ascending)?.ToList();

        var itemsCount = await _context.Products.CountAsync(cancellationToken);

        return (items, itemsCount);
    }

    /// <summary>
    /// Retrieves a list of all product categories
    /// </summary>
    /// <param name="cancellationToken">Calcellation token</param>
    /// <returns>Array of all product categories</returns>
    public async Task<List<string>>? GetAllProductCategoriesAsync(CancellationToken cancellationToken = default)
    {
        List<string> items = await _context.Products.Select(x => x.Category).Distinct().ToListAsync();

        return items;
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a product in the repository
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated product</returns>
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by their title
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);


    /// <summary>
    /// Deletes a product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all products from the repository
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="orderColumn"></param>
    /// <param name="ascending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The product list if found and the count of items returned</returns>
    Task<(List<Product>?, int)> GetAllAsync(int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all products from the repository by category
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns>The product list if found and the count of items returned</returns>
    Task<(List<Product>?, int)> GetAllByCategoryAsync(string category, int page, int size, string orderColumn, bool ascending, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all product categories from the repository
    /// </summary>
    /// <returns>The product categories list if found and the count of items returned</returns>
    Task<List<string>>? GetAllProductCategoriesAsync(CancellationToken cancellationToken = default);
}
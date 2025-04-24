using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public virtual ProductRating Rating { get; set; } = new ProductRating();
    
    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the entity's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the entity using the ProductValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Title length</list>
    /// <list type="bullet">Description length</list>
    /// <list type="bullet">Category length</list>
    /// <list type="bullet">Image length</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

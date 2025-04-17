using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ProductRating : BaseEntity
{
    public decimal Rate { get; set; }
    public int Count { get; set; }
}

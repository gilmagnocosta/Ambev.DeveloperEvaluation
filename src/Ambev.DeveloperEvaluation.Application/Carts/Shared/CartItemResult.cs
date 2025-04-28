namespace Ambev.DeveloperEvaluation.Application.Products.Shared.Models;

public class CartItemResult
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public CartItemResult()
    {
        
    }

    public CartItemResult(Guid id, Guid productId, int quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }
}

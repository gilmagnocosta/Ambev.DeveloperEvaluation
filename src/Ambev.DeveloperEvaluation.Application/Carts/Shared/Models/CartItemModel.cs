namespace Ambev.DeveloperEvaluation.Application.Carts.Shared.Models;

public class CartItemModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public CartItemModel()
    {
        
    }

    public CartItemModel(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public CartItemModel(Guid id, Guid productId, int quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }
}

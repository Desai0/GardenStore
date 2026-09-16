namespace GardenStore.Web.Models;

public sealed record CartLine(Product Product, int Quantity)
{
    public decimal LineTotal => Product.Price * Quantity;
}

public sealed class CartViewModel
{
    public IReadOnlyList<CartLine> Items { get; init; } = [];
    public int ItemCount => Items.Sum(item => item.Quantity);
    public decimal TotalAmount => Items.Sum(item => item.LineTotal);
}

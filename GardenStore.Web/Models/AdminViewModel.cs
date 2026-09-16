namespace GardenStore.Web.Models;

public sealed class AdminViewModel
{
    public IReadOnlyList<Product> Products { get; init; } = [];
    public int TotalCount => Products.Count;
    public int InStockCount => Products.Count(product => product.Stock > 0);
    public int LowStockCount => Products.Count(product => product.Stock is > 0 and < 5);
}

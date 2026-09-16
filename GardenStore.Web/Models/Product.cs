namespace GardenStore.Web.Models;

public sealed class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string ImageUrl { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal? OldPrice { get; init; }
    public int Stock { get; init; }
    public bool IsHit { get; init; }

    public bool HasDiscount => OldPrice is > 0 && OldPrice > Price;

    public int DiscountPercent => HasDiscount
        ? (int)Math.Round((1 - Price / OldPrice!.Value) * 100)
        : 0;
}

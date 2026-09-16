namespace GardenStore.Web.Models;

public sealed class CatalogViewModel
{
    public IReadOnlyList<Product> Products { get; init; } = [];
    public IReadOnlyList<string> Categories { get; init; } = [];
    public string? SelectedCategory { get; init; }
    public int TotalProductCount { get; init; }
    public int AvailableProductCount { get; init; }
}

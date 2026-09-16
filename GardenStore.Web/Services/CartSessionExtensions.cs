using System.Text.Json;

namespace GardenStore.Web.Services;

public static class CartSessionExtensions
{
    private const string CartKey = "Cart";

    public static IReadOnlyList<int> GetCartProductIds(this ISession session)
    {
        var value = session.GetString(CartKey);
        return string.IsNullOrWhiteSpace(value)
            ? []
            : JsonSerializer.Deserialize<List<int>>(value) ?? [];
    }

    public static void AddProductToCart(this ISession session, int productId)
    {
        var ids = session.GetCartProductIds().ToList();
        ids.Add(productId);
        session.SetString(CartKey, JsonSerializer.Serialize(ids));
    }

    public static void RemoveProductFromCart(this ISession session, int productId)
    {
        var ids = session.GetCartProductIds().Where(id => id != productId).ToList();
        session.SetString(CartKey, JsonSerializer.Serialize(ids));
    }

    public static void ClearCart(this ISession session) => session.Remove(CartKey);
}

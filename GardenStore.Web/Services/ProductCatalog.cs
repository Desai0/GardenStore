using GardenStore.Web.Models;

namespace GardenStore.Web.Services;

public static class ProductCatalog
{
    public static IReadOnlyList<Product> All { get; } =
    [
        new() { Id = 1, Name = "Керамический горшок", Description = "Матовый горшок с поддоном для комнатных растений.", Category = "Для растений", ImageUrl = "/img/anime-1.jpg", Price = 1290, OldPrice = 1690, Stock = 8, IsHit = true },
        new() { Id = 2, Name = "Лейка 5 литров", Description = "Лёгкая лейка с длинным носиком для точного полива.", Category = "Для растений", ImageUrl = "/img/anime-2.jpg", Price = 790, Stock = 12 },
        new() { Id = 3, Name = "Садовый секатор", Description = "Стальные лезвия и нескользящие ручки для аккуратной обрезки.", Category = "Инструменты", ImageUrl = "/img/anime-3.jpg", Price = 1190, OldPrice = 1990, Stock = 5 },
        new() { Id = 4, Name = "Перчатки для сада", Description = "Плотные перчатки с дышащей тыльной стороной.", Category = "Инструменты", ImageUrl = "/img/anime-4.jpg", Price = 490, Stock = 0 },
        new() { Id = 5, Name = "Уличный фонарь", Description = "Компактный фонарь на солнечной батарее для дорожек.", Category = "Декор", ImageUrl = "/img/anime-5.jpg", Price = 1490, Stock = 7, IsHit = true },
        new() { Id = 6, Name = "Кружка садовода", Description = "Матовая керамическая кружка с пробковым основанием.", Category = "Для дома", ImageUrl = "/img/anime-6.jpg", Price = 1390, OldPrice = 1790, Stock = 4 }
    ];

    public static Product? Find(int id) => All.FirstOrDefault(product => product.Id == id);
}

using GardenStore.Web.Models;
using GardenStore.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GardenStore.Web.Controllers;

public sealed class CatalogController : Controller
{
    [HttpGet]
    public IActionResult Index(string? category)
    {
        var selectedCategory = string.IsNullOrWhiteSpace(category) ? null : category;
        var products = selectedCategory is null
            ? ProductCatalog.All
            : ProductCatalog.All.Where(product => product.Category == selectedCategory).ToList();

        return View(new CatalogViewModel
        {
            Products = products,
            Categories = ProductCatalog.All.Select(product => product.Category).Distinct().Order().ToList(),
            SelectedCategory = selectedCategory,
            TotalProductCount = ProductCatalog.All.Count,
            AvailableProductCount = ProductCatalog.All.Count(product => product.Stock > 0)
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToCart(int id)
    {
        var product = ProductCatalog.Find(id);
        if (product is null)
        {
            TempData["AlertType"] = "danger";
            TempData["AlertMessage"] = "Товар не найден. Вернитесь в каталог и выберите другой.";
        }
        else if (product.Stock == 0)
        {
            TempData["AlertType"] = "warning";
            TempData["AlertMessage"] = $"«{product.Name}» сейчас нет в наличии.";
        }
        else
        {
            HttpContext.Session.AddProductToCart(product.Id);
            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Товар «{product.Name}» добавлен в корзину.";
        }

        return RedirectToAction("Index", "Cart");
    }
}

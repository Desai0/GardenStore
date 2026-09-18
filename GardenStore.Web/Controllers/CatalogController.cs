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

    // Задание 1.1 — AJAX: поиск, возвращает partial _ProductList
    [HttpGet]
    public IActionResult Search(string query)
    {
        var products = ProductCatalog.All.AsEnumerable();
        if (!string.IsNullOrEmpty(query))
        {
            query = query.ToLower();
            products = products.Where(p =>
                p.Name.ToLower().Contains(query) ||
                p.Description.ToLower().Contains(query));
        }
        return PartialView("_ProductList", products);
    }

    // Задание 1.2 — AJAX: добавление в корзину, возвращает JSON
    [HttpPost]
    public IActionResult AddToCartAjax(int id)
    {
        var product = ProductCatalog.Find(id);
        if (product == null)
            return Json(new { success = false, message = "Товар не найден" });

        HttpContext.Session.AddProductToCart(id);
        var count = HttpContext.Session.GetCartProductIds().Count;

        return Json(new
        {
            success = true,
            cartCount = count,
            productName = product.Name
        });
    }

    // Задание 1.3 — AJAX: текущее количество товаров в корзине
    [HttpGet]
    public IActionResult GetCartCount()
    {
        var count = HttpContext.Session.GetCartProductIds().Count;
        return Json(new { count = count });
    }
}

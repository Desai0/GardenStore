using GardenStore.Web.Models;
using GardenStore.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GardenStore.Web.Controllers;

public sealed class CartController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var items = HttpContext.Session.GetCartProductIds()
            .GroupBy(id => id)
            .Select(group => new { Product = ProductCatalog.Find(group.Key), Quantity = group.Count() })
            .Where(item => item.Product is not null)
            .Select(item => new CartLine(item.Product!, item.Quantity))
            .ToList();

        return View(new CartViewModel { Items = items });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        HttpContext.Session.RemoveProductFromCart(id);
        TempData["AlertType"] = "secondary";
        TempData["AlertMessage"] = "Товар удалён из корзины.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmOrder()
    {
        if (HttpContext.Session.GetCartProductIds().Count == 0)
        {
            TempData["AlertType"] = "warning";
            TempData["AlertMessage"] = "Корзина пуста. Добавьте товар перед оформлением.";
        }
        else
        {
            HttpContext.Session.ClearCart();
            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = "Заказ подтверждён. Это учебный проект, поэтому оплата не выполняется.";
        }

        return RedirectToAction(nameof(Index));
    }
}

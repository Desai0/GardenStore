using GardenStore.Web.Models;
using GardenStore.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GardenStore.Web.Controllers;

public sealed class AdminController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new AdminViewModel { Products = ProductCatalog.All });
}

using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class AdminCategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
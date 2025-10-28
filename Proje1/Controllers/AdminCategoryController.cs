using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize]
public class AdminCategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
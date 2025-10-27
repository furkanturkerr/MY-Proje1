using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
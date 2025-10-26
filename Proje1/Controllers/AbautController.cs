using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class AbautController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
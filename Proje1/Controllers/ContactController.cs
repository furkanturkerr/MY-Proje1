using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
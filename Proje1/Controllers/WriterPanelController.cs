using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class WriterPanelController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize]
public class WriterPanelController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
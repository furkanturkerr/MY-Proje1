using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class ContentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public ActionResult ContentByHeading()
    {
        
        return View();
    }
}
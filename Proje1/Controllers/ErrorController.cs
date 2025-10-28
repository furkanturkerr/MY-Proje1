using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class ErrorController : Controller
{
    [Route("Error/Error404")]
    public IActionResult Error404()
    {
        Response.StatusCode = 404;
        return View();
    }

    [Route("Error/Error500")]
    public IActionResult Error500()
    {
        Response.StatusCode = 500;
        return View();
    }
}
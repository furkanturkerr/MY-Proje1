using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("ErrorPage/{code}")]
        public IActionResult Index(int code)
        {
            Response.StatusCode = code;
            return View();
        }
    }
}
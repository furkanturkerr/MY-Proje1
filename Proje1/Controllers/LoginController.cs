using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class LoginController : Controller
{
    private readonly IAdminService _adminService;
    public LoginController(IAdminService adminService) => _adminService = adminService;

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Index(Admin p)
    {
        var admin = _adminService.Login(p.AdminName, p.AdminPasword);

        if (admin != null)
        {
            HttpContext.Session.SetString("AdminName", admin.AdminName);
            HttpContext.Session.SetString("AdminRole", admin.AdminRole ?? "");
            return RedirectToAction("Index", "AdminCategory");
        }

        ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
        return View();
    }
}
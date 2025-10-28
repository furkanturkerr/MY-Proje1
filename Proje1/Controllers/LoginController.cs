using System.Security.Claims;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly IAdminService _adminService;

    public LoginController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(Admin model)
    {
        if (string.IsNullOrWhiteSpace(model.AdminName) || string.IsNullOrWhiteSpace(model.AdminPasword))
        {
            ViewBag.Error = "Kullanıcı adı ve şifre boş olamaz.";
            return View();
        }

        var admin = _adminService.Login(model.AdminName, model.AdminPasword);
        if (admin == null)
        {
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        await SignInAsync(admin);
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(Admin model)
    {
        if (string.IsNullOrWhiteSpace(model.AdminName) ||
            string.IsNullOrWhiteSpace(model.AdminPasword) ||
            string.IsNullOrWhiteSpace(model.AdminRole))
        {
            ViewBag.Error = "Lütfen tüm alanları doldurun.";
            return View();
        }

        var createdAdmin = _adminService.Register(model.AdminName, model.AdminPasword, model.AdminRole);

        if (createdAdmin == null)
        {
            ViewBag.Error = "Bu kullanıcı adı zaten mevcut.";
            return View();
        }

        await SignInAsync(createdAdmin);

        ViewBag.Success = "Kayıt başarılı! Oturum açılıyor...";
        return RedirectToAction("Index", "Category");
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Login");
    }

    public IActionResult Denied()
    {
        return View();
    }

    private async Task SignInAsync(Admin admin)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString()),
            new Claim(ClaimTypes.Name, admin.AdminName),
            new Claim(ClaimTypes.Role, admin.AdminRole)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}

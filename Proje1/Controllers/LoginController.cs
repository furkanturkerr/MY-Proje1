using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class LoginController : Controller
{
    private readonly IAdminService _adminService;
    public LoginController(IAdminService adminService) => _adminService = adminService;

    [HttpGet, AllowAnonymous]
    public IActionResult Index(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Index(Admin p, string? returnUrl = null)
    {
        var admin = _adminService.Login(p.AdminName, p.AdminPasword);
        if (admin == null)
        {
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        // Claims + Cookie oluştur
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.AdminName),
        };
        var identity  = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        // (İstersen) Session devam etsin
        HttpContext.Session.SetString("AdminName", admin.AdminName);

        // Güvenli geri dönüş
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);

        return RedirectToAction("Index", "Category"); // varsayılan yönlendirme
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}

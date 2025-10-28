using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize]
public class AbautController : Controller
{
    private readonly IAbautService _abautService;
    public AbautController(IAbautService abautService)
    {
        _abautService = abautService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _abautService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddAbaut()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddAbaut(Abaut abaut)
    {
        _abautService.Insert(abaut);
        return RedirectToAction("Index");
    }

    public PartialViewResult _AbautPartial()
    {
        return PartialView();
    }
}
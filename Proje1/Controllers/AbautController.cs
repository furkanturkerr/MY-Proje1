using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
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
        AbautValidator abautValidator = new();
        ValidationResult validationResult = abautValidator.Validate(abaut);
        if (validationResult.IsValid)
        {
            _abautService.Insert(abaut);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors )
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }

    public PartialViewResult _AbautPartial()
    {
        return PartialView();
    }
}
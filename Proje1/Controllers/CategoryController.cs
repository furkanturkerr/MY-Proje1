using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public IActionResult Index()
    {
        var values = _categoryService.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        CategoryValidatior categoryValidatior = new();
        ValidationResult validationResult = categoryValidatior.Validate(category);
        if (validationResult.IsValid)
        {
            _categoryService.Add(category);
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
}
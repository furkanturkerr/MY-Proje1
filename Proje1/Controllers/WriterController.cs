using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Controllers;
[Authorize]
public class WriterController:Controller
{
    private readonly IWriterService _writerService;
    private readonly ICategoryService _categoryService;
    private readonly IHeadinService _headinService;
    WriterValidator writerValidator = new WriterValidator();
    
    public WriterController(IWriterService writerService, ICategoryService categoryService , IHeadinService headinService)
    {
        _headinService = headinService;
        _categoryService = categoryService;
        _writerService = writerService;
    }
    
    public IActionResult Index()
    {
        var values = _writerService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddWriter()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddWriter(Writer writer)
    {
        ValidationResult validationResult = writerValidator.Validate(writer);
        if (validationResult.IsValid)
        {
            _writerService.Insert(writer);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }

    [HttpGet]
    public IActionResult EditWriter(int id)
    {
        var valurs = _writerService.GetById(id);
        return View(valurs);
    }
    
    [HttpPost]
    public IActionResult EditWriter(Writer writer)
    {
        ValidationResult validationResult = writerValidator.Validate(writer);
        if (validationResult.IsValid)
        {
            _writerService.Update(writer);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }

    [HttpGet]
    public IActionResult NewHeading()
    {
        List<SelectListItem> valueCategory = (from x in _categoryService.GetAll()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.vlc = valueCategory;
        return View();
    }
    
    [HttpPost]
    public IActionResult NewHeading(Heading heading)
    {
        heading.HeadingDate = DateTime.Now;
        heading.WriterId = 3;
        heading.HeadingStatus = true;
        _headinService.Insert(heading);
        return RedirectToAction("Index");
    }
}
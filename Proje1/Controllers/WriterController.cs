using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class WriterController:Controller
{
    private readonly IWriterService _writerService;
    WriterValidator writerValidator = new WriterValidator();
    
    public WriterController(IWriterService writerService)
    {
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
}
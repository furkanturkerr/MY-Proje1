using System.Net.Mime;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Controllers;

public class HeadingController : Controller
{
    private readonly IHeadinService _headinService;
    private readonly ICategoryService _categoryService;
    private readonly IWriterService _writerService;
    public HeadingController(IHeadinService headinService, ICategoryService categoryService, IWriterService writerService)
    {
        _writerService = writerService;
        _categoryService = categoryService;
        _headinService = headinService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _headinService.GetAllWithCategory();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddHeading()
    {
        List<SelectListItem> valueCategory = (from x in _categoryService.GetAll()
                select new SelectListItem
        {
            Text = x.CategoryName,
            Value = x.CategoryId.ToString()
        }).ToList();
        ViewBag.vlc = valueCategory;
        
        List<SelectListItem> valueWriter = (from x in _writerService.GetAll()
        select new SelectListItem
        {
            Text = x.WriterName + " " + x.WriterSurname,
            Value = x.WriterId.ToString()
        }).ToList();
        ViewBag.vlw = valueWriter;
        return View();
    }

    [HttpPost]
    public IActionResult AddHeading(Heading heading)
    {
        heading.HeadingDate = DateTime.Now;
        _headinService.Insert(heading);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult UpdateHeading(int id)
    {
        List<SelectListItem> valueCategory = (from x in _categoryService.GetAll()
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
        ViewBag.vlc = valueCategory;
        var valurs = _headinService.GetById(id);
        return View(valurs);
    }

    [HttpPost]
    public IActionResult UpdateHeading(Heading heading)
    {
        _headinService.Update(heading);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteHeading(int id)
    {
        var value = _headinService.GetById(id);
        value.HeadingStatus = value.HeadingStatus == true ? false : true;
        _headinService.Delete(value);
        return RedirectToAction("Index");
    }
}
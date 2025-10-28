using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class GaleryController : Controller
{
    private readonly IImageService _imageService;
    public GaleryController(IImageService imageService, ICategoryService categoryService)
    {
        _imageService = imageService;
    }
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        var values = _imageService.GetAll();
        return View(values);
    }
}
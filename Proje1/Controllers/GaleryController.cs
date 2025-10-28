using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize(Roles = "Admin")]
public class GaleryController : Controller
{
    private readonly IImageService _imageService;
    public GaleryController(IImageService imageService, ICategoryService categoryService)
    {
        _imageService = imageService;
    }
    public IActionResult Index()
    {
        var values = _imageService.GetAll();
        return View(values);
    }
}
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize]
public class ContentController : Controller
{
    private readonly IContentService _contentService;
    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public ActionResult ContentByHeading(int id)
    {
        var values = _contentService.GetAllByIdHeading(id);   
        return View(values);
    }
}
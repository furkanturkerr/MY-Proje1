using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;
[Authorize]
public class ContactController : Controller
{
    private readonly IContactService _contactService;
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _contactService.GetAll();
        return View(values);
    }
    
    public IActionResult ContactDetails(int id)
    {
        var values = _contactService.GetById(id);
        return View(values);
    }
}
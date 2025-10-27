using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

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
        return View();
    }
}
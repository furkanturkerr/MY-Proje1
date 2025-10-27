using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    // GET
    public IActionResult Inbox()
    {
        var values = _messageService.GetAll();
        return View(values);
    }
}
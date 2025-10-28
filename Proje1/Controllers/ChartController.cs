using System.Text.Json.Serialization;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class ChartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CategoryChart()
    {
        return Json(BlogList());
    }
    
    public List<CategoryClass> BlogList()
    {
        List<CategoryClass>  ct = new List<CategoryClass>();
        ct.Add(new CategoryClass()
        {
            CategoryName = "Blog",
            CategoryCaunt = 5
        });
        ct.Add(new CategoryClass()
        {
            CategoryName = "Teknoloji",
            CategoryCaunt = 4
        });
        ct.Add(new CategoryClass()
        {
            CategoryName = "Spor",
            CategoryCaunt = 1
        });
        ct.Add(new CategoryClass()
        {
            CategoryName = "Film",
            CategoryCaunt = 7
        });
        return ct;
    }
}
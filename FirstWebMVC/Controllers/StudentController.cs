using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Controllers;

public class StudentController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Student std)
    {
        string StrOutput = "Xin Chào " + std.name + " đến từ " + std.address;
        ViewBag.Message = StrOutput;
        return View();
    }

}

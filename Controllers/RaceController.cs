using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class RaceController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
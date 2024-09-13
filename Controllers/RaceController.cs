using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class RaceController : Controller
{
    private readonly ApplicationDbContext _context;

    public RaceController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Race> races = _context.Races.ToList();
        return View(races);
    }
}
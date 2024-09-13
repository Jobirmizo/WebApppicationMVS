using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ClubController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public ClubController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Club> clubs = _context.Clubs.ToList();
        return View(clubs);
    }
    
    public IActionResult Detail(int id)
    {
        Club club = _context.Clubs.FirstOrDefault(c => c.Id == id);
        return View(club);
    }
}
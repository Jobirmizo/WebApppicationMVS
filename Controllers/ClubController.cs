using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ClubController : Controller
{
    private readonly IClubService _clubService;
    
    public ClubController(IClubService clubService)
    {
        _clubService = clubService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Club> clubs = await _clubService.GetAll();
        return View(clubs);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Club club = await _clubService.GetByIdAsync(id);    
        return View(club);
    }
}
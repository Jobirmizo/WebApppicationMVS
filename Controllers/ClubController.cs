using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers;

public class ClubController : Controller
{
    private readonly IClubService _clubService;
    private readonly IPhotoService _photoService;
    public ClubController(IClubService clubService, IPhotoService photoService)
    {
        _photoService = photoService;
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClubViewModel clubVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(clubVM.Image);
            var club = new Club
            {
                Title = clubVM.Title,
                Description = clubVM.Description,
                Image = result.Url.ToString(),
                Address = new Address
                {
                    Street = clubVM.Address.Street,
                    City = clubVM.Address.City,
                    State = clubVM.Address.State
                }
            };
            _clubService.Add(club);
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", "Photo upload failed!");
        }


        return View(clubVM);
    }
    
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Data.Enums;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers;

public class RaceController : Controller
{
    private readonly IRaceService _raceService;
    private readonly IPhotoService _photoService;
    public RaceController(IRaceService raceService, IPhotoService photoService)
    {
        _photoService = photoService;
        _raceService = raceService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Race> races = await _raceService.GetAll();
        return View(races);
    }
    public async Task<IActionResult> Detail(int id)
    {
        Race race = await _raceService.GetByIdAsync(id);
        return View(race);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(Race race)
    {
        if (!ModelState.IsValid)
        {
            return View(race);
        }
        
        _raceService.Add(race);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var race = await _raceService.GetByIdAsync(id);
        if (race == null) return View();

        var raceVM = new EditRaceViewModel
        {
            Title = race.Title,
            Description = race.Description,
            Address = race.Address,
            AddressId = race.AddressId,
            URL = race.Image,
            RaceCategory = race.RaceCategory
        };
        return View(raceVM);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("","Model is not Valid");
            return View("Edit", raceVM);
        }

        var userRace = await _raceService.GetByIdAsync(id);

        if (userRace != null)
        {
            try
            {
                await _photoService.DeletePhotosAsync(userRace.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Could not delete photo");
                return View(raceVM);
            }

            var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);
            var race = new Race
            {
                Id = id,
                Title = raceVM.Title,
                Description = raceVM.Description,
                Image = photoResult.Url.ToString(),
                Address = raceVM.Address,
                AddressId = raceVM.AddressId
            };

            _raceService.Update(race);

            return RedirectToAction("Index");
        }
        else
        {
            return View(raceVM);
        }
    }
    
}
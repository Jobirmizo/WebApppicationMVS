﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class RaceController : Controller
{
    private readonly IRaceService _raceService;
    public RaceController(IRaceService raceService)
    {
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
    
}
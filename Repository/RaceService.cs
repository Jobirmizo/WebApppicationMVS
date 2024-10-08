﻿using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class RaceService : IRaceService
{
    private readonly ApplicationDbContext _context;
    public RaceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Race>> GetAll()
    {
        return await _context.Races.ToListAsync();
    }

    public async Task<Race> GetByIdAsync(int id)
    {
        return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
    }
    public async Task<Race> GetByIdAsyncNoTracking(int id)
    {
        return await _context.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
    {
        return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
    }

    public bool Add(Race race)
    {
        _context.Add(race);
        return Save();
    }

    public bool Update(Race race)
    {
        _context.Update(race);
        return Save();
    }

    public bool Delete(Race race)
    {
        _context.Remove(race);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;  
    }
}
﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class ClubService : IClubService
{
    private readonly ApplicationDbContext _context;
    public ClubService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Club>> GetAll()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetByIdAsync(int id)
    {
        return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
    }
    public async Task<Club> GetByIdAsyncNoTracking(int id)
    {
        return await _context.Clubs.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Club>> GetClubByCity(string city)
    {
        return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
    }

    public bool Add(Club club)
    {
        _context.Add(club);
        return Save();
    }

    public bool Update(Club club)
    {
        _context.Update(club);
        return Save();
    }

    public bool Delete(Club club)
    {
        _context.Remove(club);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;    
    }
}
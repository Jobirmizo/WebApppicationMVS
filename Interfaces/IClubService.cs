﻿using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface IClubService
{
    Task<IEnumerable<Club>> GetAll();
    Task<Club> GetByIdAsync(int id);
    Task<IEnumerable<Club>> GetClubByCity(string city);
    bool Add(Club club);
    bool Update(Club club);
    bool Delete(Club club);
    bool Save();
}
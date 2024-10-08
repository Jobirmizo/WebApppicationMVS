﻿using WebApplication1.Data.Enums;
using WebApplication1.Models;

namespace WebApplication1.ViewModel;

public class EditRaceViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Address Address { get; set; }
    public int AddressId { get; set; }
    public IFormFile Image { get; set; }
    public string URL { get; set; }
    public RaceCategory RaceCategory { get; set; }
    
}
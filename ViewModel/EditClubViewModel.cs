﻿using WebApplication1.Controllers;
using WebApplication1.Data.Enums;
using WebApplication1.Models;

namespace WebApplication1.ViewModel;

public class EditClubViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? AddressId { get; set; }
    public Address Address { get; set; }
    public string? URL { get; set; }
    public IFormFile Image { get; set; }
    public ClubCategory ClubCategory { get; set; }
}
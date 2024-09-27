using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.ViewModel;


namespace WebApplication1.Controllers;

public class DashboardController : Controller
{
    
    private readonly IDashboardService _dashboardService;
    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;  
    }
    public async Task<IActionResult> Index()
    {
        var userRaces = await _dashboardService.GetAllUserRaces();
        var userClubs = await _dashboardService.GetAllUserClubs();
        var dashboardViewModel = new DashboardViewModel()
        {
            Races = userRaces,
            Clubs = userClubs
        };
        return View(dashboardViewModel);
    }
}
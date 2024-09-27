using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public DashboardService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }
    public async Task<List<Club>> GetAllUserClubs()
    {
        var currentUser = _httpContextAccessor.HttpContext?.User;
        var userClubs = _context.Clubs.Where(r => r.AppUser.Id == currentUser.ToString());
        return userClubs.ToList();
    }
    public async Task<List<Race>> GetAllUserRaces()
    {
        var currentUser = _httpContextAccessor.HttpContext?.User;
        var userRaces = _context.Races.Where(r => r.AppUser.Id == currentUser.ToString());
        return userRaces.ToList();
    }
}
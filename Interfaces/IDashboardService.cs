using WebApplication1.Models;


namespace WebApplication1.Interfaces;

public interface IDashboardService
{
    Task<List<Race>> GetAllUserRaces();
    Task<List<Club>> GetAllUserClubs();

}
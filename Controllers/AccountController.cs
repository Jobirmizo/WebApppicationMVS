using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ApplicationDbContext _context;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult login()
    {
        var response = new LoginViewModel();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            return View(loginViewModel);
        }

        var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);
        if (user != null)
        {
            var checkPassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (checkPassword)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Race");
                }    
            }
            TempData["Error"] = "Wrong cretians try again";
        }
        TempData["Error"] = "Wrong cretians try again";
        return View(loginViewModel);
    }
    
}
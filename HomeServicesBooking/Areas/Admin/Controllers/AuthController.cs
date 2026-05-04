using System.Security.Claims;
using HomeServicesBooking.Data;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeServicesBooking.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AuthController> _logger;
    private readonly PasswordHasher<AdminUser> _passwordHasher = new();

    public AuthController(ApplicationDbContext context, ILogger<AuthController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var admin = await _context.AdminUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == model.Email);

        if (admin is null || !IsPasswordValid(admin, model.Password))
        {
            _logger.LogWarning("Failed login attempt for email: {Email}", model.Email);
            ModelState.AddModelError(string.Empty, "بيانات غير صحيحة");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, admin.Id.ToString()),
            new(ClaimTypes.Name, admin.Email),
            new(ClaimTypes.Email, admin.Email),
            new(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        try
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SignInAsync failed for email: {Email}", model.Email);
            ModelState.AddModelError(string.Empty, "حدث خطأ أثناء تسجيل الدخول");
            return View(model);
        }

        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SignOutAsync failed");
        }

        return RedirectToAction("Login", "Auth", new { area = "Admin" });
    }

    private bool IsPasswordValid(AdminUser admin, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(admin, admin.PasswordHash, password);
        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
}

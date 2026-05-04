using System.Diagnostics;
using HomeServicesBooking.Data;
using Microsoft.AspNetCore.Mvc;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var services = await _context.Services
            .AsNoTracking()
            .Where(service => service.IsActive)
            .OrderBy(service => service.Name)
            .Select(service => new ServiceCardViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description
            })
            .ToListAsync();

        return View(new HomeIndexViewModel
        {
            Services = services
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

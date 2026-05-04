using HomeServicesBooking.Data;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Controllers;

public class ServicesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServicesController(ApplicationDbContext context)
    {
        _context = context;
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

        return View(services);
    }

    public async Task<IActionResult> Details(int id)
    {
        var service = await _context.Services
            .AsNoTracking()
            .Where(service => service.Id == id && service.IsActive)
            .Select(service => new ServiceDetailsViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description
            })
            .FirstOrDefaultAsync();

        if (service is null)
        {
            return NotFound();
        }

        return View(service);
    }
}

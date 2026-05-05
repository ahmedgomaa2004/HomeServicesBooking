using HomeServicesBooking.Data;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class ServicesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ServicesController> _logger;

    public ServicesController(ApplicationDbContext context, ILogger<ServicesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var services = await _context.Services
            .AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .Select(s => new ServiceListItemViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                IsActive = s.IsActive,
                IsActiveDisplay = s.IsActive ? "نشط" : "معطل",
                IsActiveBadgeClass = s.IsActive ? "bg-success" : "bg-secondary",
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            })
            .ToListAsync();

        return View(services);
    }

    public IActionResult Create()
    {
        return View(new ServiceFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var service = new Service
            {
                Name = model.Name.Trim(),
                Description = model.Description.Trim(),
                IsActive = true
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تمت إضافة الخدمة بنجاح";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create service");
            TempData["ErrorMessage"] = "حدث خطأ أثناء إضافة الخدمة";
            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        var service = await _context.Services
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new ServiceFormViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            })
            .FirstOrDefaultAsync();

        if (service is null)
        {
            return NotFound();
        }

        return View(service);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServiceFormViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var service = await _context.Services.FindAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        try
        {
            service.Name = model.Name.Trim();
            service.Description = model.Description.Trim();
            service.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم تعديل الخدمة بنجاح";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update service {ServiceId}", id);
            TempData["ErrorMessage"] = "حدث خطأ أثناء تعديل الخدمة";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Deactivate(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        if (!service.IsActive)
        {
            TempData["ErrorMessage"] = "الخدمة معطلة بالفعل";
            return RedirectToAction(nameof(Index));
        }

        try
        {
            service.IsActive = false;
            service.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم تعطيل الخدمة بنجاح";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to deactivate service {ServiceId}", id);
            TempData["ErrorMessage"] = "حدث خطأ أثناء تعطيل الخدمة";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Activate(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        if (service.IsActive)
        {
            TempData["ErrorMessage"] = "الخدمة مفعّلة بالفعل";
            return RedirectToAction(nameof(Index));
        }

        try
        {
            service.IsActive = true;
            service.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم تفعيل الخدمة بنجاح";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to activate service {ServiceId}", id);
            TempData["ErrorMessage"] = "حدث خطأ أثناء تفعيل الخدمة";
            return RedirectToAction(nameof(Index));
        }
    }
}

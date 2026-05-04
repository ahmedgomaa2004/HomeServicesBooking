using HomeServicesBooking.Data;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Controllers;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ApplicationDbContext context, ILogger<OrdersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Create(int? serviceId)
    {
        var model = new OrderFormViewModel
        {
            ServiceId = serviceId,
            OrderDate = DateTime.Today
        };

        await PopulateServicesAsync(model);

        if (serviceId.HasValue)
        {
            model.ServiceName = model.Services
                .FirstOrDefault(service => service.Value == serviceId.Value.ToString())
                ?.Text;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderFormViewModel model)
    {
        var selectedService = model.ServiceId.HasValue
            ? await _context.Services.FirstOrDefaultAsync(service =>
                service.Id == model.ServiceId.Value && service.IsActive)
            : null;

        if (selectedService is null)
        {
            ModelState.AddModelError(nameof(model.ServiceId), "نوع الخدمة مطلوب");
        }

        if (!ModelState.IsValid)
        {
            await PopulateServicesAsync(model);
            model.ServiceName = selectedService?.Name;
            return View(model);
        }

        try
        {
            var order = new Order
            {
                CustomerName = model.CustomerName.Trim(),
                Phone = model.Phone.Trim(),
                Address = model.Address.Trim(),
                ServiceId = selectedService!.Id,
                ServiceName = selectedService.Name,
                OrderDate = model.OrderDate!.Value.Date,
                Status = OrderStatus.Pending
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم إرسال طلبك بنجاح";
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Order save failed");
            ModelState.AddModelError(string.Empty, "حدث خطأ أثناء حفظ الطلب، يرجى المحاولة مرة أخرى");

            await PopulateServicesAsync(model);
            model.ServiceName = selectedService?.Name;
            return View(model);
        }
    }

    private async Task PopulateServicesAsync(OrderFormViewModel model)
    {
        model.Services = await _context.Services
            .AsNoTracking()
            .Where(service => service.IsActive)
            .OrderBy(service => service.Name)
            .Select(service => new SelectListItem
            {
                Value = service.Id.ToString(),
                Text = service.Name,
                Selected = model.ServiceId.HasValue && service.Id == model.ServiceId.Value
            })
            .ToListAsync();
    }
}

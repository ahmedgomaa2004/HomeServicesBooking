using HomeServicesBooking.Data;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ApplicationDbContext context, ILogger<OrdersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index(string? search, string? status, int? page)
    {
        var ordersQuery = _context.Orders.AsNoTracking();

        // Apply status filter — safe parsing
        if (!string.IsNullOrWhiteSpace(status) && status != "All")
        {
            if (Enum.TryParse<OrderStatus>(status, out var parsedStatus))
            {
                ordersQuery = ordersQuery.Where(o => o.Status == parsedStatus);
            }
            // If invalid status value, ignore filter (treat as All)
        }

        // Apply search — trim and ignore if empty after trim
        search = search?.Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            ordersQuery = ordersQuery.Where(o =>
                o.CustomerName.Contains(search) ||
                o.Phone.Contains(search));
        }

        var totalCount = await ordersQuery.CountAsync();
        var totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / 10.0));
        var currentPage = Math.Max(1, page ?? 1);
        if (currentPage > totalPages)
        {
            currentPage = totalPages;
        }

        var orders = await ordersQuery
            .OrderByDescending(o => o.CreatedAt)
            .Skip((currentPage - 1) * 10)
            .Take(10)
            .Select(o => new OrderListItemViewModel
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                Phone = o.Phone,
                ServiceName = o.ServiceName,
                OrderDate = o.OrderDate,
                Status = o.Status == OrderStatus.InProgress
                    ? "In Progress"
                    : o.Status.ToString(),
                StatusBadgeClass = o.Status == OrderStatus.Pending
                    ? "bg-warning text-dark"
                    : o.Status == OrderStatus.InProgress
                        ? "bg-info text-dark"
                        : "bg-success"
            })
            .ToListAsync();

        var viewModel = new OrdersListViewModel
        {
            Orders = orders,
            SearchTerm = search,
            StatusFilter = status,
            CurrentPage = currentPage,
            TotalPages = totalPages,
            TotalCount = totalCount
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .Where(o => o.Id == id)
            .Select(o => new OrderDetailsViewModel
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                Phone = o.Phone,
                Address = o.Address,
                ServiceName = o.ServiceName,
                OrderDate = o.OrderDate,
                Status = o.Status == OrderStatus.InProgress
                    ? "In Progress"
                    : o.Status.ToString(),
                StatusBadgeClass = o.Status == OrderStatus.Pending
                    ? "bg-warning text-dark"
                    : o.Status == OrderStatus.InProgress
                        ? "bg-info text-dark"
                        : "bg-success",
                CurrentStatusCode = o.Status.ToString(),
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            })
            .FirstOrDefaultAsync();

        if (order is null)
        {
            return NotFound();
        }

        order.StatusOptions =
        [
            new() { Value = "Pending", Text = "Pending" },
            new() { Value = "InProgress", Text = "In Progress" },
            new() { Value = "Done", Text = "Done" }
        ];

        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        if (!Enum.TryParse<OrderStatus>(status, out var newStatus))
        {
            TempData["ErrorMessage"] = "قيمة الحالة غير صحيحة";
            return RedirectToAction(nameof(Details), new { id });
        }

        var order = await _context.Orders.FindAsync(id);

        if (order is null)
        {
            return NotFound();
        }

        try
        {
            order.Status = newStatus;
            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم تحديث الحالة";
            return RedirectToAction(nameof(Details), new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update order {OrderId} status", id);
            TempData["ErrorMessage"] = "حدث خطأ أثناء تحديث الحالة";
            return RedirectToAction(nameof(Index));
        }
    }
}

using HomeServicesBooking.Data;
using HomeServicesBooking.Models;
using HomeServicesBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeServicesBooking.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(ApplicationDbContext context, ILogger<DashboardController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var ordersQuery = _context.Orders.AsNoTracking();

        var viewModel = new DashboardViewModel
        {
            TotalOrdersCount = await ordersQuery.CountAsync(),
            PendingOrdersCount = await ordersQuery.CountAsync(o => o.Status == OrderStatus.Pending),
            DoneOrdersCount = await ordersQuery.CountAsync(o => o.Status == OrderStatus.Done),
            LatestOrders = await ordersQuery
                .OrderByDescending(o => o.CreatedAt)
                .Take(10)
                .Select(o => new LatestOrderViewModel
                {
                    CustomerName = o.CustomerName,
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
                .ToListAsync()
        };

        return View(viewModel);
    }
}

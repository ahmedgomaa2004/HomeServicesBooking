using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeServicesBooking.ViewModels;

public class OrderDetailsViewModel
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string ServiceName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string StatusBadgeClass { get; set; } = string.Empty;

    public string CurrentStatusCode { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<SelectListItem> StatusOptions { get; set; } = [];
}

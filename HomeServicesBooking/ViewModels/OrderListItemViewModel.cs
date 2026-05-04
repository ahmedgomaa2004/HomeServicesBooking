namespace HomeServicesBooking.ViewModels;

public class OrderListItemViewModel
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string ServiceName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string StatusBadgeClass { get; set; } = string.Empty;
}

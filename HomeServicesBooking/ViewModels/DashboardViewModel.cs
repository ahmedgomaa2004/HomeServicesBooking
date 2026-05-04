namespace HomeServicesBooking.ViewModels;

public class DashboardViewModel
{
    public int TotalOrdersCount { get; set; }

    public int PendingOrdersCount { get; set; }

    public int DoneOrdersCount { get; set; }

    public List<LatestOrderViewModel> LatestOrders { get; set; } = [];
}

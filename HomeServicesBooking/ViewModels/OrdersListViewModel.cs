namespace HomeServicesBooking.ViewModels;

public class OrdersListViewModel
{
    public List<OrderListItemViewModel> Orders { get; set; } = [];

    public string? SearchTerm { get; set; }

    public string? StatusFilter { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }
}

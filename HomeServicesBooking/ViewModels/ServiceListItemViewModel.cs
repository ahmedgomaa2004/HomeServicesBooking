namespace HomeServicesBooking.ViewModels;

public class ServiceListItemViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public string IsActiveDisplay { get; set; } = string.Empty;

    public string IsActiveBadgeClass { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

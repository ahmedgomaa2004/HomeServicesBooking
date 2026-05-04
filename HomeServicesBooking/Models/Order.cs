using System.ComponentModel.DataAnnotations;

namespace HomeServicesBooking.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;

    public int? ServiceId { get; set; }

    public Service? Service { get; set; }

    [Required]
    [MaxLength(150)]
    public string ServiceName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}

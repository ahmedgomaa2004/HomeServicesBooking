using System.ComponentModel.DataAnnotations;

namespace HomeServicesBooking.ViewModels;

public class ServiceFormViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "اسم الخدمة مطلوب")]
    [MinLength(3, ErrorMessage = "اسم الخدمة يجب أن يكون 3 حروف على الأقل")]
    [MaxLength(150, ErrorMessage = "اسم الخدمة يجب ألا يتجاوز 150 حرفًا")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "وصف الخدمة مطلوب")]
    [MinLength(10, ErrorMessage = "وصف الخدمة يجب أن يكون 10 حروف على الأقل")]
    [MaxLength(1000, ErrorMessage = "وصف الخدمة يجب ألا يتجاوز 1000 حرف")]
    public string Description { get; set; } = string.Empty;
}

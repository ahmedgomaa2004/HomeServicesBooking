using System.ComponentModel.DataAnnotations;
using HomeServicesBooking.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeServicesBooking.ViewModels;

public class OrderFormViewModel
{
    [Required(ErrorMessage = "الاسم مطلوب")]
    [MinLength(3, ErrorMessage = "الاسم يجب أن يكون 3 حروف على الأقل")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "رقم الموبايل مطلوب")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "رقم الموبايل يجب أن يكون 11 رقم")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "العنوان مطلوب")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "نوع الخدمة مطلوب")]
    public int? ServiceId { get; set; }

    public string? ServiceName { get; set; }

    [Required(ErrorMessage = "تاريخ الحجز مطلوب")]
    [DataType(DataType.Date)]
    [DateNotInPast(ErrorMessage = "لا يمكن اختيار تاريخ في الماضي")]
    public DateTime? OrderDate { get; set; }

    public List<SelectListItem> Services { get; set; } = [];
}

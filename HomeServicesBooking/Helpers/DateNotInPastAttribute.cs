using System.ComponentModel.DataAnnotations;

namespace HomeServicesBooking.Helpers;

public class DateNotInPastAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return true;
        }

        if (value is DateTime date)
        {
            return date.Date >= DateTime.Today;
        }

        return false;
    }
}
